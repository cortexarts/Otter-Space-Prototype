// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/SpriteRadialGradient" {
    Properties{
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
    _Color("Bottom Color", Color) = (1,1,1,1)
        _Color2("Top Color", Color) = (1,1,1,1)
        _Slide("Slide", Range(0, 1)) = 0.5
    }
        SubShader{
        Tags{ "Queue" = "Transparent"  "IgnoreProjector" = "True" }
        LOD 100
        ZWrite Off
        Pass{
        Blend SrcAlpha OneMinusSrcAlpha
        CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
        fixed4 _Color;
    fixed4 _Color2;
    float _Slide;

    struct v2f
    {
        float4 pos : SV_POSITION;
        fixed4 col : COLOR;
    };
    v2f vert(appdata_full v)
    {
        float t = length(v.texcoord - float2(0.5, 0.5)) * 1.41421356237; // 1.141... = sqrt
        v2f o;
        o.pos = UnityObjectToClipPos(v.vertex);
        o.col = lerp(_Color,_Color2, t + (_Slide - 0.5) * 2);
        return o;
    }

    float4 frag(v2f i) : COLOR{
        float4 c = i.col;
        return c;
    }
        ENDCG
    }
    }
}