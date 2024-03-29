#version 330 core
out vec4 FragColor;

in vec3 NormalWS;
in vec3 PosWS;

uniform vec3 objectColor;
uniform vec3 lightColor;
uniform vec3 lightPos;
uniform vec3 cameraPos;

void main()
{
    //****Phong Light Mode****

    // ambient
    float ambientStrength = 0.3;
    vec3 ambient = lightColor * ambientStrength;

    // diffuse
    vec3 Normal = normalize(NormalWS);
    vec3 LightVector = normalize(lightPos - PosWS);
    float diff = max(dot(Normal,LightVector),0.0);
    vec3 diffuse = diff * lightColor;

    // specular
    float specularStrength = 0.5;
    vec3 cameraDir = normalize(cameraPos - PosWS);
    vec3 reflectDir = reflect(-LightVector, Normal);
    float spec = pow(max(dot(cameraDir,reflectDir),0.0),32);
    vec3 specular = specularStrength * spec * lightColor;


    // result
    vec3 result = (ambient + diffuse + specular) * objectColor;

    FragColor = vec4(result,1.0);
}