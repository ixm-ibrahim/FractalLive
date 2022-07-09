﻿#version 450 core

#define M_PI 3.1415926535897932384626433832795


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
uniform vec4 bailoutLine;

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
float GetOrbitTrap(vec2 z, inout float trap);

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

    //if (orbitTrap == TRAP_LINE)
        //return vec3(0);

    if (orbitTrap == TRAP_POINT || orbitTrap == TRAP_LINE)
	    //return vec3(0.5 + 0.5*(sin(bailout*trap)));
	    return vec3(trap);

	return vec3(sqrt(float(iter)/maxIterations));
}

vec2 MandelbrotLoop(vec2 c, int maxIterations, inout int iter, inout float trap)
{
	vec2 z = vec2(0);
    trap = 1e20;
    //trap = length(c);
	for (iter = 0; iter < maxIterations && IsBounded(z); ++iter)
	{
		z = c_2(z) + c;

        trap = GetOrbitTrap(z, trap);
	}
    
    //trap = clamp(pow( trap*pow(2,zoom), 0.25 ), 0.0, 1.0); // control 1
    //trap = 1.0 / (1.0 + exp(-7.0 * (trap - 0.5)));  // control 2

	return z;
}

vec2 MandelbrotDistanceLoop(vec2 c, int maxIterations, inout int iter)
{
	vec2 z = vec2(0);
	for (iter = 0; iter < maxIterations && IsBounded(z); ++iter)
	{
		z = c_2(z) + c;
	}

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
            //return z.x*z.x + z.y*z.y < bailout*bailout;
            return z.x*z.x + z.y*z.y < 1024;
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

float GetOrbitTrap(vec2 z, inout float trap)
{
    switch (orbitTrap)
    {
        case TRAP_POINT:
            trap = min(trap, dot(z-bailoutPoint,z-bailoutPoint));
            //trap = min(trap, log(abs(dot(z-bailoutPoint,z-bailoutPoint))));
            break;
        case TRAP_LINE:
            //trap = min(trap, DistanceToLine(z, bailoutLine.xy, bailoutLine.zw));
            trap = min(trap, dot(z-bailoutPoint,z-bailoutPoint));
            bailoutLine;
            break;
        case TRAP_CROSS:
            trap = min(trap, dot(z-bailoutPoint,z-bailoutPoint));
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

bool NeedDistance()
{
    return orbitTrap == TRAP_LINE || orbitTrap == TRAP_CROSS;
}