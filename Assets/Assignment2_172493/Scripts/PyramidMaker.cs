using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KIT307_172493;

public class PyramidMaker : MonoBehaviour
{
    public float pyramidSize = 1.0f;
    public Texture2D texture;
    public Material pyramid;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        meshRenderer.sharedMaterial = pyramid; //new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        meshFilter.mesh = MeshUtilities.Pyramid(pyramidSize);

        meshRenderer.sharedMaterial.mainTexture = texture;
    }

}
