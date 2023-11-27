using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KIT307_172493
{
    //A torus (donut) a circle swept along another one.
    public class Torus : MonoBehaviour
    {
        Mesh torusMesh;
        MeshRenderer meshRenderer;
        MeshFilter meshFilter;
        Vector3[] verts;
        int[] tris;

        //pulbic variables for inspector useage
        [Header("URP Material to Render")]
        public Material torusMaterial;

        [Header("Size of Pipe and Internal Curve Radii")]
        public float pipeRadius;
        public float internalTRadius;

        [Header("Number of pipe and curved segments")]
        public int numPipeParts;
        public int numSideWalls;

        // Start is called before the first frame update
        void Start()
        {
            meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshFilter = gameObject.AddComponent<MeshFilter>();

            torusMesh = new Mesh();
            meshRenderer.sharedMaterial = torusMaterial;
            GetComponent<MeshFilter>().mesh = torusMesh;
            SetVerts();
            SetTris();
            torusMesh.RecalculateNormals();
        }

        // Update is called once per frame       
        void Update()
        {

        }

        //void CreateTorus()
        //{
        //    verts = new Vector3[numSideWalls * numPipeParts * 4];
        //    float uStep = (2f * Mathf.PI) / numPipeParts;
           
        //}

        //sinusoid function
        //x = (R + r cos v) cos u
        //y = (R + r cos v) sin u
        //z = r cos v
        Vector3 GetTorusPoint(float u, float v)
        {
            Vector3 point;
            float rad = (internalTRadius + pipeRadius * Mathf.Cos(v));
            point.x = rad * Mathf.Sin(u);
            point.y = rad * Mathf.Cos(u);
            point.z = pipeRadius * Mathf.Sin(v);
            return point;
        }


        void SetVerts()
        {
            verts = new Vector3[numSideWalls * numPipeParts * 4];
            float uStep = (2f * Mathf.PI) / numPipeParts;
            CreateFirstRing(uStep);
            int segMove = numSideWalls * 4;
            for (int i = 2, j = segMove; i <= numPipeParts; i++, j += segMove)
            {
                CreateTorus(i * uStep, j);
            }

            torusMesh.vertices = verts;
        }
        private void SetTris()
        {
            tris = new int[numSideWalls * numPipeParts * 6];
            for (int t = 0, i = 0; t < tris.Length; t += 6, i += 4)
            {
                tris[t] = i;
                tris[t + 1] = tris[t + 4] = i + 1;
                tris[t + 2] = tris[t + 3] = i + 2;
                tris[t + 5] = i + 3;
            }
            torusMesh.triangles = tris;
        }
        private void CreateFirstRing(float u)
        {
            float vStep = (2f * Mathf.PI) / numSideWalls;

            Vector3 vertexA = GetTorusPoint(0f, 0f);
            Vector3 vertexB = GetTorusPoint(u, 0f);
            for (int v = 1, i = 0; v <= numSideWalls; v++, i += 4)
            {
                verts[i] = vertexA;
                verts[i + 1] = vertexA = GetTorusPoint(0f, v * vStep);
                verts[i + 2] = vertexB;
                verts[i + 3] = vertexB = GetTorusPoint(u, v * vStep);

            }
        }

        void CreateTorus(float u, int i)
        {
            float vStep = (2f * Mathf.PI) / numSideWalls;
            int ringOffset = numSideWalls * 4;

            Vector3 vertex = GetTorusPoint(u, 0f);
            for (int v = 1; v <= numSideWalls; v++, i += 4)
            {
                verts[i] = verts[i - ringOffset + 2];
                verts[i + 1] = verts[i - ringOffset + 3];
                verts[i + 2] = vertex;
                verts[i + 3] = vertex = GetTorusPoint(u, v * vStep);
            }
        }
    }
}

