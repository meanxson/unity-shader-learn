Shader "NT/SkyBox"
{
    Properties
    {
		_ColorA("Color A", color) = (0,0,0,0)
		_ColorB("Color B", color) = (0,0,0,0)
		_Delta("Delta", Float) = 0.5
    }
    SubShader
    {
        Tags {"QUEUE"="Background" "PreviewType"="Skybox" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

			fixed4 _ColorA;
			fixed4 _ColorB;
			float _Delta;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float2 position : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				_Delta = (sin(_Time.y + i.uv.y)+1)/4;
				fixed3 color = lerp(_ColorA, _ColorB, _Delta);
                return fixed4(color, 1.0);
            }
            ENDCG
        }
    }
}
