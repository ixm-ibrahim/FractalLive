﻿#version 450 core

layout(location = 0) in vec3 aPos;
layout(location = 1) in vec2 aTexCoords;

out vec2 FragPos;
out vec2 TexCoords;

void main(void)
{
    gl_Position = vec4(aPos, 1.0);
    FragPos = aPos.xy;

	TexCoords = aTexCoords;
}