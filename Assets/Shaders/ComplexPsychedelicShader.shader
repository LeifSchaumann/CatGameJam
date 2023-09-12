Shader "Custom/ComplexPsychedelicShader" {
    Properties {
        _MainTex ("Texture", 2D) = "green" {}
        _Speed ("Speed", Range(0, 10)) = 1
        _Amplitude ("Amplitude", Range(0, 1)) = 0.5
        _Frequency ("Frequency", Range(0, 10)) = 2
    }

    SubShader {
        Tags { "RenderType"="Opaque" }
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Speed;
            float _Amplitude;
            float _Frequency;

            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target {
                half2 uv = i.uv;
                uv.x += _Amplitude * sin(_Time.y * _Frequency);
                uv.y += _Amplitude * cos(_Time.x * _Frequency);

                half4 col = tex2D(_MainTex, uv);
                col.r = sin(col.r * _Speed * _Time.y);
                col.g = cos(col.g * _Speed * _Time.x);
                col.b = sin(col.b * _Speed * _Time.x);

                return col;
            }
            ENDCG
        }
    }
}
