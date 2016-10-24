Shader "Farm/BlimpFishFourOnTheFloorDropTheBeat" 
{
	Properties {
		_MainTex ("Base Color (RGB)", 2D) = "white" {}
		_Stroke0("Stroke0 (RGB)", 2D) = "white" {}
		_Stroke1("Stroke1 (RGB)", 2D) = "white" {}
		_Stroke2("Stroke2 (RGB)", 2D) = "white" {}
		_Stroke3("Stroke3 (RGB)", 2D) = "white" {}
		_Stroke4("Stroke4 (RGB)", 2D) = "white" {}
		_Color ("Main Color", Color) = (1,1,1,1)
		_stroke0color ("Stoke0 Color", Color) = (1,1,1,1)
		_stroke1color ("Stoke1 Color", Color) = (1,1,1,1)
		_stroke2color ("Stoke2 Color", Color) = (1,1,1,1)
		_stroke3color ("Stoke3 Color", Color) = (1,1,1,1)
		_stroke3color ("Stoke4 Color", Color) = (1,1,1,1)
	}

	SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            
            CGPROGRAM
            #include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest

			uniform sampler2D _MainTex;
			uniform sampler2D _Stroke0;
			uniform float4 _Stroke0_ST;
			uniform sampler2D _Stroke1;
			uniform sampler2D _Stroke2;
			uniform sampler2D _Stroke3;
			uniform sampler2D _Stroke4;
			uniform float4 _Color;
			uniform float4 _stroke0color;
			uniform float4 _stroke1color;
			uniform float4 _stroke2color;
			uniform float4 _stroke3color;
			uniform float4 _stroke4color;

            struct vertexInput {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct vertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
				float2 cap : TEXCOORD1;
            };


            vertexOutput vert (appdata_base vertIn) {
                vertexOutput output;
				output.pos = mul(UNITY_MATRIX_MVP, vertIn.vertex);
                output.uv0 = TRANSFORM_TEX(vertIn.texcoord, _Stroke0);

				return output;
            }


			float4 frag(vertexOutput input) : COLOR{
				return _Color*float4(tex2D(_MainTex, input.uv0).rgb, 1.0)
				+ _stroke1color*float4(tex2D(_Stroke1, input.uv0).rgb, 1.0)
				+ _stroke2color*float4(tex2D(_Stroke2, input.uv0).rgb, 1.0)
				+ _stroke3color*float4(tex2D(_Stroke3, input.uv0).rgb, 1.0)
				+ _stroke4color*float4(tex2D(_Stroke4, input.uv0).rgb, 1.0);
            }

            ENDCG
        }
   
    }
	FallBack "Diffuse"
}
