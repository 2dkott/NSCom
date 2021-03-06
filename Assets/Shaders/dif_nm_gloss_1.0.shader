﻿Shader "Custom/diffuse_bump_spec" {
 
Properties {
 
  _MainTex ("Texture", 2D) = "white" {}
 
  _SpecMap ("SpecMap", 2D) = "white" {}
 
  _BumpMap ("Normalmap", 2D) = "bump" {}
 
 _Shininess ("Specular Shininess", Float) = 32
 
}
 
SubShader {
 
    Tags { "RenderType" = "Opaque" }
 
CGPROGRAM
 
#pragma surface surf ColoredSpecular
 
 half _Shininess;
 
struct MySurfaceOutput {
 
    half3 Albedo;
 
    half3 Normal;
 
    half3 Emission;
 
    half Specular;
 
    half3 GlossColor;
 
    half Alpha;
 
};
 
 
 
 
 
inline half4 LightingColoredSpecular (MySurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
 
{
 
  half3 h = normalize (lightDir + viewDir);
 
 
 
  half diff = max (0, dot (s.Normal, lightDir));
 
 
 
  float nh = max (0, dot (s.Normal, h));
 
  float spec = pow (nh, _Shininess);
 
  half3 specCol = spec * s.GlossColor;
 
 
 
  half4 c;
 
  c.rgb = (s.Albedo * _LightColor0.rgb * diff + _LightColor0.rgb * specCol) * (atten * 2);
 
  c.a = s.Alpha;
 
  return c;
 
}
 
 
 
inline half4 LightingColoredSpecular_PrePass (MySurfaceOutput s, half4 light)
 
{
 
    half3 spec = light.a * s.GlossColor;
 
   
 
    half4 c;
 
    c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
 
    c.a = s.Alpha + spec * _SpecColor.a;
 
    return c;
 
}
 
 
 
 
 
struct Input {
 
  float2 uv_MainTex;
 
  float2 uv_SpecMap;
 
  float2 uv_BumpMap;
 
};
 
sampler2D _MainTex;
 
sampler2D _SpecMap;
 
sampler2D _BumpMap;
 
 
 
void surf (Input IN, inout MySurfaceOutput o)
 
{
 
  o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
 
  half4 spec = tex2D (_SpecMap, IN.uv_SpecMap);
 
  o.GlossColor = spec.rgb;
 
  o.Specular = _Shininess/128.0;
 
  o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
 
}
 
ENDCG
 
}
 
Fallback "Diffuse"
 
}