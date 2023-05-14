using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using war3;

namespace war3
{
    public class MDX
    {
        public int version;
        public List<GeoSet> getsets = new List<GeoSet>();
        public List<string> texturePathList = new List<string>();
    }
    
    public class GeoSet
    {
        public List<Vector3> vertices = new List<Vector3>();
        public List<Vector3> normals = new List<Vector3>();
        public List<Vector2> uv = new List<Vector2>();
        public List<int> faces = new List<int>();
    }
    
    public class GeoMaterial
    {
        
    }
}
