using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KIT307_17249
{    public class TerrainGenerator : MonoBehaviour
    {
        Mesh terrainMesh;
        MeshFilter meshFilter;
        MeshRenderer meshRenderer;
        MeshCollider meshCollider;

        [Header("Material & Gradient For Shader Colour")]
        public Material terrainMaterial;
        public Gradient colourGradient;

        Vector3[] verts;
        //Vector2[] uvs;
        Color[] colours;        
        //public Texture2D texture;
        int[] tris;        

        [Header("Size of Terrain")]
        public int width = 20;
        public int lenght = 40;
        float minHeight;
        float maxHeight;

        [Header("Terrain Editing Tools")]
        public Vector3 rotation;
        public float perlinAmp = 1.2f;

        // Start is called before the first frame update
        void Start()
        {
            meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshFilter = gameObject.AddComponent<MeshFilter>();
            meshCollider = gameObject.AddComponent<MeshCollider>();

            terrainMesh = new Mesh();
            //meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshRenderer.sharedMaterial = terrainMaterial;
            GetComponent<MeshFilter>().mesh = terrainMesh;
            //GetComponent<MeshCollider>().sharedMesh = terrainMesh;
            //meshCollider.sharedMesh = terrainMesh;
            //meshFilter.mesh = terrainMesh;

            CreateTerrainMesh();
            //UpdateMesh();
        }

        // Update is called once per frame
        void Update()
        {
            CreateTerrainMesh();
            UpdateMesh();
            //changeRotation();
        }

        void UpdateMesh()
        {
            terrainMesh.Clear();
            terrainMesh.vertices = verts;
            terrainMesh.triangles = tris;
            terrainMesh.colors = colours;
            //terrainMesh.uv = uvs;
            terrainMesh.RecalculateNormals();
            terrainMesh.RecalculateBounds();
            meshCollider = gameObject.GetComponent<MeshCollider>();
            meshCollider.sharedMesh = terrainMesh;

        }
        void CreateTerrainMesh()
        {
            verts = new Vector3[(width + 1) * (lenght + 1)];
            //Vector4[] tangents = new Vector4[verts.Length];
            //Vector4 tangent = new Vector4(2f, 0f, 0f, -2f);
            int currentVert = 0;

            for (int iz = 0; iz <= lenght; iz++)
            {
                for (int ix = 0; ix <= width; ix++)
                {
                    float radX = rotation.x * Mathf.Deg2Rad;
                    float radZ = rotation.z * Mathf.Deg2Rad;
                    float sinX = Mathf.Sin(radX);
                    float sinZ = Mathf.Sin(radZ);
                    float height = Mathf.PerlinNoise(ix * sinX, iz * sinZ) * perlinAmp;
                    verts[currentVert] = new Vector3(ix, height, iz);

                    //update height for terrain colour
                    if (height > maxHeight)
                    {
                        maxHeight = height;
                    }
                    if (height < minHeight)
                    {
                        minHeight = height;
                    }

                    currentVert++;
                    //tangents[currentVert] = tangent;
                }
            }

            //Triangles
            tris = new int[width * lenght * 6]; //amount of points for the plane

            int vert = 0;               //vertex
            int arrayIndexTris = 0;     //current array indices

            for (int iz = 0; iz < lenght; iz++)
            {
                for (int ix = 0; ix < width; ix++)
                {
                    tris[arrayIndexTris + 0] = vert + 0;
                    tris[arrayIndexTris + 1] = vert + width + 1;
                    tris[arrayIndexTris + 2] = vert + 1;
                    tris[arrayIndexTris + 3] = vert + 1;
                    tris[arrayIndexTris + 4] = vert + width + 1;
                    tris[arrayIndexTris + 5] = vert + width + 2;

                    vert++;
                    arrayIndexTris += 6;
                }
                vert++;
            }

            //Change colour based on height of verts
            colours = new Color[(width + 1) * (lenght + 1)];
            int i = 0;
            for (int iz = 0; iz <= lenght; iz++)
            {
                for (int ix = 0; ix <= width; ix++)
                {
                    float vertHeight = Mathf.InverseLerp(minHeight, maxHeight, verts[i].y);
                    colours[i] = colourGradient.Evaluate(vertHeight);
                    i++;
                }
            }
        }        
        //void changeRotation()
        //{

        //}
    }
}

