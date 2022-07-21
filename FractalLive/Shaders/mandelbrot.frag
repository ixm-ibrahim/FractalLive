﻿#version 450 core

#define M_PI            3.1415926535897932384626433832795
#define MAX_LENGTH      1e15

#define TRAP_CUSTOM						-1
#define TRAP_CIRCLE						0
#define TRAP_SQUARE						1
#define TRAP_REAL						2
#define TRAP_IMAG						3
#define TRAP_RECTANGLE					4
#define TRAP_POINTS						5
#define TRAP_LINES						6

#define COL_CUSTOM						-1
#define COL_BLACK						0
#define COL_WHITE						1
#define COL_ITERATION                   2
#define COL_SMOOTH                      3
#define COL_DOMAIN_SIMPLE               4
#define COL_DOMAIN_NORMAL               5
#define COL_DOMAIN_BRIGHTNESS           6
#define COL_DOMAIN_BRIGHT_RINGS         7
#define COL_DOMAIN_BRIGHT_RINGS_SMOOTH  8
#define COL_DOMAIN_DARK_RINGS           9
#define COL_DOMAIN_BRIGHT_DARK_SMOOTH   10

#define CALC_MIN                        0
#define CALC_MAX                        1
#define CALC_AVG                        2
#define CALC_FIRST                      3
#define CALC_LAST                       4

out vec4 FragColor;

in vec2 FragPos;
in vec2 TexCoords;

uniform float time;
uniform float lockedZoom;

uniform int maxIterations;
uniform int minIterations;
uniform bool useConjugate;
uniform float power;
uniform float c_power;

uniform int orbitTrap;
uniform float bailout;
uniform vec2 bailoutRectangle;
uniform vec2[16] bailoutPoints;
uniform int bailoutPointsCount;
uniform vec4[16] bailoutLines;
uniform int bailoutLinesCount;
uniform int orbitTrapCalculation;
uniform bool useSecondValue;
uniform float startOrbitDistance;
uniform int startOrbit;
uniform int orbitRange;
uniform float bailoutFactor1;
uniform float bailoutFactor2;
uniform float secondValueFactor1;
uniform float secondValueFactor2;

uniform bool splitInteriorExterior;
uniform int coloring;
uniform int interiorColoring;
uniform int exteriorColoring;
uniform float colorCycle;
uniform float colorFactor;
uniform float orbitTrapFactor;
uniform int domainCalculation;
uniform bool matchOrbitTrap;
uniform bool useDomainSecondValue;
uniform float secondDomainValueFactor1;
uniform float secondDomainValueFactor2;
uniform bool useDomainIteration;

vec3 Mandelbrot();

void main()
{
	//FragColor = vec4(Mandelbrot() * vec3(TexCoords,1), 1.0);
	FragColor = vec4(Mandelbrot(), 1.0);
}

vec2 MandelbrotLoop(vec2 c, inout int iter, inout vec2 trap, out vec4 domainZ, out ivec2 domainIter);
vec3 GetColor(vec2 z, int iter, vec2 trap, vec4 domainZ, ivec2 domainIter);
vec3 DomainColoring(int coloring, vec4 z, ivec2 iter, vec2 trap);
bool IsBounded(int iter, vec2 z);
bool IsWithinIteration(int iter);
vec2 GetOrbitTrap(vec2 z, int iter, inout vec2 trap, inout vec4 domainZ, inout ivec2 domainIter);
vec2 CalculateOrbitTrapDistance(vec2 trap, float newDist, int iter, vec2 newZ, inout vec4 domainZ, inout ivec2 domainIter);
vec4 CalculateDomainZ(vec4 domainZ, vec2 newZ, int iter, inout ivec2 domainIter);
float GetSmoothIter(float iter, vec2 z);
vec2 Fix(vec2 z);
vec3 ColorFromHSV(vec3 color);
vec3 Rainbow(float mu);
float DistanceToPoint(vec2 z, vec2 p);
float DistanceToLine(vec2 p, vec2 a, vec2 b);
float sigmoid(float x, float factor);
vec3 sigmoid(vec3 v, float factor);
vec2 c_conj(vec2 c);
vec2 c_2(vec2 c);
vec2 c_mul(vec2 a, vec2 b);
vec2 c_div(vec2 a, vec2 b);
vec2 c_pow(vec2 c, float p);
vec2 c_invert(vec2 c);
vec3 ColorFromHSV(vec3 color);

vec3 Mandelbrot()
{
	int iter = 0;
    vec2 trap = vec2(startOrbitDistance);
	vec2 z;
	vec4 domainZ;
    ivec2 domainIter;
    
    z = MandelbrotLoop(FragPos, iter, trap, domainZ, domainIter);

	//if (iter >= maxIterations)
		//return vec3(1.0);

    //if (orbitTrap == TRAP_LINE)
        //return vec3(0);

    //if (orbitTrap != TRAP_POINTS && orbitTrap != TRAP_LINES)
	    //return vec3(0.5 + 0.5*(sin(bailout*trap.x))); // 4.5 is a good value
	    //return vec3(7*trap);
	    //trap = 0;

	//return vec3(sqrt(float(iter)/maxIterations));
	//return sqrt(float(iter)/maxIterations) *  GetColor(z, iter);
	return GetColor(z, iter, trap, domainZ, domainIter);
    

	//return 0.5 + 0.5*sin(GetColor(z, iter, trap) * colorCycle);colorFactor;
}

vec2 MandelbrotLoop(vec2 c, inout int iter, inout vec2 trap, out vec4 domainZ, out ivec2 domainIter)
{
	vec2 z = vec2(0);
    domainZ = vec4(c,c);
    trap = vec2(startOrbitDistance);
	for (iter = 0; iter < maxIterations && IsBounded(iter, z); ++iter)
	{
        if (useConjugate)
            z = c_conj(z);
        
		z = c_pow(z, power) + c_pow(c, c_power);
        z = Fix(z);

        trap = GetOrbitTrap(z, iter, trap, domainZ, domainIter);
	}
    


    if (useSecondValue)
    {
        if (trap.y > trap.x)
            trap.x /= trap.y;
        else
            trap.x = trap.y / trap.x;

        trap.x = pow(sigmoid(trap.x, secondValueFactor1), secondValueFactor2);
        //trap.x = sigmoid(trap.x, secondValueFactor1) * pow(trap.x, secondValueFactor2);
    }

    trap.x = sigmoid(pow( trap.x*pow(2,lockedZoom), bailoutFactor1 ), bailoutFactor2);

	return z;
}

vec3 GetColor(vec2 z, int iter, vec2 trap, vec4 domainZ, ivec2 domainIter)
{
    // Decide the color based on the number of iterations
    vec3 color;
    if (iter >= maxIterations)
    {
        int c = splitInteriorExterior ? interiorColoring : coloring;
        
        switch (c)
        {
            case COL_CUSTOM:
                vec3 outerColor1 = vec3(0.13f, 0.94f, 0.13f);
                vec3 outerColor2 = vec3(0.0f, 0.47f, 0.95f);
            
                float theta = sin(atan(float(z.y), float(z.x)) + time)*.5 + .5;

                color = mix(outerColor1, outerColor2, theta);
                break;
            case COL_BLACK:
                color = vec3(0);
                break;
            case COL_WHITE:
                color = vec3(1);
                break;
            case COL_ITERATION:
            case COL_SMOOTH:
            default:
                color = DomainColoring(c, domainZ, domainIter, trap);
                break;
        }
    }
    else
    {
        int c = splitInteriorExterior ? exteriorColoring : coloring;

        switch (c)
        {
            case COL_CUSTOM:
                vec3 outerColor1 = vec3(0.13f, 0.94f, 0.13f);
                vec3 outerColor2 = vec3(0.0f, 0.47f, 0.95f);
            
                //float theta = sin(atan(float(z.y), float(z.x)) + time)*.5 + .5;

                //color = mix(outerColor1, outerColor2, theta);
                //color = mix(outerColor1, outerColor2, dist);
                color = mix(outerColor1, outerColor2, iter/maxIterations);
                break;
            case COL_BLACK:
                color = vec3(0);
                break;
            case COL_WHITE:
                color = vec3(1);
                break;
            case COL_ITERATION:
                //color = Rainbow(iter * (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES ? trap : 1));
                color = (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES) ? mix(Rainbow(orbitTrapFactor*trap.x), Rainbow(iter), trap.x) : Rainbow(iter);
                break;
            case COL_SMOOTH:
                float mu;
        
                mu = GetSmoothIter(iter, z);

                //color = Rainbow(mu + (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES ? 10*trap : 1));
                //color = Rainbow(mu) * (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES ? Rainbow(trap) : vec3(1));
                color = (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES) ? mix(Rainbow(orbitTrapFactor*trap.x), Rainbow(mu), trap.x) : Rainbow(mu);
                //color = 0.5*Rainbow(mu) + (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES ? 0.5*Rainbow(10*trap) : 0.5*Rainbow(mu));
                break;
            default:
                color = DomainColoring(c, domainZ, domainIter, trap);
                break;
        }
    }
    
    return sigmoid(color, colorFactor);
}

vec3 DomainColoring(int coloring, vec4 z, ivec2 iter, vec2 trap)
{
    //float t = (time + trap) * 20;
    float t = time * 20;
    
    secondDomainValueFactor1;
    secondDomainValueFactor2;

    vec3 color;

    float theta = atan(z.y, z.x) / (2*M_PI) + M_PI;
	float r = length(z.xy);

    if (useDomainSecondValue)
    {
        float r2 = length(z.zw);
        
        if (matchOrbitTrap)
        {
            vec4 dummyDomainZ;
            ivec2 dummyDomainIter;
            vec2 trap;
            switch (orbitTrap)
            {
                case TRAP_POINTS:
                    trap.x = DistanceToPoint(z.xy, bailoutPoints[0]);
                    for (int i = 1; i < bailoutPointsCount; i++)
                        trap = CalculateOrbitTrapDistance(trap, DistanceToPoint(z.xy, bailoutPoints[i]), iter.x, z.xy, dummyDomainZ, dummyDomainIter);
                    r = trap.x;

                    trap.x = DistanceToPoint(z.zw, bailoutPoints[0]);
                    for (int i = 1; i < bailoutPointsCount; i++)
                        trap = CalculateOrbitTrapDistance(trap, DistanceToPoint(z.zw, bailoutPoints[i]), iter.x, z.zw, dummyDomainZ, dummyDomainIter); 
                    r2 = trap.x;

                    break;
                case TRAP_LINES:
                    trap.x = DistanceToLine(z.xy, bailoutLines[0].xy, bailoutLines[0].zw);
                    for (int i = 1; i < bailoutLinesCount; i++)
                        trap = CalculateOrbitTrapDistance(trap, DistanceToLine(z.xy, bailoutLines[i].xy, bailoutLines[i].zw), iter.x, z.xy, dummyDomainZ, dummyDomainIter);
                    r = trap.x;

                    trap.x = DistanceToLine(z.zw, bailoutLines[0].xy, bailoutLines[0].zw);
                    for (int i = 1; i < bailoutLinesCount; i++)
                        trap = CalculateOrbitTrapDistance(trap, DistanceToLine(z.zw, bailoutLines[i].xy, bailoutLines[i].zw), iter.x, z.zw, dummyDomainZ, dummyDomainIter); 
                    r2 = trap.x;

                    break;
            }
        }

        if (r2 > r)
            r /= r2;
        else
            r = r2 / r;

        r = pow(r, secondDomainValueFactor1) * sigmoid(r, secondDomainValueFactor2);

        theta *= r;
    }
    
    theta = theta * 360 * colorCycle + t;

	if (z.x == 0 && z.y == 0)
	{
		theta = 0;
		r = 0;
	}
	else if (isnan(z.x) || isnan(z.y))
	{
		z = vec4(0);
		theta = 0;
		r = 0;
	}

    float twoPI = 2 * M_PI;
    float s = abs(sin(mod(r * twoPI, twoPI)));
	float b = sqrt(sqrt(abs(sin(mod(z.y * twoPI, twoPI)) * sin(mod(z.x * twoPI, twoPI)))));
	float b2 = .5 * ((1 - s) + b + sqrt(pow(1 - s - b, 2) + 0.01));

    switch (coloring)
    {
        case COL_DOMAIN_NORMAL:
            color = ColorFromHSV(vec3(theta, s, b2 > 1 ? 1 : b2));
            break;
        case COL_DOMAIN_BRIGHTNESS:
            color = ColorFromHSV(vec3(theta, 1, b2 > 1 ? 1 : b2));
            break;
        case COL_DOMAIN_BRIGHT_RINGS:
            color = ColorFromHSV(vec3(theta, s, 1));
            break;
        case COL_DOMAIN_BRIGHT_RINGS_SMOOTH:
            color = ColorFromHSV(vec3(theta, mod(r,1), 1));
            break;
        case COL_DOMAIN_DARK_RINGS:
            color = ColorFromHSV(vec3(theta, 1, s));
            break;
        case COL_DOMAIN_BRIGHT_DARK_SMOOTH:
            color = ColorFromHSV(vec3(theta, 1, mod(r,1)));
            break;
        default:
            //color = mix(outerColor1, outerColor2, theta);
            //float test = log(length(c_invert(z)));
            color = ColorFromHSV(vec3(theta, 1, 1));
            break;
    }

    if (useDomainIteration)
    {
        color *= Rainbow(iter.x);
        //color = mix(color, Rainbow(iter.x), float(iter.x)/maxIterations);
        
        if (useDomainSecondValue)
            color = mix(Rainbow(iter.x), vec3(r), r);
        else
            color = Rainbow(iter.x);
    }

    if (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES)
        if (coloring <= COL_SMOOTH)
            color = mix(Rainbow(orbitTrapFactor*trap.x), color, trap.x);
        else
            color = mix(color, color*sigmoid(trap.x,orbitTrapFactor), trap.x);
            //color = mix(color, vec3(0), trap);

    return color;
}

bool IsBounded(int iter, vec2 z)
{
    if (!IsWithinIteration(iter))
        return true;

    switch (orbitTrap)
    {
        case TRAP_CUSTOM:
            return (sin(z.y) < sin(bailout.x));
        case TRAP_SQUARE:
            return abs(z.x) < bailout && abs(z.y) < bailout;
        case TRAP_REAL:
            return abs(z.x) < bailout;
        case TRAP_IMAG:
            return abs(z.y) < bailout;
        case TRAP_RECTANGLE:
            return abs(z.x) < bailoutRectangle.x && abs(z.y) < bailoutRectangle.y;
        default:
            return z.x*z.x + z.y*z.y < bailout*bailout;
            //return z.x*z.x + z.y*z.y < 1024;
    }

    return false;
}

bool IsWithinIteration(int iter)
{
    return iter+1 >= startOrbit && iter+1 <= startOrbit + orbitRange - 1 && iter > minIterations;
}

vec2 GetOrbitTrap(vec2 z, int iter, inout vec2 trap, inout vec4 domainZ, inout ivec2 domainIter)
{
    if (IsWithinIteration(iter))
        switch (orbitTrap)
        {
            case TRAP_POINTS:
                for (int i = 0; i < bailoutPointsCount; i++)
                    trap = CalculateOrbitTrapDistance(trap, DistanceToPoint(z, bailoutPoints[i]), iter, z, domainZ, domainIter); 
                break;
            case TRAP_LINES:
                for (int i = 0; i < bailoutLinesCount; i++)
                    trap = CalculateOrbitTrapDistance(trap, DistanceToLine(z, bailoutLines[i].xy, bailoutLines[i].zw), iter, z, domainZ, domainIter);
                break;
            default:
                trap.x = 0;
        }

    return trap;
}

vec2 CalculateOrbitTrapDistance(vec2 trap, float newDist, int iter, vec2 newZ, inout vec4 domainZ, inout ivec2 domainIter)
{
    if (!IsWithinIteration(iter))
        return trap;

    if (matchOrbitTrap)
    {
        switch (orbitTrapCalculation)
        {
            case CALC_MIN:
                if (newDist < trap.x)
                {
                    domainIter.x = iter;
                    domainZ = vec4(newZ,domainZ.xy);

                    return vec2(newDist, trap.x);
                }
                else if (newDist < trap.y)
                {
                    domainIter.y = iter;
                    domainZ = vec4(domainZ.xy,newZ);

                    return vec2(trap.x, newDist);
                }

                return trap;
            case CALC_MAX:
                if (newDist > trap.x)
                {
                    domainIter.x = iter;
                    domainZ = vec4(newZ,domainZ.xy);

                    return vec2(newDist, trap.x);
                }
                else if (newDist > trap.y)
                {
                    domainIter.y = iter;
                    domainZ = vec4(domainZ.xy,newZ);
                    
                    return vec2(trap.x, newDist);
                }

                return trap;
            case CALC_AVG:
                domainIter.x = iter;
                domainIter.x = iter-1;
                domainZ = vec4((domainZ.xy + newZ) / 2, domainZ.xy);

                return vec2((trap.x + newDist) / 2, trap.x);
            case CALC_FIRST:
                int start = (minIterations > startOrbit) ? minIterations : startOrbit;

                // first
                if (iter+1 == start)
                {
                    domainIter.x = iter;
                    domainZ = vec4(newZ,domainZ.xy);
                    
                    return vec2(newDist, trap.x);
                }
                // second
                if (iter+1 == start+1)
                {
                    domainIter.y = iter;
                    domainZ = vec4(domainZ.xy,newZ);
                    
                    vec2(trap.x, newDist);
                }

                return trap;
            case CALC_LAST:
                domainIter.x = iter;
                domainIter.y = iter-1;
                domainZ = vec4(newZ, domainZ.xy);

                return vec2(newDist, trap.x);
            default:
                return vec2(0);
        }
    }
    else
    {
        domainZ = CalculateDomainZ(domainZ, newZ, iter, domainIter);

        switch (orbitTrapCalculation)
        {
            case CALC_MIN:
                if (newDist < trap.x)
                    return vec2(newDist, trap.x);
                else if (newDist < trap.y)
                    return vec2(trap.x, newDist);

                return trap;
            case CALC_MAX:
                if (newDist > trap.x)
                    return vec2(newDist, trap.x);

                return trap;
            case CALC_AVG:
                return vec2((trap.x + newDist) / 2, trap.x);
            case CALC_FIRST:
                int start = (minIterations > startOrbit) ? minIterations : startOrbit;

                // first
                if (iter+1 == start)
                    return vec2(newDist, trap.x);
                // second
                if (iter+1 == start+1)
                    vec2(trap.x, newDist);

                return trap;
            case CALC_LAST:
                return vec2(newDist, trap.x);
            default:
                return vec2(0);
        }
    }
    
}

vec4 CalculateDomainZ(vec4 domainZ, vec2 newZ, int iter, inout ivec2 domainIter)
{
    if (!IsWithinIteration(iter))
        return domainZ;
        
    float ldz = length(domainZ.xy);
    float ldz2 = length(domainZ.zw);
    float lz = length(newZ);

    switch (domainCalculation)
    {
        case CALC_MIN:
            if (lz < ldz)
            {
                domainIter.x = iter;
                return vec4(newZ,domainZ.xy);
            }
            else if (lz < ldz2)
            {
                domainIter.y = iter;
                return vec4(domainZ.xy,newZ);
            }
            return domainZ;
        case CALC_MAX:
            if (lz > ldz)
            {
                domainIter.x = iter;
                return vec4(newZ,domainZ.xy);
            }
            else if (lz > ldz2)
            {
                domainIter.y = iter;
                return vec4(domainZ.xy,newZ);
            }
            return domainZ;
        case CALC_AVG:
            domainIter.x = iter;
            domainIter.x = iter-1;
            return vec4((domainZ.xy + newZ) / 2, domainZ.xy);
        case CALC_FIRST:
            int start = (minIterations > startOrbit) ? minIterations : startOrbit;

            // first
            if (iter+1 == start)
            {
                domainIter.x = iter;
                return vec4(newZ,domainZ.xy);
            }
            // second
            if (iter+1 == start+1)
            {
                domainIter.y = iter;
                return vec4(domainZ.xy,newZ);
            }

            return domainZ;
         case CALC_LAST:
            domainIter.x = iter;
            domainIter.y = iter-1;
            return vec4(newZ, domainZ.xy);
        default:
            return domainZ;
    }
}

float GetSmoothIter(float iter, vec2 z)
{
    if (coloring == COL_SMOOTH)
        //mu = iter;
        //return iter + 1 - (log2(log2(length(z))));
        //return clamp(log2(log(length(z)) / log(bailout)), 0.0, 1.0);
        //return iter - log2(log2(dot(z,z))) + 4.0;
        //return iter - log(log(dot(z,z))/(log(bailout)))/log(power);
        //return iter - (log(log(length(z))/log(bailout)) / (sign(power)*log(abs(power))));
        //return iter - (log(log(length(z))/log(bailout)) / (sign(power)*log(abs(power) == 1 ? 1.0000001 : abs(power))));
        return iter + 1 - (log(log(length(z))) / (sign(power)*log(abs(power) == 1 ? 1.0000001 : abs(power))));
        //return iter - (log(log(length(z))/log(bailout)));
    
    return iter;
}

vec2 Fix(vec2 z)
{
//    if (isnan(z.x))
//        z.x = 0;
//    if (isnan(z.y))
//        z.y = 0;
//    if (length(z) > MAX_LENGTH)
//        z = MAX_LENGTH * normalize(z);

    return z;
}

vec3 ColorFromHSV(vec3 color)
{
    float hi = mod(floor(color.x / 60.0), 6);
    float f = color.x / 60.0 - floor(color.x / 60.0);

    //value = value * 255;
    float v = color.z;
    float p = color.z * (1 - color.y);
    float q = color.z * (1 - f * color.y);
    float t = color.z * (1 - (1 - f) * color.y);

    if (hi == 0)
        return vec3(v, t, p);
    if (hi == 1)
        return vec3(q, v, p);
    if (hi == 2)
        return vec3(p, v, t);
    if (hi == 3)
        return vec3(p, q, v);
    if (hi == 4)
        return vec3(t, p, v);

    return vec3(v, p, q);
}

vec3 Rainbow(float mu)
{
    return vec3(sin(colorCycle * 7 * (mu + time) / 17) * .5 + .5, sin(colorCycle * 11 * (mu + time) / 29) * .5 + .5, sin(colorCycle * 13 * (mu + time) / 41) * .5 + .5);
}

float DistanceToPoint(vec2 z, vec2 p)
{
    return length(z - p);
}
float DistanceToLine(vec2 p, vec2 a, vec2 b)
{
    return abs((b.x-a.x)*(a.y-p.y) - (a.x-p.x)*(b.y-a.y)) / sqrt(pow(b.x-a.x,2) + pow(b.y-a.y,2));
}

float sigmoid(float x, float factor)
{
    return 1.0 / (1.0 + exp(-factor * (x - 0.5)));
}
vec3 sigmoid(vec3 v, float factor)
{
    return 1.0 / (1.0 + exp(-factor * (v - 0.5)));
}

vec2 c_mul(vec2 a, vec2 b)
{
    return vec2(a.x*b.x - a.y*b.y, a.x*b.y + a.y*b.x);
}
vec2 c_invert(vec2 c)
{
    float l = pow(length(c),2);
    return vec2(c.x / l, -c.y / l);
}
vec2 c_div(vec2 a, vec2 b)
{
    float x = dot(b,b);
    return vec2((a.x*b.x + a.y*b.y) / x, (a.y*b.x - a.x*b.y) / x);
}
vec2 c_conj(vec2 c)
{
    return vec2(c.x, -c.y);
}
vec2 c_2(vec2 c)
{
    return vec2(c.x*c.x - c.y*c.y, 2*c.x*c.y);
}
vec2 c_pow(vec2 c, float a)
{
    if (c.x == 0 && c.y == 0)
        return c;
	if (a == 1)
        return c;
	if (a == 2)
        return c_2(c);
    else if (int(a) == a)
    {
        vec2 original = c;
        float p = abs(a);

        for (p; p - 1 > 0; p--)
            c = c_mul(c, original);

        if (a < 0)
            return c_div(vec2(1,0), c);
        
        return c;
    }
    
    float r = length(c);
    float theta = atan(c.y, c.x);   
    return isnan(r) || isnan(theta) ? c : pow(r, a) * vec2(cos(theta * a), sin(theta * a));
}
