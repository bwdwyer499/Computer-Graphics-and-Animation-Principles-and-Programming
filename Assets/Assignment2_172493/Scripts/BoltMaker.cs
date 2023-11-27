using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KIT307_172493
{    public class BoltMaker : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Bolt(10, 10, 5, 2, 6, 16);
        }
    }
}

