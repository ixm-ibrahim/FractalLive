#version 450 core

#define M_PI 3.1415926535897932384626433832795

layout(location = 0) in vec3 aPos;
layout(location = 1) in vec2 aTexCoords;
layout(location = 2) in vec3 aNorm;

uniform mat4 model;
uniform mat4 projection;
uniform mat4 view;

uniform bool is3D;

uniform float zoom;
uniform float rollAngle;

uniform vec2 center;

uniform float initialRadius;
uniform float normalizedCoordsWidth;
uniform float normalizedCoordsHeight;

out vec3 FragPosModel;
out vec3 FragPosWorld;
out vec3 FragNormal;
out vec2 TexCoords;

void main(void)
{
    if (is3D)
    {
        FragPosModel = aPos;
	    FragPosWorld = vec3(model * vec4(FragPosModel, 1.0));
        gl_Position = vec4(FragPosWorld, 1.0) * view * projection;
	    
	    TexCoords = aTexCoords;
        FragNormal = aNorm * mat3(transpose(inverse(model)));
    }
    else
    {
        gl_Position = vec4(aPos, 1.0);
        FragPosModel = aPos;

	    TexCoords = aTexCoords;
        
        float a = rollAngle * M_PI / 180;
	    float s = sin(a);
	    float c = cos(a);
	    vec2 newPos = vec2(aPos.x*c - aPos.y*s, aPos.y*c + aPos.x*s);
        
        FragPosModel = vec3(initialRadius*vec2(normalizedCoordsWidth,normalizedCoordsHeight)*aPos.xy/pow(2,zoom), 0);
	    FragPosModel = vec3(center + vec2(FragPosModel.x*c - FragPosModel.y*s, FragPosModel.y*c + FragPosModel.x*s), 0);
    }
}