using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace war3
{
    public class MDXRenderer : MonoBehaviour
    {
        private MDX _mdx = null;

        public void Init(MDX mdx)
        {
            _mdx = mdx;
            
            for(int i = 0;i < mdx.geosets.Count;i++)
            {
                var geoset = mdx.geosets[i];
                GameObject go = new GameObject("geo[" + i + "]");
                go.transform.parent = gameObject.transform;
                var geoRenderer = go.AddComponent<GeoRenderer>();
                geoRenderer.Init(_mdx,geoset);
            }
        }
    }
}
