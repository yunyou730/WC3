using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using war3;
using LitJson;

namespace war3
{
    public static class MDXParser
    {
        private static float kScaleFactor = 0.01f;
        public static MDX FromJson(LitJson.JsonData json)
        {
            MDX mdx = new MDX();

            int version = (int)json["Version"];
            mdx.version = version;
            
            JsonData geosetsData = json["Geosets"];
            for (int geoIdx = 0;geoIdx < geosetsData.Count;geoIdx++)
            {
                ReadGeoSet(mdx,geosetsData,geoIdx);
            }

            return mdx;
        }
        
        static float GetFloatData(JsonData jsonData)
        {
            float result = 0.0f;

            if (jsonData.IsDouble)
            {
                double v = (double)jsonData;
                result = (float)v;
            }
            if (jsonData.IsInt)
            {
                int v = (int)jsonData;
                result = (float)v;
            }
            return result;
        }

        private static void ReadGeoSet(MDX mdx,JsonData geosetsData,int geoIdx)
        {
            GeoSet geoset = new GeoSet();
            mdx.getsets.Add(geoset);
                
            JsonData geosetData = geosetsData[geoIdx];
                
            // vertex pos
            int vertCount = geosetData["Vertices"].Count / 3;
            for (int vertIdx = 0;vertIdx < vertCount;vertIdx++)
            {
                // attr pos
                float x = GetFloatData(geosetData["Vertices"][vertIdx * 3 + 0]);
                float y = GetFloatData(geosetData["Vertices"][vertIdx * 3 + 1]);
                float z = GetFloatData(geosetData["Vertices"][vertIdx * 3 + 2]);                
                geoset.vertices.Add(new Vector3(x,y,z) * kScaleFactor);
                
                // attr normal
                float nx = GetFloatData(geosetData["Normals"][vertIdx * 3 + 0]);
                float ny = GetFloatData(geosetData["Normals"][vertIdx * 3 + 1]);
                float nz = GetFloatData(geosetData["Normals"][vertIdx * 3 + 2]);
                geoset.normals.Add(new Vector3(nx,ny,nz));
                
                // attr UV
                float u = GetFloatData(geosetData["TVertices"][0][vertIdx * 2 + 0]);
                float v = GetFloatData(geosetData["TVertices"][0][vertIdx * 2 + 1]);
                geoset.uv.Add(new Vector2(u,v));
            }
                
            // vert index to geoset.faces
            int indexCount = geosetData["Faces"].Count;
            for (int iIdx = 0;iIdx < indexCount;iIdx++)
            {
                int vertIdx = (int)geosetData["Faces"][iIdx];
                geoset.faces.Add(vertIdx);
            }
        }
    }
    
}
