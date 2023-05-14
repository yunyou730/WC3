using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace war3
{
    public class GeoRenderer : MonoBehaviour
    {
        private MDX _mdx = null;
        private GeoSet _geo = null;
        private MeshFilter _meshFilter = null;
        private MeshRenderer _meshRenderer = null;
        
        
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");
        
        public void Init(MDX mdx,GeoSet geo)
        {
            _mdx = mdx;
            _geo = geo;
            CheckAndAddComps();
            SetupMesh(_meshFilter.mesh,geo.vertices,geo.faces,geo.uv);
            SetupMaterials();
        }
        
        protected void CheckAndAddComps()
        {
            _meshFilter = gameObject.GetComponent<MeshFilter>();
            if (_meshFilter == null)
            {
                _meshFilter = gameObject.AddComponent<MeshFilter>();
            }

            _meshRenderer = gameObject.GetComponent<MeshRenderer>();
            if (_meshRenderer == null)
            {
                _meshRenderer = gameObject.AddComponent<MeshRenderer>();
            }
        }

        protected void SetupMesh(Mesh mesh,List<Vector3> newVertices,List<int> newTriangles,List<Vector2> newUVs)
        {
            mesh.vertices = newVertices.ToArray();
            mesh.triangles = newTriangles.ToArray();
            mesh.uv = newUVs.ToArray();
        }
        
        protected void SetupMaterials()
        {
            GeoMaterial geoMaterial = _mdx.materialsInfo[_geo.materialID];
            Material[] materials = new Material[geoMaterial.layers.Count];
            for (int i = 0;i < geoMaterial.layers.Count;i++)
            {
                GeoMaterialLayer geoMatLayer = geoMaterial.layers[i];
                TextureInfo textureInfo = _mdx.texturesInfo[geoMatLayer.textureID];
                
                Shader shader = Shader.Find("Unlit/ObjectRenderer");
                var material = new Material(shader);
                materials[i] = material;

                if (textureInfo.imagePath != "" && 
                    (TextureInfo.EReplaceable)textureInfo.replaceableId == TextureInfo.EReplaceable.ALLOW)
                {
                    // @todo
                    // set color & flag
                }
                else
                {
                    string path = textureInfo.imagePath.Replace("\\", "_");
                    Texture2D texture = Resources.Load<Texture2D>(path);
                    material.SetTexture(MainTex,texture);
                }
            }

            _meshRenderer.sharedMaterials = materials;

        }
        
        protected void HandleTexture(Material material)
        {
            
        }


    }
}
