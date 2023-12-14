Shader"Guidev/ToonShader"
{
    Properties
    {
        _Albedo("Albedo",Color) = (1, 1, 1, 1)
        _Shades ("Shades",Range (1,20)) = 3 
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
            

             #include "UnityCG.cginc"

            struct appdata
            {
             float4 vertex : POSITION;
             float3 normal : NORMAL;
            };

            struct v2f
            {
               
             float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                
                  v2f o;
                //Translate the vertex long the normal Vector 
                // This will increase the size of the model 
                 o.vertex = UnityObjectToClipPos(v.vertex + v.normal);
                 
                
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
             return fixed4(1.0,0.0,0.0,1.0);
            }
            ENDCG
        }

        Pass
        {
            Cull Front 
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
               
                float4 vertex : SV_POSITION;
                float3 worldNormal : TEXCOORDO;
            };
                float4 _Albedo;
                float  _Shades;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Calculate the cosine of the angle between the normal vector and the light direction
                // The world space  light direction is stored in _WorldSpaceLightPos0
                //The world space normal is stored in i.worldNormal
                //All what i have to do now is to normalize both vectors and calculate the dot product
                 float cosineAngle = dot(normalize(i.worldNormal), normalize(_WorldSpaceLightPos0.xyz));
    
                 //Set the min to zero as the result can be negative  in cases where the light is behind the shaded point 
                 cosineAngle = max(cosineAngle,0.0);
                 cosineAngle = floor(cosineAngle * _Shades) / _Shades;
                 return _Albedo * cosineAngle;
                   
            }
            ENDCG
        }
    }
}
