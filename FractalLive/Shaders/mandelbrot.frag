#version 450 core


#define TRAP_CIRCLE						0
#define TRAP_SQUARE						1
#define TRAP_REAL						2
#define TRAP_IMAG						3
#define TRAP_RECTANGLE					4
#define TRAP_POINT						5
#define TRAP_LINE						6
#define TRAP_CROSS						7

out vec4 FragColor;

in vec2 FragPos;
in vec2 TexCoords;

uniform int maxIterations;
uniform int orbitTrap;
uniform float bailout;

vec3 Mandelbrot();
vec2 MandelbrotLoop(vec2 c, int maxIteration, inout int iter);

void main()
{
	FragColor = vec4(Mandelbrot() * vec3(TexCoords,1), 1.0);
}

vec2 c_2(vec2 c);
bool WithinOrbitTrap(vec2 z);

vec3 Mandelbrot()
{
	int iter = 0;
	vec2 z = MandelbrotLoop(FragPos, maxIterations, iter);

	if (iter >= maxIterations)
		return vec3(1.0);

	return vec3(sqrt(float(iter)/maxIterations));
}

vec2 MandelbrotLoop(vec2 c, int maxIterations, inout int iter)
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
        case TRAP_CIRCLE:
            return z.x*z.x + z.y*z.y < bailout*bailout;
        case TRAP_SQUARE:
            return abs(z.x) < bailout && abs(z.y) < bailout;
        case TRAP_REAL:
            return abs(z.x) < bailout;
        case TRAP_IMAG:
            return abs(z.y) < bailout;
        //case TRAP_RECTANGLE:
            //return abs(z.x) < bailout.x && abs(z.y) < bailout.y;
        default:
            return (sin(z.y) < sin(bailout.x));
    }

    return false;
}

vec2 c_2(vec2 c)
{
    return vec2(c.x*c.x - c.y*c.y, 2*c.x*c.y);
}