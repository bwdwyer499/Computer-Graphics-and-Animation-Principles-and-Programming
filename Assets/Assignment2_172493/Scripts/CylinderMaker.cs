using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KIT307_172493;

public class CylinderMaker : MonoBehaviour
{
    public int cylinderD = 10;
    public float cylinderH = 10.0f;
    public float cylinderR = 5.0f;
    public Material cylinder;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        meshRenderer.sharedMaterial = cylinder; //new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        meshFilter.mesh = MeshUtilities.Cylinder(cylinderD, cylinderR, cylinderH);

    }
}
