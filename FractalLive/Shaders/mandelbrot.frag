#version 450 core

#define M_PI            3.141592653589793238462643383279
#define M_2PI           6.283185307179586476925286766559
#define M_PHI           1.618033988749894848204586834365
#define MAX_LENGTH      1e15

#define PROJ_CARTESIAN                  0
#define PROJ_RIEMANN_FLAT               1
#define PROJ_RIEMANN_SPHERE             2

#define FRAC_MANDELBROT					0
#define FRAC_LAMBDA						1
#define FRAC_CUSTOM						2

#define TRAP_CIRCLE						0
#define TRAP_SQUARE						1
#define TRAP_REAL						2
#define TRAP_IMAG						3
#define TRAP_RECTANGLE					4
#define TRAP_SPIRAL					    5
#define TRAP_POINTS						6
#define TRAP_LINES						7
#define TRAP_TEXTURE					8
#define TRAP_CUSTOM						9

#define COL_BLACK						0
#define COL_WHITE						1
#define COL_ITERATION                   2
#define COL_SMOOTH                      3
#define COL_STRIPES                     4
#define COL_STRIPES_DOMAIN              5
#define COL_DOMAIN_SIMPLE               6
#define COL_DOMAIN_NORMAL               7
#define COL_DOMAIN_BRIGHTNESS           8
#define COL_DOMAIN_BRIGHT_RINGS         9
#define COL_DOMAIN_BRIGHT_RINGS_SMOOTH  10
#define COL_DOMAIN_DARK_RINGS           11
#define COL_DOMAIN_BRIGHT_DARK_SMOOTH   12
#define COL_CUSTOM						13

#define CALC_MIN                        0
#define CALC_MAX                        1
#define CALC_AVG                        2
#define CALC_FIRST                      3
#define CALC_LAST                       4

out vec4 FragColor;

in vec3 FragPosModel;
in vec3 FragPosWorld;
in vec3 FragNormal;
in vec2 TexCoords;

uniform int proj;
uniform float normalizedCoordsWidth;
uniform float normalizedCoordsHeight;
uniform float time;
uniform float zoom;
uniform float lockedZoom;

uniform vec2 center;
uniform vec2 riemannAngles;

uniform int formula;
uniform int maxIterations;
uniform int minIterations;
uniform bool useConjugate;
uniform vec2 startPosition;
uniform vec2 power;
uniform vec2 c_power;
uniform float foldCount;
uniform float foldAngle;
uniform vec2 foldOffset;

uniform int orbitTrap;
uniform float bailout;
uniform vec2 bailoutRectangle;
uniform vec4 bailoutSpiral;
uniform vec2[16] bailoutPoints;
uniform int bailoutPointsCount;
uniform vec4[16] bailoutLines;
uniform int bailoutLinesCount;
uniform sampler2D bailoutTexture;
uniform int orbitTrapCalculation;
uniform bool useSecondValue;
uniform float startOrbitDistance;
uniform int startOrbit;
uniform int orbitRange;
uniform float bailoutFactor1;
uniform float bailoutFactor2;
uniform float secondValueFactor1;
uniform float secondValueFactor2;
uniform vec2 bailoutTextureScale;

uniform bool splitInteriorExterior;

uniform int coloring;
uniform bool useCustomPalette;
uniform vec4[6] customPalette;
uniform float colorCycles;
uniform float colorFactor;
uniform float orbitTrapFactor;
uniform float stripeDensity;
uniform int domainCalculation;
uniform bool matchOrbitTrap;
uniform bool useDomainSecondValue;
uniform float secondDomainValueFactor1;
uniform float secondDomainValueFactor2;
uniform bool useDomainIteration;
uniform bool useDistanceEstimation;
uniform float maxDistanceEstimation;
uniform float distanceEstimationFactor1;
uniform float distanceEstimationFactor2;
uniform bool useNormals;
uniform bool useTexture;
uniform sampler2D e_texture;
uniform float textureBlend;
uniform float textureScaleX;
uniform float textureScaleY;
uniform bool usePolarTextureCoordinates;
uniform bool useDistortedTexture;
uniform float textureDistortionFactor;

uniform int i_coloring;
uniform bool i_useCustomPalette;
uniform vec4[6] i_customPalette;
uniform float i_colorCycles;
uniform float i_colorFactor;
uniform float i_orbitTrapFactor;
uniform float i_stripeDensity;
uniform bool i_matchOrbitTrap;
uniform bool i_useDomainSecondValue;
uniform float i_secondDomainValueFactor1;
uniform float i_secondDomainValueFactor2;
uniform bool i_useDomainIteration;
uniform bool i_useTexture;
uniform sampler2D i_texture;
uniform float i_textureBlend;
uniform float i_textureScaleX;
uniform float i_textureScaleY;
uniform bool i_usePolarTextureCoordinates;
uniform bool i_useDistortedTexture;
uniform float i_textureDistortionFactor;

vec3 Mandelbrot();

void main()
{
	//FragColor = vec4(Mandelbrot() * vec3(TexCoords,1), 1.0);
	FragColor = vec4(Mandelbrot(), 1.0);FragPosWorld;
}

vec2 MandelbrotLoop(vec2 c, inout int iter, inout vec2 trap, out vec4 domainZ, out ivec2 domainIter, inout float distanceEstimation, inout vec4 stripesAddend, float riemannAdjustment);
vec2 ComputeFractal(vec2 z, vec2 c, bool withinMaxDistance, inout vec2 dz, inout vec2 dz2);
vec2 FoldZ(vec2 z);
vec3 GetColor(vec2 z, vec2 c, int iter, vec2 trap, vec4 domainZ, ivec2 domainIter, float distanceEstimation, vec4 stripes);
vec3 DomainColoring(int coloring, vec4 z, ivec2 iter, vec2 trap, vec4 stripes, bool escacped);
vec3 I_DomainColoring(int coloring, vec4 z, ivec2 iter, vec2 trap, vec4 stripes);
bool IsBounded(int iter, vec2 z);
bool IsWithinIteration(int iter);
vec2 GetOrbitTrap(vec2 z, int iter, inout vec2 trap, inout vec4 domainZ, inout ivec2 domainIter);
vec2 CalculateOrbitTrapDistance(vec2 trap, float newDist, int iter, vec2 newZ, bool matchOrbitTrap, inout vec4 domainZ, inout ivec2 domainIter);
vec4 CalculateDomainZ(vec4 domainZ, vec2 newZ, int iter, inout ivec2 domainIter);
float GetSmoothIter(float iter, vec2 z);
vec2 Fix(vec2 z);
vec3 HSVtoRGB(vec3 color);
vec3 RGBtoHSV(vec3 color);
vec3 Rainbow(float mu, float colorCycles);
vec3 ColorPalette(vec4[6] customPalette, float ratio);
float DistanceToPoint(vec2 z, vec2 p);
float DistanceToLine(vec2 z, vec2 a, vec2 b);
float DistanceToRectangle(vec2 z, float a, float b);
float DistanceToSpiral(vec2 z);
float sigmoid(float x, float factor);
vec3 sigmoid(vec3 v, float factor);
vec2 c_1();
vec2 c_i();
vec2 c_conj(vec2 c);
vec2 c_2(vec2 c);
vec2 c_mul(vec2 a, vec2 b);
vec2 c_div(vec2 a, vec2 b);
vec2 c_pow(vec2 c, float p);
vec2 c_pow(float c, vec2 p);
vec2 c_pow(vec2 c, vec2 p);
vec2 c_exp(vec2 c);
vec2 c_invert(vec2 c);
vec2 c_rotate(vec2 c, float a);
float c_squared_modulus(vec2 c);
float c_arg(vec2 c);
vec2 c_from_polar(float r, float theta);
vec2 c_to_polar(vec2 c);

vec3 Mandelbrot()
{
	int iter = 0;
    vec2 trap = vec2(startOrbitDistance);
	vec2 z;
	vec4 domainZ;
    ivec2 domainIter;
    float distanceEstimation;
    vec4 stripes = vec4(0);
    
    vec2 c = FragPosModel.xy;
    float riemannAdjustment = 1;
    
    if (proj == PROJ_RIEMANN_FLAT)
    {
        vec2 uv = TexCoords;
        //vec2 uv = TexCoords * normalize(vec2(normalizedCoordsWidth,normalizedCoordsHeight));
        uv = (1 - uv)*2 - 1;
        uv = vec2(uv.x * sqrt(1 - uv.y*uv.y/2), uv.y * sqrt(1 - uv.x*uv.x/2));
        
        float theta = atan(uv.y, uv.x) + M_PI;
        float phi = length(uv)*M_PI;

        vec3 spherePos;
        spherePos.x = cos(theta)*sin(phi);
        spherePos.y = sin(theta)*sin(phi);
        spherePos.z = -cos(phi);

        // https://stackoverflow.com/questions/9037174/glsl-rotation-with-a-rotation-vector
        vec4 q = vec4(vec3(1,0,0)*sin(riemannAngles.x/2), cos(riemannAngles.x/2));
        vec3 temp = cross(q.xyz, spherePos) + q.w * spherePos;
        vec3 rotatedX = spherePos + 2.0*cross(q.xyz, temp);
        
        q = vec4(vec3(0,1,0)*sin(riemannAngles.y/2), cos(riemannAngles.y/2));
        temp = cross(q.xyz, rotatedX) + q.w * rotatedX;
        vec3 rotatedY = rotatedX + 2.0*cross(q.xyz, temp);
        
        // Riemann projection
        vec3 pos = normalize(vec3(rotatedY.x, rotatedY.y, rotatedY.z));
        riemannAdjustment = (1 + (pos.z + 1)/(1 - pos.z)) / 2.0;
        float r = pos.x*riemannAdjustment / pow(2,zoom);

        float i = pos.y*riemannAdjustment / pow(2,zoom);
    
        c = vec2(r + center.x, i + center.y);
    }
    else if (proj == PROJ_RIEMANN_SPHERE)
    {
        vec3 pos = normalize(vec3(FragPosModel.x, FragPosModel.y, FragPosModel.z));
        riemannAdjustment = (1 + (pos.y + 1)/(1 - pos.y)) / 2.0 / pow(2,zoom);
        float r = pos.x*riemannAdjustment;
        float i = pos.z*riemannAdjustment;
    
        // Initialize image center
        c = vec2(r + center.x, i + center.y);
    }

    z = MandelbrotLoop(c, iter, trap, domainZ, domainIter, distanceEstimation, stripes, riemannAdjustment);
    
	return GetColor(z, c, iter, trap, domainZ, domainIter, distanceEstimation, stripes);
}

vec2 MandelbrotLoop(vec2 c, inout int iter, inout vec2 trap, out vec4 domainZ, out ivec2 domainIter, inout float distanceEstimation, inout vec4 stripesAddend, float riemannAdjustment)
{
	vec2 z = startPosition + ((formula == FRAC_LAMBDA) ? c_div(c_1(), power) : vec2(0));
    domainZ = vec4(c,c);
    trap = vec2(startOrbitDistance, 0);
    vec4 lastAdded = vec4(0);
    int stripesCount = 0;

    vec2 dz = vec2(1.0,0.0);
    vec2 dz2 = vec2(0.0,0.0);
    float m2 = dot(z,z);
    bool withinMaxDistance = true;
    
	for (iter = 0; iter < maxIterations; ++iter)
	{
        z = ComputeFractal(z, c, withinMaxDistance, dz, dz2);
        
        if (IsWithinIteration(iter))
        {
            stripesAddend.x += sin(stripeDensity * c_arg(z))/2 + 0.5;
            stripesAddend.y += sin((splitInteriorExterior ? i_stripeDensity : stripeDensity) * c_arg(z))/2 + 0.5;
            stripesAddend.z += sin(textureDistortionFactor * c_arg(z))/2 + 0.5;
            stripesAddend.w += sin((splitInteriorExterior ? i_textureDistortionFactor : textureDistortionFactor) * c_arg(z))/2 + 0.5;
            stripesCount++;
        
            if (!matchOrbitTrap)
                domainZ = CalculateDomainZ(domainZ, z, iter, domainIter);

            trap = GetOrbitTrap(z, iter, trap, domainZ, domainIter);
        }

        //if (orbitTrap == TRAP_TEXTURE && trap.y != 0)
            //break;
        
        if (withinMaxDistance)
        {
            m2 = dot(z,z);

            if (m2 > maxDistanceEstimation || (orbitTrap == TRAP_TEXTURE && trap.y != 0))
                withinMaxDistance = false;
        }
        
        if (!IsBounded(iter, z)) break;

        lastAdded = stripesAddend;
	}
    
    if (IsBounded(iter, z))
        stripesAddend /= stripesCount;
    else
        stripesAddend = mix(lastAdded/(stripesCount - 1), stripesAddend/stripesCount, fract(GetSmoothIter(iter, z)));
    
    if (useSecondValue)
    {
        if (trap.y > trap.x)
            trap.x /= trap.y;
        else
            trap.x = trap.y / trap.x;

        trap.x = pow(sigmoid(trap.x, secondValueFactor1), secondValueFactor2);
    }

    trap.x = sigmoid(pow( trap.x*pow(2,lockedZoom), bailoutFactor1 ), bailoutFactor2);
    
    if (useNormals)
    {
        vec2 v = vec2(sqrt(2)/2, sqrt(2)/2);
        vec2 u = c_div(z,dz);
        u = normalize(u);  // normal vector: (u.re,u.im,1) 
        float t = dot(u,v) + 1.0/distanceEstimationFactor1;  // dot product with the incoming light
        t = max(t/(1 + 1.0/distanceEstimationFactor1), 0);  // rescale so that t does not get bigger than 1
        distanceEstimation = sigmoid(t, distanceEstimationFactor2);
    }
    else
    {
        //float d = sqrt(m2 / dot(dz,dz)) * .5 * log(m2);
        float d = log(m2) * length(z) / length(dz);
        distanceEstimation = sqrt(sigmoid(d * pow(distanceEstimationFactor1, 2) * pow(2,lockedZoom) / riemannAdjustment, distanceEstimationFactor2));
    }

	return z;
}

vec2 ComputeFractal(vec2 z, vec2 c, bool withinMaxDistance, inout vec2 dz, inout vec2 dz2)
{
    if (withinMaxDistance || useNormals) 
        switch (formula)
        {
            case FRAC_MANDELBROT:
                dz2 = c_mul(power, (dz2*z + c_pow(dz,power)));
                dz = c_mul(power, c_mul(z,dz)) + c_power;
                break;
            case FRAC_LAMBDA:   // c^cp * (z - z^p)
                dz = c_mul(c_power, dz - power * c_mul(z,dz));
                break;
            case FRAC_CUSTOM:
            default:
                break;
        }

    vec2 new_z;

    if (useConjugate)
        z.y = -z.y;

    z = FoldZ(z);

    switch (formula)
    {
        case FRAC_MANDELBROT:
            new_z = c_pow(z, power) + c_pow(c, c_power);
            break;
        case FRAC_LAMBDA:
            //z = c_pow(z, power);
            //new_z = c_mul(c_pow(c, c_power), c_mul(z, vec2(1,0) - z));
            new_z = c_mul(c_pow(c, c_power), z - c_pow(z, power));
            break;
        case FRAC_CUSTOM:
        default:
            
            new_z = c_pow(z, z) + c_pow(c, c);
            //new_z = c_pow(z, power) - z - 1 + c_pow(c, c_power);
            break;
    }

    return Fix(new_z);
}

vec2 FoldZ(vec2 z)
{
    if (foldCount == 0)
        return z;
    
    // 1
    /*
    new_z = RotateZ(new_z, foldAngle);
    new_z.y = abs(new_z.y);
    new_z = RotateZ(new_z, -foldAngle);
    */
    
    // 2
    /*
    new_z = RotateZ(new_z, foldAngle);

    new_z.y = abs(new_z.y);
    new_z = RotateZ(new_z, -M_PI / 2);
    new_z.y = abs(new_z.y);
    new_z = RotateZ(new_z, M_PI / 2);

    new_z = RotateZ(new_z, -foldAngle);
    */
    
    // 3
    /*
    new_z = RotateZ(new_z, foldAngle);

    new_z.y = abs(new_z.y);
    new_z = RotateZ(new_z, -M_PI / 3);
    new_z.y = abs(new_z.y);
    new_z = RotateZ(new_z, -M_PI / 3);
    new_z.y = abs(new_z.y);
    new_z = RotateZ(new_z, 2*M_PI / 3);

    new_z = RotateZ(new_z, -foldAngle);
    */
    
    // N
    // Rotate
    z = c_rotate(z, foldAngle); // radians
    // Translate
    z += foldOffset;
   
    // Burning Ships
    float absCount = abs(foldCount);
    float m = mod(foldCount, 2);
    bool even = m > 0 && m <= 1;
    float count = even ? absCount - 1 : absCount;
   
    if (foldCount < 1)
    {
        z.y = mix(z.y, abs(z.y), foldCount);

        z = c_rotate(z, M_PI * foldCount);
    }
   
    if (even && absCount >= 1)
        z.y = abs(z.y);

    for (int i = 0; i < count; i++)
    {
        z = c_rotate(z, M_PI / foldCount);
        z.y = abs(z.y);
    }

    // Untranslate
    z -= foldOffset;
    // Unrotate
    z = c_rotate(z, -foldAngle);

    return z;
}

vec3 GetColor(vec2 z, vec2 c, int iter, vec2 trap, vec4 domainZ, ivec2 domainIter, float distanceEstimation, vec4 stripes)
{
    // Decide the color based on the number of iterations
    vec3 color;
    if (iter >= maxIterations)
    {
        int c = splitInteriorExterior ? i_coloring : coloring;
        vec3 domColor = splitInteriorExterior ? I_DomainColoring(i_coloring, domainZ, domainIter, trap, stripes) : DomainColoring(coloring, domainZ, domainIter, trap, stripes, iter < maxIterations);
        
        switch (c)
        {
            case COL_CUSTOM:
                vec3 outerColor1 = vec3(0.13f, 0.94f, 0.13f);
                vec3 outerColor2 = vec3(0.0f, 0.47f, 0.95f);
            
                float theta = sin(c_arg(z) + time)*.5 + .5;

                color = mix(outerColor1, outerColor2, theta);

                color = mix(Rainbow(orbitTrapFactor*trap.x, colorCycles), color, trap.x);

                break;
            case COL_BLACK:
                color = vec3(0);
                
                color = mix(1-vec3(pow(trap.x,orbitTrapFactor)), color, trap.x);

                break;
            case COL_WHITE:
                color = vec3(1);
                
                color = mix(vec3(pow(trap.x,orbitTrapFactor)), color, trap.x);

                break;
            case COL_STRIPES:
                color = stripes.y * domColor;
                break;
            case COL_ITERATION:
            case COL_SMOOTH:
                float mu = (atan(z.y,z.x)+M_PI/2)/M_2PI;
                
                if (splitInteriorExterior)
                    color = i_useCustomPalette ? ColorPalette(i_customPalette, mu) : Rainbow(mu*50, colorCycles);
                else
                    color = useCustomPalette ? ColorPalette(customPalette, mu) : Rainbow(mu*50, colorCycles);
                
                color = mix(Rainbow(orbitTrapFactor*trap.x, colorCycles), color, trap.x);

                break;
            default:
                color = domColor;
                break;
        }
    }
    else
    {
        //int c = splitInteriorExterior ? exteriorColoring : coloring;
        vec3 iterColor = useCustomPalette ? ColorPalette(customPalette, iter/31) : Rainbow(iter, colorCycles);
        vec3 orbitColor = useCustomPalette ? ColorPalette(customPalette, orbitTrapFactor*trap.x/31) : Rainbow(orbitTrapFactor*trap.x, colorCycles);
        vec3 muColor = useCustomPalette ? ColorPalette(customPalette, GetSmoothIter(iter, z)/31) : Rainbow(GetSmoothIter(iter, z), colorCycles);
        
        switch (coloring)
        {
            case COL_CUSTOM:
            {
                vec3 outerColor1 = vec3(0.13f, 0.94f, 0.13f);
                vec3 outerColor2 = vec3(0.0f, 0.47f, 0.95f);
            
                //float theta = sin(atan(float(z.y), float(z.x)) + time)*.5 + .5;

                //color = mix(outerColor1, outerColor2, theta);
                //color = mix(outerColor1, outerColor2, dist);
                color = mix(outerColor1, outerColor2, fract(GetSmoothIter(iter, z)));
                
                color = mix(Rainbow(orbitTrapFactor*trap.x, colorCycles), color, trap.x);

                break;
            }
            case COL_BLACK:
            {
                color = vec3(0);
                
                color = mix(1-vec3(pow(trap.x,orbitTrapFactor)), color, trap.x);

                break;
            }
            case COL_WHITE:
            {
                color = vec3(1);
                
                color = mix(vec3(pow(trap.x,orbitTrapFactor)), color, trap.x);

                break;
            }
            case COL_ITERATION:
            {
                color = mix(orbitColor, iterColor, trap.x);
                break;
            }
            case COL_SMOOTH:
            {
                color = mix(orbitColor, muColor, trap.x);
                break;
            }
            case COL_STRIPES:
            {
                //color = vec3(stripes);
                //color = useCustomPalette ? ColorPalette(customPalette, stripes*colorFactor) : Rainbow(stripes, 1*colorFactor);
                color = muColor * sigmoid(stripes.x, colorFactor);
                color = mix(orbitColor, color, trap.x);
                break;
            }
            default:
            {
                color = DomainColoring(coloring, domainZ, domainIter, trap, stripes, iter < maxIterations);
                break;
            }
        }
    }
    
    if (splitInteriorExterior && iter >= maxIterations)
        color = sigmoid(color, i_colorFactor);
    else
        color = sigmoid(color, colorFactor);
    
    if (useDistanceEstimation && iter < maxIterations)
        //color = pow( vec3(dist), vec3(0.9,1.1,1.4) );
        if (coloring == COL_BLACK)
            color += 1-distanceEstimation;
        else
            color *= distanceEstimation;

    if (splitInteriorExterior && iter >= maxIterations && i_useTexture)
    {
        //vec2 tex = vec2(pow(atan(FragPosModel.y, FragPosModel.x),2), GetSmoothIter(iter, z));
        //vec2 tex = vec2(stripes.y, GetSmoothIter(iter, z));   //@pass c here
        vec2 tex;
        
        if (i_useDistortedTexture)
            tex = vec2(pow(stripes.w,1), (1-fract(GetSmoothIter(iter, z))));
        else
            //tex = vec2(atan(FragPosModel.y, FragPosModel.x), GetSmoothIter(iter, z));
            //tex = vec2(atan(c.y, c.x), GetSmoothIter(iter, z));
            tex = vec2(atan(c.y, c.x), sin(length(z))*.5+.5);
            
        if (i_usePolarTextureCoordinates)
        {
            tex *= vec2(M_2PI * i_textureScaleX, i_textureScaleY);
            tex = 0.5*vec2(tex.y*cos(tex.x), tex.y*sin(tex.x)) + 0.5;
        }
        else
            tex *= vec2(i_textureScaleX, i_textureScaleY);

        color = mix(color, texture(i_texture, tex).xyz, i_textureBlend);
    }
    else if (useTexture)
    {
        //vec2 tex = TexCoords;
        //vec2 tex = z;
        //vec2 tex = vec2(atan(z.y, z.x), 1-fract(GetSmoothIter(iter, z)));
        //vec2 tex = vec2(pow(stripes.x, colorFactor), 1-fract(GetSmoothIter(iter, z)));
        vec2 tex;
        
        if (useDistortedTexture)
            tex = vec2(pow(stripes.z,1), 1-fract(GetSmoothIter(iter, z)));
        else
            tex = vec2((atan(z.y,z.x)+M_PI)/M_2PI, 1-fract(GetSmoothIter(iter, z)));
            
        if (usePolarTextureCoordinates)
        {
            tex *= vec2(M_2PI * textureScaleX, textureScaleY);
            tex = 0.5*vec2(tex.y*cos(tex.x), tex.y*sin(tex.x)) + 0.5;
        }
        else
            tex *= vec2(textureScaleX, textureScaleY);

        color = mix(color, texture(e_texture, tex).xyz, textureBlend);
    }
    
    return color;
}

vec3 DomainColoring(int coloring, vec4 z, ivec2 iter, vec2 trap, vec4 stripes, bool escaped)
{
    //float t = (time + trap) * 20;
    float t = time * 20;
    
    vec3 color;

    float theta = (c_arg(z.xy) + M_PI) / M_2PI;
	//float r = sigmoid(length(z.xy), orbitTrapFactor);
	float r = length(z.xy);

    if (useDomainSecondValue && orbitTrap != TRAP_TEXTURE)
    {
        float r2 = length(z.zw);
        
        if (matchOrbitTrap)
        {
            vec4 dummyDomainZ;
            ivec2 dummyDomainIter;
            vec2 trap;
            switch (orbitTrap)
            {
                case TRAP_CIRCLE:
                    r = length(z.xy);
                    r2 = length(z.zw);

                    break;
                case TRAP_SQUARE:
                    r = DistanceToRectangle(z.xy, bailout, bailout);
                    r2 = DistanceToRectangle(z.zw, bailout, bailout);

                    break;
                case TRAP_REAL:
                    r = DistanceToLine(z.xy, vec2(0,0), vec2(0,1));
                    r2 = DistanceToLine(z.zw, vec2(0,0), vec2(0,1));

                    break;
                case TRAP_IMAG:
                    r = DistanceToLine(z.xy, vec2(0,0), vec2(1,0));
                    r2 = DistanceToLine(z.zw, vec2(0,0), vec2(1,0));

                    break;
                case TRAP_RECTANGLE:
                    r = DistanceToRectangle(z.xy, bailoutRectangle.x, bailoutRectangle.y);
                    r2 = DistanceToRectangle(z.zw, bailoutRectangle.x, bailoutRectangle.y);

                    break;
                case TRAP_SPIRAL:
                    r = DistanceToSpiral(z.xy);
                    r2 = DistanceToSpiral(z.zw);

                    break;
                case TRAP_POINTS:
                    trap.x = DistanceToPoint(z.xy, bailoutPoints[0]);
                    for (int i = 1; i < bailoutPointsCount; i++)
                        trap = CalculateOrbitTrapDistance(trap, DistanceToPoint(z.xy, bailoutPoints[i]), iter.x, z.xy, matchOrbitTrap, dummyDomainZ, dummyDomainIter);
                    r = trap.x;

                    trap.x = DistanceToPoint(z.zw, bailoutPoints[0]);
                    for (int i = 1; i < bailoutPointsCount; i++)
                        trap = CalculateOrbitTrapDistance(trap, DistanceToPoint(z.zw, bailoutPoints[i]), iter.x, z.zw, matchOrbitTrap, dummyDomainZ, dummyDomainIter); 
                    r2 = trap.x;

                    break;
                case TRAP_LINES:
                    trap.x = DistanceToLine(z.xy, bailoutLines[0].xy, bailoutLines[0].zw);
                    for (int i = 1; i < bailoutLinesCount; i++)
                        trap = CalculateOrbitTrapDistance(trap, DistanceToLine(z.xy, bailoutLines[i].xy, bailoutLines[i].zw), iter.x, z.xy, matchOrbitTrap, dummyDomainZ, dummyDomainIter);
                    r = trap.x;

                    trap.x = DistanceToLine(z.zw, bailoutLines[0].xy, bailoutLines[0].zw);
                    for (int i = 1; i < bailoutLinesCount; i++)
                        trap = CalculateOrbitTrapDistance(trap, DistanceToLine(z.zw, bailoutLines[i].xy, bailoutLines[i].zw), iter.x, z.zw, matchOrbitTrap, dummyDomainZ, dummyDomainIter); 
                    r2 = trap.x;

                    break;
                case TRAP_CUSTOM:
                default:
                    break;
            }
        }

        if (r2 > r)
            r /= r2;
        else
            r = r2 / r;

        r = pow(r, secondDomainValueFactor1) * sigmoid(r, secondDomainValueFactor2);

        theta *= r;
    }
    

    theta = theta * 360 * (useCustomPalette ? 1 : colorCycles) + (useCustomPalette ? 0 : t);
    
    if (useCustomPalette)
        theta = RGBtoHSV(ColorPalette(customPalette, mod(theta, 360)/360)).x;

	if (z.x == 0 && z.y == 0)
	{
		theta = 0;
		r = 0;
	}
	else if (isnan(z.x) || isnan(z.y))
	{
		z = vec4(0);
		theta = 0;
		r = 0;
	}

    float s = abs(sin(mod(r * M_2PI, M_2PI)));
	float b = sqrt(sqrt(abs(sin(mod(z.y * M_2PI, M_2PI)) * sin(mod(z.x * M_2PI, M_2PI)))));
	float b2 = .5 * ((1 - s) + b + sqrt(pow(1 - s - b, 2) + 0.01));

    switch (coloring)
    {
        case COL_STRIPES_DOMAIN:
        {
            //color = vec3(stripes);
            //color = HSVtoRGB(vec3(sigmoid(stripes.x, colorFactor)*360*colorCycles + t, 1, 1));
            float strp = sigmoid(stripes.x, colorFactor)*360*colorCycles;
            vec3 hsv =  RGBtoHSV(ColorPalette(customPalette, mod(strp + t, 360)/360));
            float th = useCustomPalette ? hsv.x : strp + t;
            
            if (escaped)
                color = HSVtoRGB(vec3(th, hsv.y, hsv.z));
            else
                color = HSVtoRGB(vec3(th + theta, hsv.y, hsv.z));

            break;
        }
        case COL_DOMAIN_NORMAL:
            color = HSVtoRGB(vec3(theta, s, b2 > 1 ? 1 : b2));
            break;
        case COL_DOMAIN_BRIGHTNESS:
            color = HSVtoRGB(vec3(theta, 1, b2 > 1 ? 1 : b2));
            break;
        case COL_DOMAIN_BRIGHT_RINGS:
            color = HSVtoRGB(vec3(theta, s, 1));
            break;
        case COL_DOMAIN_BRIGHT_RINGS_SMOOTH:
            color = HSVtoRGB(vec3(theta, mod(r,1), 1));
            break;
        case COL_DOMAIN_DARK_RINGS:
            color = HSVtoRGB(vec3(theta, 1, s));
            break;
        case COL_DOMAIN_BRIGHT_DARK_SMOOTH:
            color = HSVtoRGB(vec3(theta, 1, mod(r,1)));
            break;
        default:
            //color = mix(outerColor1, outerColor2, theta);
            //float test = log(length(c_invert(z)));
            color = HSVtoRGB(vec3(theta, 1, 1));
            break;
    }

    if (useDomainIteration)
    {
        vec3 c = useCustomPalette ? ColorPalette(customPalette, iter.x*1.05) : Rainbow(iter.x, colorCycles);

        color *= c;
        //color = mix(color, Rainbow(iter.x), float(iter.x)/maxIterations);
        
        if (useDomainSecondValue)
            color = mix(c, vec3(r), r);
        else
            color = c;
    }

    color = mix(color, color*sigmoid(trap.x,orbitTrapFactor), trap.x);
    //color = mix(color, vec3(0), trap);

    return color;
}

vec3 I_DomainColoring(int coloring, vec4 z, ivec2 iter, vec2 trap, vec4 stripes)
{
    //float t = (time + trap) * 20;
    float t = time * 20;
    
    vec3 color;

    float theta = (atan(z.y, z.x) + M_PI) / M_2PI;
	float r = length(z.xy);

    if (i_useDomainSecondValue && orbitTrap != TRAP_TEXTURE)
    {
        float r2 = length(z.zw);
        
        if (i_matchOrbitTrap)
        {
            vec4 dummyDomainZ;
            ivec2 dummyDomainIter;
            vec2 trap;
            switch (orbitTrap)
            {
                case TRAP_CIRCLE:
                    r = length(z.xy);
                    r2 = length(z.zw);

                    break;
                case TRAP_SQUARE:
                    r = DistanceToRectangle(z.xy, bailout, bailout);
                    r2 = DistanceToRectangle(z.zw, bailout, bailout);

                    break;
                case TRAP_REAL:
                    r = DistanceToLine(z.xy, vec2(0,0), vec2(0,1));
                    r2 = DistanceToLine(z.zw, vec2(0,0), vec2(0,1));

                    break;
                case TRAP_IMAG:
                    r = DistanceToLine(z.xy, vec2(0,0), vec2(1,0));
                    r2 = DistanceToLine(z.zw, vec2(0,0), vec2(1,0));

                    break;
                case TRAP_RECTANGLE:
                    r = DistanceToRectangle(z.xy, bailoutRectangle.x, bailoutRectangle.y);
                    r2 = DistanceToRectangle(z.zw, bailoutRectangle.x, bailoutRectangle.y);

                    break;
                case TRAP_SPIRAL:
                    r = DistanceToSpiral(z.xy);
                    r2 = DistanceToSpiral(z.zw);

                    break;
                case TRAP_POINTS:
                    trap.x = DistanceToPoint(z.xy, bailoutPoints[0]);
                    for (int i = 1; i < bailoutPointsCount; i++)
                        trap = CalculateOrbitTrapDistance(trap, DistanceToPoint(z.xy, bailoutPoints[i]), iter.x, z.xy, i_matchOrbitTrap, dummyDomainZ, dummyDomainIter);
                    r = trap.x;

                    trap.x = DistanceToPoint(z.zw, bailoutPoints[0]);
                    for (int i = 1; i < bailoutPointsCount; i++)
                        trap = CalculateOrbitTrapDistance(trap, DistanceToPoint(z.zw, bailoutPoints[i]), iter.x, z.zw, i_matchOrbitTrap, dummyDomainZ, dummyDomainIter); 
                    r2 = trap.x;

                    break;
                case TRAP_LINES:
                    trap.x = DistanceToLine(z.xy, bailoutLines[0].xy, bailoutLines[0].zw);
                    for (int i = 1; i < bailoutLinesCount; i++)
                        trap = CalculateOrbitTrapDistance(trap, DistanceToLine(z.xy, bailoutLines[i].xy, bailoutLines[i].zw), iter.x, z.xy, i_matchOrbitTrap, dummyDomainZ, dummyDomainIter);
                    r = trap.x;

                    trap.x = DistanceToLine(z.zw, bailoutLines[0].xy, bailoutLines[0].zw);
                    for (int i = 1; i < bailoutLinesCount; i++)
                        trap = CalculateOrbitTrapDistance(trap, DistanceToLine(z.zw, bailoutLines[i].xy, bailoutLines[i].zw), iter.x, z.zw, i_matchOrbitTrap, dummyDomainZ, dummyDomainIter); 
                    r2 = trap.x;

                    break;
                case TRAP_CUSTOM:
                default:
                    break;
            }
        }

        if (r2 > r)
            r /= r2;
        else
            r = r2 / r;

        r = pow(r, i_secondDomainValueFactor1) * sigmoid(r, i_secondDomainValueFactor2);

        theta *= r;
    }
    

    theta = theta * 360 * (i_useCustomPalette ? 1 : i_colorCycles) + (i_useCustomPalette ? 0 : t);
    
    if (useCustomPalette)
        theta = RGBtoHSV(ColorPalette(i_customPalette, mod(theta, 360)/360)).x;

	if (z.x == 0 && z.y == 0)
	{
		theta = 0;
		r = 0;
	}
	else if (isnan(z.x) || isnan(z.y))
	{
		z = vec4(0);
		theta = 0;
		r = 0;
	}

    float s = abs(sin(mod(r * M_2PI, M_2PI)));
	float b = sqrt(sqrt(abs(sin(mod(z.y * M_2PI, M_2PI)) * sin(mod(z.x * M_2PI, M_2PI)))));
	float b2 = .5 * ((1 - s) + b + sqrt(pow(1 - s - b, 2) + 0.01));


    switch (i_coloring)
    {
        case COL_STRIPES_DOMAIN:
        {
            //color = vec3(stripes);
            //color = HSVtoRGB(vec3(sigmoid(stripes.x, colorFactor)*360*colorCycles + t, 1, 1));
            float strp = sigmoid(stripes.x, colorFactor)*360*colorCycles;
            vec3 hsv = RGBtoHSV(ColorPalette(customPalette, mod(strp + t, 360)/360));
            float th = useCustomPalette ? hsv.x : strp + t;
            color = HSVtoRGB(vec3(th + theta, hsv.y, hsv.z));
            break;
        }
        case COL_DOMAIN_NORMAL:
            color = HSVtoRGB(vec3(theta, s, b2 > 1 ? 1 : b2));
            break;
        case COL_DOMAIN_BRIGHTNESS:
            color = HSVtoRGB(vec3(theta, 1, b2 > 1 ? 1 : b2));
            break;
        case COL_DOMAIN_BRIGHT_RINGS:
            color = HSVtoRGB(vec3(theta, s, 1));
            break;
        case COL_DOMAIN_BRIGHT_RINGS_SMOOTH:
            color = HSVtoRGB(vec3(theta, mod(r,1), 1));
            break;
        case COL_DOMAIN_DARK_RINGS:
            color = HSVtoRGB(vec3(theta, 1, s));
            break;
        case COL_DOMAIN_BRIGHT_DARK_SMOOTH:
            color = HSVtoRGB(vec3(theta, 1, mod(r,1)));
            break;
        default:
            //color = mix(outerColor1, outerColor2, theta);
            //float test = log(length(c_invert(z)));
            color = HSVtoRGB(vec3(theta, 1, 1));
            break;
    }

    if (i_useDomainIteration)
    {
        vec3 c = i_useCustomPalette ? ColorPalette(i_customPalette, iter.x*1.05) : Rainbow(iter.x, i_colorCycles);

        color *= c;
        //color = mix(color, Rainbow(iter.x), float(iter.x)/maxIterations);
        
        if (i_useDomainSecondValue)
            color = mix(c, vec3(r), r);
        else
            color = c;
    }

    if (i_coloring <= COL_SMOOTH)
        color = mix(Rainbow(i_orbitTrapFactor*trap.x, i_colorCycles), color, trap.x);
    else
        color = mix(color, color*sigmoid(trap.x,i_orbitTrapFactor), trap.x);
        //color = mix(color, vec3(0), trap);

    return color;
}

bool IsBounded(int iter, vec2 z)
{
    if (!IsWithinIteration(iter))
        return true;

    switch (orbitTrap)
    {
        case TRAP_CUSTOM:
            return sin(z.y) < sin(bailout);
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

bool IsWithinIteration(int iter)
{
    return iter+1 >= startOrbit && iter+1 <= startOrbit + orbitRange - 1 && iter > minIterations;
}

vec2 GetOrbitTrap(vec2 z, int iter, inout vec2 trap, inout vec4 domainZ, inout ivec2 domainIter)
{
    if (IsWithinIteration(iter))
        switch (orbitTrap)
        {
            case TRAP_TEXTURE:
            case TRAP_CIRCLE:
                trap = CalculateOrbitTrapDistance(trap, length(z), iter, z, (splitInteriorExterior ? i_matchOrbitTrap : matchOrbitTrap), domainZ, domainIter);
                break;
            case TRAP_SQUARE:
                trap = CalculateOrbitTrapDistance(trap, DistanceToRectangle(z, bailout, bailout), iter, z, (splitInteriorExterior ? i_matchOrbitTrap : matchOrbitTrap), domainZ, domainIter);
                break;
            case TRAP_REAL:
                trap = CalculateOrbitTrapDistance(trap, DistanceToLine(z, vec2(0,0), vec2(0,1)), iter, z, (splitInteriorExterior ? i_matchOrbitTrap : matchOrbitTrap), domainZ, domainIter);
                break;
            case TRAP_IMAG:
                trap = CalculateOrbitTrapDistance(trap, DistanceToLine(z, vec2(0,0), vec2(1,0)), iter, z, (splitInteriorExterior ? i_matchOrbitTrap : matchOrbitTrap), domainZ, domainIter);
                break;
            case TRAP_RECTANGLE:
                trap = CalculateOrbitTrapDistance(trap, DistanceToRectangle(z, bailoutRectangle.x, bailoutRectangle.y), iter, z, (splitInteriorExterior ? i_matchOrbitTrap : matchOrbitTrap), domainZ, domainIter);
                break;
            case TRAP_SPIRAL:
                trap = CalculateOrbitTrapDistance(trap, DistanceToSpiral(z), iter, z, (splitInteriorExterior ? i_matchOrbitTrap : matchOrbitTrap), domainZ, domainIter);
                break;
            case TRAP_POINTS:
                for (int i = 0; i < bailoutPointsCount; i++)
                    trap = CalculateOrbitTrapDistance(trap, DistanceToPoint(z, bailoutPoints[i]), iter, z, (splitInteriorExterior ? i_matchOrbitTrap : matchOrbitTrap), domainZ, domainIter); 
                break;
            case TRAP_LINES:
                for (int i = 0; i < bailoutLinesCount; i++)
                    trap = CalculateOrbitTrapDistance(trap, DistanceToLine(z, bailoutLines[i].xy, bailoutLines[i].zw), iter, z, (splitInteriorExterior ? i_matchOrbitTrap : matchOrbitTrap), domainZ, domainIter);
                break;
            case TRAP_CUSTOM:
            default:
                trap.x = 0;
        }

    return trap;
}

vec2 CalculateOrbitTrapDistance(vec2 trap, float newDist, int iter, vec2 newZ, bool matchOrbitTrap, inout vec4 domainZ, inout ivec2 domainIter)
{
    if (!IsWithinIteration(iter))
        return trap;

    if (orbitTrap == TRAP_TEXTURE && trap.y == 0)
    {
        newZ *= bailoutTextureScale;
        if (abs(newZ.x) >= 0 && abs(newZ.x) <= 1 && abs(newZ.y) >= 0 && abs(newZ.y) <= 1 && texture(bailoutTexture, newZ).x < .9)
        //if (abs(newZ.x) >= 0 && abs(newZ.x) <= 1 && abs(newZ.y) >= 0 && abs(newZ.y) <= 1)
        //if (texture(bailoutTexture, newZ*2).xyz != vec3(1))
        //if (texture(bailoutTexture, newZ/4).x < 0.5)
        //if (!(newZ.x >= 0 && newZ.x <= 1 && newZ.y >= 0 && newZ.y <= 1 && texture(bailoutTexture, newZ).xyz != vec3(1)))
        {
            domainZ = texture(bailoutTexture, newZ*2);
            trap.y = 1;
        }

        return trap;
    }
    
    if (matchOrbitTrap)
    {
        switch (orbitTrapCalculation)
        {
            case CALC_MIN:
                if (newDist < trap.x)
                {
                    domainIter.x = iter;
                    domainZ = vec4(newZ,domainZ.xy);

                    return vec2(newDist, trap.x);
                }
                else if (newDist < trap.y)
                {
                    domainIter.y = iter;
                    domainZ = vec4(domainZ.xy,newZ);

                    return vec2(trap.x, newDist);
                }

                return trap;
            case CALC_MAX:
                if (newDist > trap.x)
                {
                    domainIter.x = iter;
                    domainZ = vec4(newZ,domainZ.xy);

                    return vec2(newDist, trap.x);
                }
                else if (newDist > trap.y)
                {
                    domainIter.y = iter;
                    domainZ = vec4(domainZ.xy,newZ);
                    
                    return vec2(trap.x, newDist);
                }

                return trap;
            case CALC_AVG:
                domainIter.x = iter;
                domainIter.x = iter-1;
                domainZ = vec4((domainZ.xy + newZ) / 2, domainZ.xy);

                return vec2((trap.x + newDist) / 2, trap.x);
            case CALC_FIRST:
                int start = (minIterations > startOrbit) ? minIterations : startOrbit;

                // first
                if (iter+1 == start)
                {
                    domainIter.x = iter;
                    domainZ = vec4(newZ,domainZ.xy);
                    
                    return vec2(newDist, trap.x);
                }
                // second
                if (iter+1 == start+1)
                {
                    domainIter.y = iter;
                    domainZ = vec4(domainZ.xy,newZ);
                    
                    vec2(trap.x, newDist);
                }

                return trap;
            case CALC_LAST:
                domainIter.x = iter;
                domainIter.y = iter-1;
                domainZ = vec4(newZ, domainZ.xy);

                return vec2(newDist, trap.x);
            default:
                return vec2(0);
        }
    }
    else
    {
        switch (orbitTrapCalculation)
        {
            case CALC_MIN:
                if (newDist < trap.x)
                    return vec2(newDist, trap.x);
                else if (newDist < trap.y)
                    return vec2(trap.x, newDist);

                return trap;
            case CALC_MAX:
                if (newDist > trap.x)
                    return vec2(newDist, trap.x);

                return trap;
            case CALC_AVG:
                return vec2((trap.x + newDist) / 2, trap.x);
            case CALC_FIRST:
                int start = (minIterations > startOrbit) ? minIterations : startOrbit;

                // first
                if (iter+1 == start)
                    return vec2(newDist, trap.x);
                // second
                if (iter+1 == start+1)
                    vec2(trap.x, newDist);

                return trap;
            case CALC_LAST:
                return vec2(newDist, trap.x);
            default:
                return vec2(0);
        }
    }
}

vec4 CalculateDomainZ(vec4 domainZ, vec2 newZ, int iter, inout ivec2 domainIter)
{
    if (!IsWithinIteration(iter))
        return domainZ;
        
    float ldz = length(domainZ.xy);
    float ldz2 = length(domainZ.zw);
    float lz = length(newZ);

    switch (domainCalculation)
    {
        case CALC_MIN:
            if (lz < ldz)
            {
                domainIter.x = iter;
                return vec4(newZ,domainZ.xy);
            }
            else if (lz < ldz2)
            {
                domainIter.y = iter;
                return vec4(domainZ.xy,newZ);
            }
            return domainZ;
        case CALC_MAX:
            if (lz > ldz)
            {
                domainIter.x = iter;
                return vec4(newZ,domainZ.xy);
            }
            else if (lz > ldz2)
            {
                domainIter.y = iter;
                return vec4(domainZ.xy,newZ);
            }
            return domainZ;
        case CALC_AVG:
            domainIter.x = iter;
            domainIter.x = iter-1;
            return vec4((domainZ.xy + newZ) / 2, domainZ.xy);
        case CALC_FIRST:
            int start = (minIterations > startOrbit) ? minIterations : startOrbit;

            // first
            if (iter+1 == start)
            {
                domainIter.x = iter;
                return vec4(newZ,domainZ.xy);
            }
            // second
            if (iter+1 == start+1)
            {
                domainIter.y = iter;
                return vec4(domainZ.xy,newZ);
            }

            return domainZ;
         case CALC_LAST:
            domainIter.x = iter;
            domainIter.y = iter-1;
            return vec4(newZ, domainZ.xy);
        default:
            return domainZ;
    }
}

float GetSmoothIter(float iter, vec2 z)
{
    //mu = iter;
    //return iter + 1 - (log2(log2(length(z))));
    //return iter + 1 + log(log(bailout)/log(dot(z,z))) / (sign(power)*log(abs(power) == 1 ? 1.0000001 : abs(power)));
    //return iter + 1 + log2(log(bailout)/log(dot(z,z)));
    //return iter - log(log(length(z))/log(bailout)) / log(power);
    return iter - log(log(length(z))/log(bailout)) / (sign(power.x)*log(abs(power.x) == 1 ? 1.0000001 : abs(power.x)));
}

vec2 Fix(vec2 z)
{
//    if (isnan(z.x))
//        z.x = 0;
//    if (isnan(z.y))
//        z.y = 0;
//    if (length(z) > MAX_LENGTH)
//        z = MAX_LENGTH * normalize(z);

    return z;
}

vec3 RGBtoHSV(vec3 color)
{
    vec4 K = vec4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
    vec4 p = mix(vec4(color.bg, K.wz), vec4(color.gb, K.xy), step(color.b, color.g));
    vec4 q = mix(vec4(p.xyw, color.r), vec4(color.r, p.yzx), step(p.x, color.r));

    float d = q.x - min(q.w, q.y);
    float e = 1.0e-10;
    return vec3(abs(q.z + (q.w - q.y) / (6.0 * d + e)) * 360, d / (q.x + e), q.x);
}

vec3 HSVtoRGB(vec3 color)
{/*
    */
    float hi = mod(floor(color.x / 60.0), 6);
    float f = color.x / 60.0 - floor(color.x / 60.0);

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
    
    vec4 K = vec4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
    vec3 pp = abs(fract(color.xxx + K.xyz) * 6.0 - K.www);
    return color.z * mix(K.xxx, clamp(pp - K.xxx, 0.0, 1.0), color.y) * 360;
}

vec3 Rainbow(float mu, float colorCycles)
{
    return vec3(sin(colorCycles * 7 * (mu + time) / 17) * .5 + .5, sin(colorCycles * 11 * (mu + time) / 29) * .5 + .5, sin(colorCycles * 13 * (mu + time) / 41) * .5 + .5);
}

vec3 ColorPalette(vec4[6] colorPalette, float ratio)
{
    ratio = mod(ratio*colorCycles*6 + time/4, 6);
    //ratio = mod(ratio, 1);

    //return lerp(vec3(0,0,1), vec3(1,1,0), 0.6);
    //return lerp(vec3(0,0,1), vec3(1,1,0), 0.6);
    //float t = lerp(0.0,1.0, mod(time,1));
    //return vec3(t,t,t);
    
    if (ratio < 1)
        //return colorPalette[0].xyz;
        return mix(colorPalette[0].xyz, colorPalette[1].xyz, ratio);
    if (ratio < 2)
        //return colorPalette[1].xyz;
        return mix(colorPalette[1].xyz, colorPalette[2].xyz, ratio-1);
    if (ratio < 3)
        //return colorPalette[2].xyz;
        return mix(colorPalette[2].xyz, colorPalette[3].xyz, ratio-2);
    if (ratio < 4)
        //return colorPalette[3].xyz;
        return mix(colorPalette[3].xyz, colorPalette[4].xyz, ratio-3);
    if (ratio < 5)
        //return colorPalette[4].xyz;
        return mix(colorPalette[4].xyz, colorPalette[5].xyz, ratio-4);
    //if (ratio < 6)
        //return colorPalette[5].xyz;
        return mix(colorPalette[5].xyz, colorPalette[0].xyz, ratio-5);
}

float DistanceToPoint(vec2 z, vec2 p)
{
    return length(z - p);
}
float DistanceToLine(vec2 z, vec2 a, vec2 b)
{
    return abs((b.x-a.x)*(a.y-z.y) - (a.x-z.x)*(b.y-a.y)) / sqrt(pow(b.x-a.x,2) + pow(b.y-a.y,2));
}
float DistanceToRectangle(vec2 z, float a, float b)
{
    float dx = max(abs(z.x) - a, 0);
    float dy = max(abs(z.y) - b, 0);
    //float dx = abs(abs(z.x) - a);
    //float dy = abs(abs(z.y) - b);
    return dx * dx + dy * dy;
}
float DistanceToSpiral(vec2 z)
{
    vec2 newZ = z - bailoutSpiral.xy;
    float r = log(length(newZ))/(4 * log(M_PHI)) - (c_arg(newZ) + bailoutSpiral.z)/(M_2PI);
    return bailoutSpiral.w * abs(r - round(r));
}

float sigmoid(float x, float factor)
{
    return 1.0 / (1.0 + exp(-factor * (x - 0.5)));
}
vec3 sigmoid(vec3 v, float factor)
{
    return 1.0 / (1.0 + exp(-factor * (v - 0.5)));
}

vec2 c_1()
{
    return vec2(1,0);
}
vec2 c_i()
{
    return vec2(0,1);
}
vec2 c_mul(vec2 a, vec2 b)
{
    return vec2(a.x*b.x - a.y*b.y, a.x*b.y + a.y*b.x);
}
vec2 c_invert(vec2 c)
{
    float l = pow(length(c),2);
    return vec2(c.x / l, -c.y / l);
}
vec2 c_div(vec2 a, vec2 b)
{
    float x = dot(b,b);
    return vec2((a.x*b.x + a.y*b.y) / x, (a.y*b.x - a.x*b.y) / x);
}
vec2 c_conj(vec2 c)
{
    return vec2(c.x, -c.y);
}
vec2 c_2(vec2 c)
{
    return vec2(c.x*c.x - c.y*c.y, 2*c.x*c.y);
}
vec2 c_pow(vec2 c, float p)
{
    if (c.x == 0 && c.y == 0)
        return c;
	if (p == 1)
        return c;
	if (p == 2)
        return c_2(c);
    else if (int(p) == p)
    {
        vec2 original = c;
        float ip = abs(p);

        for (ip; ip - 1 > 0; ip--)
            c = c_mul(c, original);

        if (p < 0)
            return c_div(vec2(1,0), c);
        
        return c;
    }
    
    c = c_to_polar(c);
    return isnan(c.x) || isnan(c.y) ? c : c_from_polar(pow(c.x, p), c.y * p);
}
vec2 c_pow(float c, vec2 p)
{
    float r = pow(c, p.x);
	float theta = p.y * log(c);

	return isnan(theta) || isnan(r) ? vec2(c,0) : vec2(r * cos(theta), r * sin(theta));
}
vec2 c_pow(vec2 c, vec2 p)
{
    if (c == vec2(0,0))
        return c;
    if (p.y == 0)
        return c_pow(c, p.x);

    vec2 polar = c_to_polar(c);
    return isnan(polar.x) || isnan(polar.y) ? c : c_from_polar(pow(polar.x, p.x) * exp(-p.y * polar.y), p.x * polar.y + p.y * log(polar.x));
}
vec2 c_exp(vec2 c)
{
    float r = exp(c.x);

	if (c.x == 0)
		return vec2(cos(c.y), sin(c.y));
	if (c.y == 0)
		return vec2(r, 0);

	return isnan(c.x) || isnan(c.y) ? c : vec2(r * cos(c.y), r * sin(c.y));
}
vec2 c_rotate(vec2 c, float a)
{
   return c_mul(c, vec2(cos(a), sin(a)));
}
float c_squared_modulus(vec2 c)
{
    return dot(c,c);
}

float c_arg(vec2 c)
{
    return atan(c.y,c.x);
}

vec2 c_from_polar(float r, float theta)
{
  return vec2(r * cos(theta), r * sin(theta));
}
vec2 c_to_polar(vec2 c)
{
  return vec2(length(c), atan(c.y, c.x));
}
