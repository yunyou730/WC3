using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace war3
{
    public class WMeshRenderer
    {
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");
        
        public void Init(GameObject go,List<Vector3> newVertices,List<int> newTriangles,List<Vector2> newUV,Texture2D texture)
        {
            MeshFilter meshFilter = go.GetComponent<MeshFilter>();
            MeshRenderer meshRenderer = go.GetComponent<MeshRenderer>();

            if (meshFilter == null)
            {
                meshFilter = go.AddComponent<MeshFilter>();
            }

            if (meshRenderer == null)
            {
                meshRenderer = go.AddComponent<MeshRenderer>();
            }

            // setup mesh data
            Mesh mesh = meshFilter.mesh;
            mesh.Clear();
            mesh.vertices = newVertices.ToArray();
            mesh.triangles = newTriangles.ToArray();
            mesh.uv = newUV.ToArray();
            
            //mesh.Optimize();
            //mesh.RecalculateNormals();
            //mesh.vertices = 
            // set material
            
            // shader & material
            Shader shader = Shader.Find("Unlit/ObjectRenderer");
            Material material = new Material(shader);
            meshRenderer.sharedMaterial = material;
            
            if (texture != null)
            {
                material.SetTexture(MainTex,texture);    
            }
        }
    }
}
