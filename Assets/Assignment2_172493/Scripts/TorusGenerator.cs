using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KIT307_172493
{    public class TorusGenerator : MonoBehaviour
    {
        Mesh torusMesh;
        MeshRenderer meshRenderer;
        MeshFilter meshFilter;
        Vector3[] verts;
        Vector2[] uvs;
        int[] tris;

        //pulbic variables for inspector useage
        [Header("URP Material to Render")]
        public Material torusMaterial;

        [Header("Pipe and Internal Curve Radii")]
        public float pipeRadius;
        public float internalTRadius;

        [Header("Pipe System")]
        public float pipeDistance;
        private float prevPipeCurve;

        [Header("Number of pipe and curved segments")]
        public int numPipeParts;
        public int numSideWalls;

        // Start is called before the first frame update
        void Awake()
        {
            meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshFilter = gameObject.AddComponent<MeshFilter>();

            torusMesh = new Mesh();
            meshRenderer.sharedMaterial = torusMaterial;
            GetComponent<MeshFilter>().mesh = torusMesh;         

            SetVerts();
            SetTris();
            SetUVs();
            torusMesh.RecalculateNormals();
        }

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
            float uStep = pipeDistance / pipeRadius;
            prevPipeCurve = uStep * numSideWalls * (360.0f / (2.0f * Mathf.PI));
            CreateFirstRing(uStep);
            int segMove = numSideWalls * 4;
            for (int i = 2, j = segMove; i <= numSideWalls; i++, j += segMove)
            {
                CreateTorus(i * uStep, j);
            }
            torusMesh.vertices = verts;
        }

        private void SetTris()
        {
            tris = new int[(numSideWalls * numPipeParts * 6)];
            for (int t = 0, i = 0; t < tris.Length; t += 6, i += 4)
            {
                tris[t] = i;
                tris[t + 1] = tris[t + 4] = i + 2;
                tris[t + 2] = tris[t + 3] = i + 1;
                tris[t + 5] = i + 3;
            }
            torusMesh.triangles = tris;
        }

        private void SetUVs()
        {
            uvs = new Vector2[verts.Length];
            for (int i = 0; i < verts.Length; i += 4)
            {
                uvs[i] = Vector2.zero;
                uvs[i + 1] = Vector2.right;
                uvs[i + 2] = Vector2.up;
                uvs[i + 3] = Vector2.one;
            }
            torusMesh.uv = uvs;
        }

        public void AlignPipes(TorusGenerator t)
        {
            transform.SetParent(t.transform, false);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -t.prevPipeCurve);
            transform.Translate(0.0f, t.internalTRadius, 0.0f);
            transform.Rotate(numSideWalls * 90, 0.0f, 0.0f);
            transform.Translate(0.0f, -internalTRadius, 0.0f);
            transform.SetParent(t.transform.parent);
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

