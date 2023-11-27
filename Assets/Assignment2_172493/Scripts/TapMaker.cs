using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KIT307_172493
{
    public class TapMaker : MonoBehaviour
    {
        public GameObject tapBase;
        public GameObject tapStem;
        public GameObject tapHead;
        public GameObject tapHandle;
        public GameObject tapSpout;
        public GameObject tapSpoutFitting;
        public GameObject tapJoint;


        // Start is called before the first frame update
        void Start()
        {
            //CYLINDER 1 BASE
            //cylinder that makes the base of the lamp
            tapBase = new GameObject();
            tapBase.name = "Tap Base";

            MeshRenderer meshRenderer = tapBase.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            MeshFilter meshFilter = tapBase.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cylinder(16, 0.07f, 0.01f); //(Density,Radius,Height)

            tapBase.transform.parent = transform;

            //CYLINDER 2 STEM
            //Make cylinder that makes up the taps verticle stem
            tapStem = new GameObject();
            tapStem.name = "Tap Stem";

            meshRenderer = tapStem.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = tapStem.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cylinder(16, 0.05f, 0.1f); 

            tapStem.transform.parent = tapBase.transform;
            tapStem.transform.localPosition = new Vector3(0, 0.1f, 0);

            //TAP JOINT
            tapJoint = new GameObject();
            tapJoint.name = "Tap Joint";
            tapJoint.transform.parent = tapStem.transform;
            tapJoint.transform.localPosition = new Vector3(0, 0.1f, 0);
            

            //CYLINDER 3 HEAD
            tapHead = new GameObject();
            tapHead.name = "Tap Head";

            meshRenderer = tapHead.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = tapHead.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cylinder(16, 0.06f, 0.02f);

            tapHead.transform.parent = tapJoint.transform;
            tapHead.transform.localPosition = new Vector3(0, 0.01f, 0);

            //CYLINDER 4 HANDLE
            tapHandle = new GameObject();
            tapHandle.name = "Tap Handle";

            meshRenderer = tapHandle.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = tapHandle.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cylinder(16, 0.01f, 0.05f); //(Density,Radius,Height)

            tapHandle.transform.parent = tapHead.transform;
            tapHandle.transform.localPosition = new Vector3(-0.1f, 0, 0);
            tapHandle.transform.localRotation = Quaternion.Euler(0, 0, 90);
            tapHandle.transform.localScale = new Vector3(1, 3, 1);

            //CYLINDER 5 SPOUT
            tapSpout = new GameObject();
            tapSpout.name = "Tap Spout";

            meshRenderer = tapSpout.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = tapSpout.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cylinder(16, 0.022f, 0.05f); //(Density,Radius,Height)

            tapSpout.transform.parent = tapStem.transform;
            tapSpout.transform.localPosition = new Vector3(-0.07f, 0.03f, 0);
            tapSpout.transform.localRotation = Quaternion.Euler(0, 0, -45);

            //CYLINDER 5 SPOUT FITTING
            tapSpoutFitting = new GameObject();
            tapSpoutFitting.name = "Tap Spout Fitting";

            meshRenderer = tapSpoutFitting.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = tapSpoutFitting.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cylinder(16, 0.017f, 0.01f); //(Density,Radius,Height)

            tapSpoutFitting.transform.parent = tapSpout.transform;
            tapSpoutFitting.transform.localPosition = new Vector3(0, -0.045f, 0);
            tapSpoutFitting.transform.rotation = tapSpout.transform.localRotation;
        }
    }
}

