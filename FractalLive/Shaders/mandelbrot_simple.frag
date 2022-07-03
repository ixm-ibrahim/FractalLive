#version 450 core



out vec4 FragColor;

in vec2 FragPos;

vec3 Mandelbrot();
vec2 MandelbrotLoop(vec2 c, int maxIteration, inout int iter);

void main()
{
	FragColor = vec4(Mandelbrot(), 1.0);
}

vec2 c_2(vec2 c);

vec3 Mandelbrot()
{
	int iter = 0;
	vec2 z = MandelbrotLoop(FragPos*2, 100, iter);

	if (iter >= 100)
		return vec3(1.0);

	return vec3(0.0);
}

vec2 MandelbrotLoop(vec2 c, int maxIteration, inout int iter)
{
	vec2 z = vec2(0);
	for (iter = 0; iter < maxIteration && (z.x*z.x + z.y*z.y) < 4; ++iter)
	{
		z = c_2(z) + c;
	}

	return z;
}

vec2 c_2(vec2 c)
{
    return vec2(c.x*c.x - c.y*c.y, 2*c.x*c.y);
}