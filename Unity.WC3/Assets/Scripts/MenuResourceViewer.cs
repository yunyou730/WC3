using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using war3;

public class MenuResourceViewer : MonoBehaviour
{
    private MDX _mdx = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClickTest()
    {
        var newVertices = new List<Vector3>();
        var newTriangles = new List<int>();
        var newUV = new List<Vector2>();
        
        newVertices.Add(new Vector3(-1,-1,0));
        newVertices.Add(new Vector3(-1 ,1,0));
        newVertices.Add(new Vector3(1,-1,0));
        newVertices.Add(new Vector3(1,1,0));

        newTriangles.Add(0);
        newTriangles.Add(1);
        newTriangles.Add(2);
        newTriangles.Add(2);
        newTriangles.Add(1);
        newTriangles.Add(3);

        newUV.Add(new Vector2(0,0));
        newUV.Add(new Vector2(0,0));
        newUV.Add(new Vector2(0,0));
        newUV.Add(new Vector2(0,0));

        GameObject go = new GameObject("GO");
        war3.WMeshRenderer mr = new war3.WMeshRenderer();
        mr.Init(go,newVertices,newTriangles,newUV,null);
    }

    public void OnClickParseJSON()
    {
        string str = Resources.Load("test.mdx").ToString();
        //string str = Resources.Load("farm.mdx").ToString();
        LitJson.JsonData modelData = LitJson.JsonMapper.ToObject(str);
        
        _mdx = war3.MDXParser.FromJson(modelData);
        MDX mdx = _mdx;


        GameObject root = new GameObject("Unity Root");
        Texture2D texture = Resources.Load<Texture2D>("Textures_ranger.blp");
        
        foreach (var geo in mdx.getsets)
        {
            war3.WMeshRenderer mr = new war3.WMeshRenderer();
            GameObject go = new GameObject();
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            mr.Init(go,geo.vertices,geo.faces,geo.uv,texture);
            go.transform.parent = root.transform;
        }   
    }
    
    public void OnClickParseBin()
    {
        Debug.Log("parse bin");
    }
}
