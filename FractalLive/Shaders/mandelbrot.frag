#version 450 core

#define M_PI 3.1415926535897932384626433832795

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

out vec4 FragColor;

in vec2 FragPos;
in vec2 TexCoords;

uniform float time;
uniform float lockedZoom;

uniform int maxIterations;
uniform float power;

uniform int orbitTrap;
uniform float bailout;
uniform float bailoutFactor1;
uniform float bailoutFactor2;
uniform int startOrbit;
uniform int orbitRange;
uniform vec2 bailoutRectangle;
uniform vec2[16] bailoutPoints;
uniform int bailoutPointsCount;
uniform vec4[16] bailoutLines;
uniform int bailoutLinesCount;

uniform bool splitInteriorExterior;
uniform int coloring;
uniform int interiorColoring;
uniform int exteriorColoring;

vec3 Mandelbrot();
vec2 MandelbrotLoop(vec2 c, int maxIteration, inout int iter, inout float trap);
vec2 MandelbrotDistanceLoop(vec2 c, int maxIteration, inout int iter);

void main()
{
	//FragColor = vec4(Mandelbrot() * vec3(TexCoords,1), 1.0);
	FragColor = vec4(Mandelbrot(), 1.0);
}

vec2 c_2(vec2 c);
bool IsBounded(vec2 z);
bool NeedDistance();
float GetOrbitTrap(vec2 z, int iter, inout float trap);
vec3 GetColor(vec2 z, int iter);
vec3 DomainColoring(int coloring, vec2 z, int iter);
vec3 ColorFromHSV(vec3 color);

vec3 Mandelbrot()
{
	int iter = 0;
    float trap = 1e99;
	vec2 z;
    
    z = MandelbrotLoop(FragPos, maxIterations, iter, trap);

	//if (iter >= maxIterations)
		//return vec3(1.0);

    //if (orbitTrap == TRAP_LINE)
        //return vec3(0);

    if (orbitTrap == TRAP_POINTS || orbitTrap == TRAP_LINES)
	    //return vec3(0.5 + 0.5*(sin(bailout*trap))); // 4.5 is a good value
	    //return vec3(trap);
	    return trap * GetColor(z, iter);

	//return vec3(sqrt(float(iter)/maxIterations));
	//return sqrt(float(iter)/maxIterations) *  GetColor(z, iter);
	return GetColor(z, iter);
}

vec2 MandelbrotLoop(vec2 c, int maxIterations, inout int iter, inout float trap)
{
	vec2 z = vec2(0);
    trap = 1e20;
    //trap = length(c);
	for (iter = 0; iter < maxIterations && IsBounded(z); ++iter)
	{
		z = c_2(z) + c;

        trap = GetOrbitTrap(z, iter, trap);
	}
    
    trap = clamp(pow( trap*pow(2,lockedZoom), bailoutFactor1 ), 0.0, 1.0); // control 1
    //trap = clamp(pow( trap*zoom, 0.25 ), 0.0, 1.0); // control 1
    //trap = clamp(pow( trap, 0.25 ), 0.0, 1.0)*pow(2,zoom); // control 1
    trap = 1.0 / (1.0 + exp(-bailoutFactor2 * (trap - 0.5)));  // control 2

	return z;
}

bool IsBounded(vec2 z)
{
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

float length_squared(vec2 a, vec2 b)
{
    return pow(length(b - a), 2);
}

float DistanceToLine(vec2 p, vec2 a, vec2 b)
{
    return abs((b.x-a.x)*(a.y-p.y) - (a.x-p.x)*(b.y-a.y)) / sqrt(pow(b.x-a.x,2) + pow(b.y-a.y,2));
}

float GetOrbitTrap(vec2 z, int iter, inout float trap)
{
    if (iter+1 >= startOrbit && iter+1 <= startOrbit + orbitRange - 1)
        switch (orbitTrap)
        {
            case TRAP_POINTS:
                for (int i = 0; i < bailoutPointsCount; i++)
                    trap = min(trap,dot(z-bailoutPoints[i],z-bailoutPoints[i]));
                break;
            case TRAP_LINES:
                for (int i = 0; i < bailoutLinesCount; i++)
                    trap = min(trap, DistanceToLine(z, bailoutLines[i].xy, bailoutLines[i].zw));
                break;
            default:
                trap = 0;
        }

    return trap;
}

vec2 c_2(vec2 c)
{
    return vec2(c.x*c.x - c.y*c.y, 2*c.x*c.y);
}

vec3 GetColor(vec2 z, int iter)
{
    // Decide the color based on the number of iterations
    vec3 color;
    if (iter >= maxIterations)
    {
        switch (splitInteriorExterior ? interiorColoring : coloring)
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
            default:
                color = DomainColoring(interiorColoring, z, iter);
                break;
        }
    }
    else
    {
        switch (splitInteriorExterior ? exteriorColoring : coloring)
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
                color = vec3(sin(7 * (iter + time) / 17) * .5 + .5, sin(11 * (iter + time) / 29) * .5 + .5, sin(13 * (iter + time) / 41) * .5 + .5);
                break;
            case COL_SMOOTH:
                float mu;
        
                mu = iter;
                //mu = iter + 1 - (log2(log2(length(z))));
                //mu = iter - log2(log2(dot(z,z))) + 4.0;
                //mu = iter - log(log(dot(z,z))/(log(bailout)))/log(power);
                //mu = iter - (log(log(length(z))/log(bailout.x)) / (sign(power)*log(abs(power))));
                mu = iter - (log(log(length(z))/log(bailout.x)) / (sign(power)*log(abs(power) == 1 ? 1.0000001 : abs(power))));
                //mu = iter + 1 - (log(log(length(z))) / (sign(power)*log(abs(power) == 1 ? 1.0000001 : abs(power))));
                //mu = iter - (log(log(length(z))/log(bailout.x)));

                color = vec3(sin(7 * (mu + time) / 17) * .5 + .5, sin(11 * (mu + time) / 29) * .5 + .5, sin(13 * (mu + time) / 41) * .5 + .5);
                break;
            default:
                color = DomainColoring(exteriorColoring, z, iter);
                break;
        }
    }
    
    return color;
}

vec3 DomainColoring(int coloring, vec2 z, int iter)
{
    float t = time * 20;

    vec3 color;

    if (coloring == COL_ITERATION || coloring == COL_SMOOTH)
        //return ColorFromHSV(vec3(atan(FragPosModel.y, FragPosModel.x) * 180 / M_PI + t, 1, 1));
        return ColorFromHSV(vec3(atan(FragPos.y, FragPos.x) * 180 / M_PI + t, 1, 1));

    float theta = sin(atan(float(z.y), float(z.x))) * 360 + t;
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
            color = ColorFromHSV(vec3(theta, 1, 1));
            break;
    }
    
    return color;
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
