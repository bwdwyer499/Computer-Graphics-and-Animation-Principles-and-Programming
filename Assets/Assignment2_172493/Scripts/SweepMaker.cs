using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KIT307_172493
{
    public class SweepMaker : MonoBehaviour
    {
        public GameObject sweep;

        void Start()
        {
            Vector3[] sweepProfile = new Vector3[10];
            sweepProfile[0] = new Vector3(0.0f, -0.01f, 0.0f);
            sweepProfile[1] = new Vector3(0.014f, -0.01f, 0.0f);
            sweepProfile[2] = new Vector3(0.04f, -0.01f, 0.0f);
            sweepProfile[3] = new Vector3(0.04f, 0.03f, 0.0f);
            sweepProfile[4] = new Vector3(0.014f, 0.03f, 0.0f);

            sweepProfile[5] = new Vector3(0.0f, 0.03f, 0.0f);
            sweepProfile[6] = new Vector3(-0.014f, 0.03f, 0.0f);
            sweepProfile[7] = new Vector3(-0.04f, 0.01f, 0.0f);
            sweepProfile[8] = new Vector3(-0.04f, -0.01f, 0.0f);
            sweepProfile[9] = new Vector3(-0.014f, -0.01f, 0.0f);

            Matrix4x4[] sweepPath;

            //Hold the path instances
            sweepPath = new Matrix4x4[15];
            //create the first transform:
            sweepPath[0] = Matrix4x4.Scale(new Vector3(0, 0, 1)) * Matrix4x4.Translate(new Vector3(0, 0, -0.4f));
            //Adjust the scale for the next path instance
            sweepPath[1] = Matrix4x4.Scale(new Vector3(0.2f, 0.2f, 1)) * Matrix4x4.Translate(new Vector3(0, 0, -0.4f));

            sweepPath[2] = Matrix4x4.Translate(new Vector3(0, 0, -0.2f));

            //Body of the snake
            //Adjust the position for the next path instances (default scale 1)
            //First body turn
            sweepPath[3] = Matrix4x4.Translate(new Vector3(-0.1f, 0, -0.15f));
            sweepPath[4] = Matrix4x4.Translate(new Vector3(-0.1f, 0, -0.14f));
            //Second body turn
            sweepPath[5] = Matrix4x4.Translate(new Vector3(0.1f, 0, -0.1f));
            sweepPath[6] = Matrix4x4.Translate(new Vector3(0.1f, 0, -0.09f));
            //Third body turn
            sweepPath[7] = Matrix4x4.Translate(new Vector3(-0.1f, 0, 0));
            sweepPath[8] = Matrix4x4.Translate(new Vector3(-0.1f, 0, 0.01f));
            //Forth body turn
            sweepPath[9] = Matrix4x4.Translate(new Vector3(0.1f, 0, 0.055f));
            sweepPath[10] = Matrix4x4.Translate(new Vector3(0.1f, 0, 0.054f));

            //Head 
            //Finally the path instances for the other end cap from the first transform to form a head
            sweepPath[11] = Matrix4x4.Scale(new Vector3(0.9f, 0.9f, 1)) * Matrix4x4.Translate(new Vector3(0, 0, 0.2f));
            sweepPath[12] = Matrix4x4.Scale(new Vector3(0.5f, 0.9f, 1)) * Matrix4x4.Translate(new Vector3(0, 0, 0.2f));
            sweepPath[13] = Matrix4x4.Translate(new Vector3(0, 0, 0.25f));
            //Close the end on the y and almost on the x to make the nose
            sweepPath[14] = Matrix4x4.Scale(new Vector3(0.1f, 0, 1)) * Matrix4x4.Translate(new Vector3(0.1f, 0, 0.4f));


            sweep = new GameObject();
            sweep.name = "Sweep";
            MeshRenderer meshRenderer = sweep.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            MeshFilter meshFilter = sweep.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Sweep(sweepProfile, sweepPath, false);

            sweep.transform.parent = transform;
            //sweep.transform.localPosition = new Vector3(0, 0.1f, 0);
            //sweep.transform.localRotation = Quaternion.Euler(90, 0, 90);

        }
    }
}