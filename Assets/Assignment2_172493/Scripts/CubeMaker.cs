using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KIT307_172493;

public class CubeMaker : MonoBehaviour
{
    public float cubeSize = 1.0f;
    public Texture2D texture;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        meshFilter.mesh = MeshUtilities.Cube(cubeSize);

        meshRenderer.sharedMaterial.mainTexture = texture;
    }
}
