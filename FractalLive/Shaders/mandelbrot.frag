#version 450 core


#define TRAP_CUSTOM						-1
#define TRAP_CIRCLE						0
#define TRAP_SQUARE						1
#define TRAP_REAL						2
#define TRAP_IMAG						3
#define TRAP_RECTANGLE					4
#define TRAP_POINT						5
#define TRAP_TRIANGLE					6
#define TRAP_LINE						7
#define TRAP_CROSS						8

out vec4 FragColor;

in vec2 FragPos;
in vec2 TexCoords;

uniform float zoom;

uniform int maxIterations;
uniform int orbitTrap;
uniform float bailout;
uniform vec2 bailoutRectangle;
uniform vec2 bailoutPoint;

vec3 Mandelbrot();
vec2 MandelbrotLoop(vec2 c, int maxIteration, inout int iter, inout float trap);
vec2 MandelbrotDistanceLoop(vec2 c, int maxIteration, inout int iter);

void main()
{
	FragColor = vec4(Mandelbrot() * vec3(TexCoords,1), 1.0);
}

vec2 c_2(vec2 c);
bool WithinOrbitTrap(vec2 z);
bool NeedDistance();

vec3 Mandelbrot()
{
	int iter = 0;
    float trap = 1e99;
	vec2 z;
    
    if (NeedDistance())
        z = MandelbrotDistanceLoop(FragPos, maxIterations, iter);
    else
        z = MandelbrotLoop(FragPos, maxIterations, iter, trap);

	//if (iter >= maxIterations)
		//return vec3(1.0);

    if (orbitTrap == TRAP_POINT)
	    return (0.5 + 0.5*sin( 4.1 + 2.0*trap + vec3(1.0,0.5,0.0) )) * pow( clamp( 2.00*zoom,    0.0, 1.0 ), 0.5 );

	return vec3(sqrt(float(iter)/maxIterations));
}

vec2 MandelbrotLoop(vec2 c, int maxIterations, inout int iter, inout float trap)
{
	vec2 z = vec2(0);
	for (iter = 0; iter < maxIterations && WithinOrbitTrap(z); ++iter)
	{
		z = c_2(z) + c;

        if (orbitTrap == TRAP_POINT)
            //trap = min(trap, length(z - bailoutPoint));
            trap = min(trap, dot(z-bailoutPoint,z-bailoutPoint));
	}
    
    trap = pow( clamp( 0.4*trap, 0.0, 1.0 ), 0.25 );

	return z;
}

vec2 MandelbrotDistanceLoop(vec2 c, int maxIterations, inout int iter)
{
	vec2 z = vec2(0);
	for (iter = 0; iter < maxIterations && WithinOrbitTrap(z); ++iter)
	{
		z = c_2(z) + c;
	}

	return z;
}

bool WithinOrbitTrap(vec2 z)
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
    }

    return false;
}

vec2 c_2(vec2 c)
{
    return vec2(c.x*c.x - c.y*c.y, 2*c.x*c.y);
}

bool NeedDistance()
{
    return orbitTrap == TRAP_LINE || orbitTrap == TRAP_CROSS;
}