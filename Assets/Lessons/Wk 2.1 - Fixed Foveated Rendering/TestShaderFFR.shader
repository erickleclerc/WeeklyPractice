Shader "Unlit/FFRDebug"
{
    Properties
    {
        _Scale("Pattern Scale", Float) = 200
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float _Scale;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float pattern = frac(i.uv.x * _Scale) > 0.5 ^ frac(i.uv.y * _Scale) > 0.5;
                return pattern ? 1 : 0;
            }

            ENDCG
        }
    }
}