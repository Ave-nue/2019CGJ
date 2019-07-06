// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "2D_Cel_Shader" {
	Properties{
		_MainTex("Main Tex", 2D) = "white" {}
		_dark_color("Dark Color", Color) = (0,0,1,1)
		_light_color("Light Color", Color) = (1,1,0,1)
		_BumpMap("Normal Map", 2D) = "bump" {}
		_AOMap("AO Map", 2D) = "white" {}
		_light_position("Light Position", Vector) = (0,0,0,0)
	}
		SubShader{
			Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
			Pass {
				Tags { "LightMode" = "ForwardBase" }

				ZWrite Off
				Blend SrcAlpha OneMinusSrcAlpha

				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag

				#include "Lighting.cginc"

				sampler2D _MainTex;
				float4 _MainTex_ST;
				float4 _light_color;
				float4 _dark_color;
				sampler2D _BumpMap;
				float4 _BumpMap_ST;
				sampler2D _AOMap;
				float4 _AOMap_ST;
				float4 _light_position;



				struct a2v {
					float4 vertex : POSITION;
					float4 texcoord : TEXCOORD0;
				};

				struct v2f {
					float4 pos : SV_POSITION;
					float4 uv : TEXCOORD0;
					float2 ao : TEXCOORD1;
					float3 worldpos : TEXCOORD2;
				};

				v2f vert(a2v v) {
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);

					o.uv.xy = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					o.uv.zw = v.texcoord.xy * _BumpMap_ST.xy + _MainTex_ST.zw;
					o.ao.xy = v.texcoord.xy * _AOMap_ST.xy + _AOMap_ST.zw;

					o.worldpos = mul(unity_ObjectToWorld, v.vertex).xyz;
					return o;
				}

				float4 frag(v2f i) : SV_Target {
					float4 diffuse = tex2D(_MainTex, i.uv.xy).rgba;
					float3 channels = tex2D(_AOMap, i.ao.xy).rgb;
					float ao = channels.r;
					float bypass = channels.g;

					float3 normal = tex2D(_BumpMap, i.uv.zw).rgb;

					normal = normalize(2 * normal - 1);


					float3 light = float3(0,0,0);

					float3 light_dir = _light_position.xyz - i.worldpos;
					float3 view_dir = normalize(UnityWorldSpaceViewDir(i.worldpos));

					float dist = light_dir.z;
					float atten = smoothstep(60, 30 ,dist);
					light_dir = normalize(light_dir);
					float3 current_light = atten * lerp(0,1,dot(normal, light_dir)) * (ao + 0.05) * 1.2;

					light = max(0,current_light - 0.38);

					light *= ao;

					diffuse += tex2D(_MainTex, i.uv.xy).rgba / 2;

					float3 gooch_light = (_dark_color * (1 - light) + _light_color * light * 1.6) * 0.4;


					float3 cel_light = smoothstep(0.1, 0.19, (current_light) / 2) + diffuse.rgb;


					return float4(float3 ((cel_light * diffuse * 0.5 + gooch_light) * bypass), diffuse.a);

				}

				ENDCG
			}
		}
}