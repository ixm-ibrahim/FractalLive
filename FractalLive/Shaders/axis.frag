#version 450 core

out vec4 FragColor;

in vec3 color;

void main()
{
	FragColor = vec4(color, 0.5f);
}
