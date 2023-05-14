Shader "war3/MDX"
{
    Properties
    {
        _TextureORTeamColor("Use Texture OR Team Color",Range(0,1)) = 0
        _MainTex ("Texture", 2D) = "white" {}
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        
        Cull Back

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            int _TextureORTeamColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                //float2 uv = i.uv;
                float2 uv = float2(i.uv.x,1.0 - i.uv.y);

                fixed4 col = tex2D(_MainTex,uv);
                //fixed4 col = tex2D(_MainTex, i.uv);
                //fixed4 col = fixed4(i.uv.x,i.uv.y,0.0,1.0);
                return col;
            }
            ENDCG
        }
    }
}
