#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;


out vec3 NormalWS;
out vec3 PosWS;

void main()
{
    // Local Space --> World Space --> Camera Space --> Clip Space
    gl_Position = projection * view * model * vec4(aPos ,  1.0);

    // Pos World Space
    PosWS = vec3(model * vec4(aPos ,  1.0));

    // Normal World Space 法线矩阵：模型矩阵左上角的逆矩阵的转置矩阵(不等比缩放时必用)
    NormalWS = mat3(transpose(inverse(model))) * aNormal;
    
    // 注意 inverse 逆矩阵计算 消耗很大 避免在Shader中使用
}