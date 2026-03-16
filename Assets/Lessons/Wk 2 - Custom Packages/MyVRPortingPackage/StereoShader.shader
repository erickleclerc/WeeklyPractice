Shader "Custom/StereoRenderTexture"
{
    Properties
    {
        _LeftTex("Left Eye Texture", 2D) = "black" {}
        _RightTex("Right Eye Texture", 2D) = "black" {}
    }

        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma multi_compile _ UNITY_SINGLE_PASS_STEREO

            #include "UnityCG.cginc"

            sampler2D _LeftTex;
            sampler2D _RightTex;

            struct appdata {
                float4 vertex : POSITION;
                float2 uv     : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f {
                float4 pos    : SV_POSITION;
                float2 uv     : TEXCOORD0;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            v2f vert(appdata v)
            {
                v2f o;

                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

            // Left = 0, Right = 1
            if (unity_StereoEyeIndex == 0)
                return tex2D(_LeftTex,  i.uv);
            else
                return tex2D(_RightTex, i.uv);
        }
        ENDCG
    }
    }
}
