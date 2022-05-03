Shader "Unlit/GrayScale"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        
        _GrayR("Gray R", Range(0, 0.299)) = 0
        _GrayG("Gray G", Range(0, 0.587)) = 0
        _GrayB("Gray B", Range(0, 0.114)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float _GrayR;
            float _GrayB;
            float _GrayG;
            

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float intensity = col.x * _GrayB + col.y * _GrayB+ col.z * _GrayG;
                return fixed4(intensity, intensity, intensity, col.w);
            }
            ENDCG
        }
    }
}
