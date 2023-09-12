Shader "Custom/ExtremePsychedelicShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Speed ("Speed", Range(0, 10)) = 1
        _Amplitude ("Amplitude", Range(0, 2)) = 1
        _Frequency ("Frequency", Range(0, 10)) = 5
        _Twirl ("Twirl", Range(0, 1)) = 0.5
        _Noise ("Noise", Range(0, 1)) = 0.2
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
            float _Twirl;
            float _Noise;

            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target {
                half2 uv = i.uv;
                
                // Apply UV distortion
                uv.x += _Amplitude * sin(_Time.y * _Frequency);
                uv.y += _Amplitude * cos(_Time.x * _Frequency);

                // Apply twirl effect
                half2 offset = uv - 0.5;
                half angle = atan2(offset.y, offset.x) + _Twirl * _Time.x;
                half radius = length(offset);
                uv = 0.5 + radius * half2(cos(angle), sin(angle));

                // Apply noise
                uv += _Noise * (_Amplitude * half2(sin(_Time.y), cos(_Time.x)));

                half4 col = tex2D(_MainTex, uv);
                col.r = sin(col.r * _Speed);
                col.g = cos(col.g * _Speed);
                col.b = sin(col.b * _Speed);

                return col;
            }
            ENDCG
        }
    }
}
