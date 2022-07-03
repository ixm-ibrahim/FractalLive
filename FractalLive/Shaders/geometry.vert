#version 450 core

layout(location = 0) in vec3 aPos;

out vec2 FragPos;

void main(void)
{
    gl_Position = vec4(aPos, 1.0);
    FragPos = aPos.xy;
}