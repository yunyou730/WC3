using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using war3;

namespace war3
{
    public class MDX
    {
        public int version;
        public List<GeoSet> geosets = new List<GeoSet>();
        public List<string> texturePathList = new List<string>();
        public List<TextureInfo> texturesInfo = new List<TextureInfo>();
        public List<GeoMaterial> materialsInfo = new List<GeoMaterial>();
    }
    
    public class GeoSet
    {
        public List<Vector3> vertices = new List<Vector3>();
        public List<Vector3> normals = new List<Vector3>();
        public List<Vector2> uv = new List<Vector2>();
        public List<int> faces = new List<int>();

        public int materialID = 0;
    }
    
    public class GeoMaterial
    {
        public List<GeoMaterialLayer> layers = new List<GeoMaterialLayer>();
        public int priorityPlane;
        public int renderMode;
    }
    
    public class GeoMaterialLayer
    {
        public int textureID;
        public int filterMode;
    }
    
    

    public class TextureInfo
    {
        public enum EReplaceable
        {
            NOT_ALLOW = 0,
            ALLOW = 1
        }
            
        public int replaceableId;
        public string imagePath;
        public int flags;
    }
}
