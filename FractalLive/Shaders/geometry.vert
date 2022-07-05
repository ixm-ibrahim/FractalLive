#version 450 core

#define M_PI 3.1415926535897932384626433832795

layout(location = 0) in vec3 aPos;
layout(location = 1) in vec2 aTexCoords;

uniform mat4 model;
uniform mat4 projection;
uniform mat4 view;

uniform bool is3D;

uniform float zoom;
uniform float rollAngle;
uniform float aspectRatio;

uniform vec2 center;

out vec2 FragPos;
out vec2 TexCoords;

void main(void)
{
    zoom;rollAngle;aspectRatio;center;

    if (is3D)
    {
        gl_Position = projection * view * model * vec4(aPos, 1.0);
    }
    else
    {
        gl_Position = vec4(aPos, 1.0);
        FragPos = aPos.xy;

	    TexCoords = aTexCoords;
        
        float a = rollAngle * M_PI / 180;
	    float s = sin(a);
	    float c = cos(a);
	    vec2 newPos = vec2(aPos.x*c - aPos.y*s, aPos.y*c + aPos.x*s);

        FragPos = newPos;

        FragPos = vec2(aspectRatio,1)*aPos.xy/zoom;
	    FragPos = center + vec2(FragPos.x*c - FragPos.y*s, FragPos.y*c + FragPos.x*s);
    }
}