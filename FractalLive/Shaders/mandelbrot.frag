#version 450 core

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
uniform float startOrbitDistance;
uniform int startOrbit;
uniform int orbitRange;
uniform float bailoutFactor1;
uniform float bailoutFactor2;

uniform bool splitInteriorExterior;
uniform int coloring;
uniform int interiorColoring;
uniform int exteriorColoring;
uniform float colorCycle;
uniform float colorFactor;
uniform float orbitTrapFactor;
uniform int domainCalculation;
uniform bool useDomainIteration;

vec3 Mandelbrot();

void main()
{
	//FragColor = vec4(Mandelbrot() * vec3(TexCoords,1), 1.0);
	FragColor = vec4(Mandelbrot(), 1.0);
}

vec2 MandelbrotLoop(vec2 c, inout int iter, inout float trap, out vec2 domainZ, out int domainIter);
vec2 MandelbrotDistanceLoop(vec2 c, int maxIteration, inout int iter);
vec3 GetColor(vec2 z, int iter, float trap, vec2 domainZ, int domainIter);
vec3 DomainColoring(int coloring, vec2 z, int iter, float trap);
bool IsBounded(int iter, vec2 z);
float GetOrbitTrap(vec2 z, int iter, inout float trap);
float CalculateOrbitTrap(float trap, float newDist, int iter);
vec2 CalculateDomainZ(vec2 domainZ, vec2 newZ, int iter, inout int domainIter);
float GetSmoothIter(float iter, vec2 z);
vec2 Fix(vec2 z);
vec3 ColorFromHSV(vec3 color);
vec3 Rainbow(float mu);
float sigmoid(float x, float factor);
vec3 sigmoid(vec3 v, float factor);
vec2 c_conj(vec2 c);
vec2 c_2(vec2 c);
vec2 c_mul(vec2 a, vec2 b);
vec2 c_div(vec2 a, vec2 b);
vec2 c_pow(vec2 c, float p);
vec2 c_invert(vec2 c);
vec3 ColorFromHSV(vec3 color);
float DistanceToLine(vec2 p, vec2 a, vec2 b);

vec3 Mandelbrot()
{
	int iter = 0;
    float trap = 1e99;
	vec2 z;
	vec2 domainZ;
    int domainIter;
    
    z = MandelbrotLoop(FragPos, iter, trap, domainZ, domainIter);

	//if (iter >= maxIterations)
		//return vec3(1.0);

    //if (orbitTrap == TRAP_LINE)
        //return vec3(0);

    //if (orbitTrap != TRAP_POINTS && orbitTrap != TRAP_LINES)
	    //return vec3(0.5 + 0.5*(sin(bailout*trap))); // 4.5 is a good value
	    //return vec3(7*trap);
	    //trap = 0;

	//return vec3(sqrt(float(iter)/maxIterations));
	//return sqrt(float(iter)/maxIterations) *  GetColor(z, iter);
	return GetColor(z, iter, trap, domainZ, domainIter);
    

	//return 0.5 + 0.5*sin(GetColor(z, iter, trap) * colorCycle);colorFactor;
}

vec2 MandelbrotLoop(vec2 c, inout int iter, inout float trap, out vec2 domainZ, out int domainIter)
{
	vec2 z = vec2(0);
    domainZ = c;
    trap = startOrbitDistance;
	for (iter = 0; iter < maxIterations && IsBounded(iter, z); ++iter)
	//IsBounded(z);for (iter = 0; iter < maxIterations; ++iter)
	{
        if (useConjugate)
            z = c_conj(z);
        
		z = c_pow(z, power) + c_pow(c, c_power);

        z = Fix(z);

        domainZ = CalculateDomainZ(domainZ, z, iter, domainIter);

        trap = GetOrbitTrap(z, iter, trap);
	}
    
    trap = clamp(pow( trap*pow(2,lockedZoom), bailoutFactor1 ), 0.0, 1.0); // control 1
    trap = sigmoid(trap, bailoutFactor2);  // control 2

	return z;
}

vec3 GetColor(vec2 z, int iter, float trap, vec2 domainZ, int domainIter)
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
                color = (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES) ? mix(Rainbow(orbitTrapFactor*trap), Rainbow(iter), trap) : Rainbow(iter);
                break;
            case COL_SMOOTH:
                float mu;
        
                mu = GetSmoothIter(iter, z);

                //color = Rainbow(mu + (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES ? 10*trap : 1));
                //color = Rainbow(mu) * (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES ? Rainbow(trap) : vec3(1));
                color = (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES) ? mix(Rainbow(orbitTrapFactor*trap), Rainbow(mu), trap) : Rainbow(mu);
                //color = 0.5*Rainbow(mu) + (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES ? 0.5*Rainbow(10*trap) : 0.5*Rainbow(mu));
                break;
            default:
                color = DomainColoring(c, domainZ, domainIter, trap);
                break;
        }
    }
    
    return sigmoid(color, colorFactor);
}

vec3 DomainColoring(int coloring, vec2 z, int iter, float trap)
{
    //float t = (time + trap) * 20;
    float t = time * 20;

    vec3 color;

    float theta = atan(z.y, z.x) * 180/M_PI * colorCycle + t;
	float r = length(z);
        	
	if (z.x == 0 && z.y == 0)
	{
		theta = 0;
		r = 0;
	}
	else if (isnan(z.x) || isnan(z.y))
	{
		z = vec2(0);
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

    if (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES)
        if (coloring <= COL_SMOOTH)
            color = mix(Rainbow(orbitTrapFactor*trap * (useDomainIteration ? iter : 1)), color, trap);
        else
            color = mix(color, color*sigmoid(trap,orbitTrapFactor), trap) * (useDomainIteration ? Rainbow(iter) : vec3(1));
            //color = mix(color, vec3(0), trap);
    else if (useDomainIteration)
        color *= Rainbow(iter);

    return color;
}

bool IsBounded(int iter, vec2 z)
{
    if (iter < minIterations)
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

float GetOrbitTrap(vec2 z, int iter, inout float trap)
{
    if (iter+1 >= startOrbit && iter+1 <= startOrbit + orbitRange - 1)
        switch (orbitTrap)
        {
            case TRAP_POINTS:
                for (int i = 0; i < bailoutPointsCount; i++)
                    trap = CalculateOrbitTrap(trap, dot(z-bailoutPoints[i],z-bailoutPoints[i]), iter);
                break;
            case TRAP_LINES:
                for (int i = 0; i < bailoutLinesCount; i++)
                    trap = CalculateOrbitTrap(trap, DistanceToLine(z, bailoutLines[i].xy, bailoutLines[i].zw), iter);
                break;
            default:
                trap = 0;
        }

    return trap;
}

float CalculateOrbitTrap(float trap, float newDist, int iter)
{
    switch (orbitTrapCalculation)
    {
        case CALC_MIN:
            return min(trap, newDist);
        case CALC_MAX:
            return max(trap, newDist);
        case CALC_AVG:
            return (trap + newDist) / 2;
        case CALC_FIRST:
            return (iter+1 == startOrbit) ? newDist : trap;
        case CALC_LAST:
            return newDist;
        default:
            return 0;
    }
}

vec2 CalculateDomainZ(vec2 domainZ, vec2 newZ, int iter, inout int domainIter)
{
    float ldz = length(domainZ);
    float lz = length(newZ);

    float ldtheta = atan(float(domainZ.y), float(domainZ.x));
    float ltheta = atan(float(domainZ.y), float(domainZ.x));

    switch (domainCalculation)
    {
        case CALC_MIN:
            if (lz < ldz)
            {
                domainIter = iter;
                return newZ;
            }
            return domainZ;
        case CALC_MAX:
            if (lz > ldz)
            {
                domainIter = iter;
                return newZ;
            }
            return domainZ;
        case CALC_AVG:
            domainIter = iter;
            return (domainZ + newZ) / 2;
        case CALC_FIRST:
            if (iter+1 == startOrbit)
            {
                domainIter = iter;
                return newZ;
            }
            return domainZ;
         case CALC_LAST:
            domainIter = iter;
            return newZ;
        default:
            domainIter = iter;
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

float sigmoid(float x, float factor)
{
    return 1.0 / (1.0 + exp(-factor * (x - 0.5)));
}
vec3 sigmoid(vec3 v, float factor)
{
    return 1.0 / (1.0 + exp(-factor * (v - 0.5)));
}

float DistanceToLine(vec2 p, vec2 a, vec2 b)
{
    return abs((b.x-a.x)*(a.y-p.y) - (a.x-p.x)*(b.y-a.y)) / sqrt(pow(b.x-a.x,2) + pow(b.y-a.y,2));
}