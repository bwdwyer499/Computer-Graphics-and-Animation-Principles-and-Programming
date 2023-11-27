using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KIT307_172493
{
    public class RobotMaker : MonoBehaviour
    {
        //Robot Body Parts
        GameObject robotLegR;
        GameObject robotLegL;
        GameObject robotFootR;
        GameObject robotFootL;
        GameObject robotBody;
        GameObject robotArmR;
        GameObject robotArmL;
        GameObject robotHead;
        GameObject robotNeck;
        GameObject robotEarR;
        GameObject robotEarEtxR;
        GameObject robotEarL;
        GameObject robotEarEtxL;
        GameObject robotAntenna;
        GameObject robotEyeR;
        GameObject robotEyeL;
        GameObject robotMouth;

        //RobotJoints
        GameObject legJointL;
        GameObject legJointR;
        GameObject ankleJointR;
        GameObject ankleJointL;
        GameObject armJointL;
        GameObject armJointR;
        GameObject neckJoint;

        //public Transform transform;
        //Material
        public Material material;
        public Material material2;
        public Material material3;

        // Start is called before the first frame update
        void Start()
        {
            //////////Robot Body//////////
            robotBody = new GameObject();
            robotBody.name = "Robot Body";
            MeshRenderer meshRenderer = robotBody.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            MeshFilter meshFilter = robotBody.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cube(1);
            robotBody.transform.parent = transform;
            robotBody.transform.localPosition = new Vector3(0,0,0);
            robotBody.transform.localScale = new Vector3(1, 1.5f, 0.5f);
            meshRenderer.material = material;


            //////////RIGHT ARM//////////
            //Robot arm joint right
            armJointR = new GameObject();
            armJointR.name = "Arm Joint R";
            armJointR.transform.parent = robotBody.transform;
            armJointR.transform.localPosition = new Vector3(-1, 0.5f, 0);

            //Robot arm right
            robotArmR = new GameObject();
            robotArmR.name = "Arm Right";
            meshRenderer = robotArmR.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotArmR.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cube(0.5f);
            robotArmR.transform.parent = armJointR.transform;
            robotArmR.transform.localPosition = new Vector3(-0.25f, -0.5f, 0);
            robotArmR.transform.localScale = new Vector3(0.5f, 1.5f, 0.5f);
            meshRenderer.material = material;

            //////////LEFT ARM//////////
            //Robot arm joint right
            armJointL = new GameObject();
            armJointL.name = "Arm Joint L";
            armJointL.transform.parent = robotBody.transform;
            armJointL.transform.localPosition = new Vector3(1, 0.5f, 0);

            //Robot arm right
            robotArmL = new GameObject();
            robotArmL.name = "Arm Left";
            meshRenderer = robotArmL.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotArmL.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cube(0.5f); 
            robotArmL.transform.parent = armJointL.transform;
            robotArmL.transform.localPosition = new Vector3(0.25f, -0.5f, 0);
            robotArmL.transform.localScale = new Vector3(0.5f, 1.5f, 0.5f);
            meshRenderer.material = material;

            //////////RIGHT LEG//////////
            //Robot arm joint right
            legJointR = new GameObject();
            legJointR.name = "Leg Joint R";
            legJointR.transform.parent = robotBody.transform;
            legJointR.transform.localPosition = new Vector3(-0.25f, -1, 0);

            //Robot leg right
            robotLegR = new GameObject();
            robotLegR.name = "Leg Right";
            meshRenderer = robotLegR.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotLegR.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cube(0.5f); 
            robotLegR.transform.parent = legJointR.transform;
            robotLegR.transform.localPosition = new Vector3(-0.25f, -0.75f, 0);
            robotLegR.transform.localScale = new Vector3(0.5f, 1.5f, 0.5f);
            meshRenderer.material = material;

            //Robot Ankle Right
            ankleJointR = new GameObject();
            ankleJointR.name = "Ankle Joint R";
            ankleJointR.transform.parent = robotLegR.transform;
            ankleJointR.transform.localPosition = new Vector3(0, -0.5f, 0);

            //Robot Foot Right
            robotFootR = new GameObject();
            robotFootR.name = "Foot Right";
            meshRenderer = robotFootR.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotFootR.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cube(0.5f);
            robotFootR.transform.parent = ankleJointR.transform;
            robotFootR.transform.localPosition = new Vector3(0, -0.25f, 0.12f);
            robotFootR.transform.localScale = new Vector3(0.5f, 0.5f, 0.75f);
            meshRenderer.material = material;


            //////////LEFT LEG//////////
            //Robot leg joint left
            legJointL = new GameObject();
            legJointL.name = "Leg Joint L";
            legJointL.transform.parent = robotBody.transform;
            legJointL.transform.localPosition = new Vector3(0.25f, -1, 0);

            //Robot leg left 
            robotLegL = new GameObject();
            robotLegL.name = "Leg Left";
            meshRenderer = robotLegL.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotLegL.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cube(0.5f); 
            robotLegL.transform.parent = legJointL.transform;
            robotLegL.transform.localPosition = new Vector3(0.25f, -0.75f, 0);
            robotLegL.transform.localScale = new Vector3(0.5f, 1.5f, 0.5f);
            meshRenderer.material = material;

            //Robot Ankle Left
            ankleJointL = new GameObject();
            ankleJointL.name = "Ankle Joint L";
            ankleJointL.transform.parent = robotLegL.transform;
            ankleJointL.transform.localPosition = new Vector3(0, -0.5f, 0);

            //Robot Foot Left
            robotFootL = new GameObject();
            robotFootL.name = "Foot Right";
            meshRenderer = robotFootL.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotFootL.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cube(0.5f);
            robotFootL.transform.parent = ankleJointL.transform;
            robotFootL.transform.localPosition = new Vector3(0, -0.25f, 0.12f);
            robotFootL.transform.localScale = new Vector3(0.5f, 0.5f, 0.75f);
            meshRenderer.material = material;


            //////////ROBOT NECK//////////
            //Neck
            robotNeck = new GameObject();
            robotNeck.name = "Robot Neck";
            meshRenderer = robotNeck.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotNeck.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cube(0.25f); 
            robotNeck.transform.parent = robotBody.transform;
            robotNeck.transform.localPosition = new Vector3(0, 1.125f, 0);
            robotNeck.transform.localScale = new Vector3(1, 0.5f, 1f);
            meshRenderer.material = material;

            //Neck Joint
            neckJoint = new GameObject();
            neckJoint.name = "Neck Joint";
            neckJoint.transform.parent = robotNeck.transform;
            neckJoint.transform.localPosition = new Vector3(0, 0.25f, 0);


            //////////ROBOT HEAD//////////
            robotHead = new GameObject();
            robotHead.name = "Robot Head";
            meshRenderer = robotHead.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotHead.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cube(0.75f); 
            robotHead.transform.parent = neckJoint.transform;
            robotHead.transform.localPosition = new Vector3(0, 0.75f, 0);
            meshRenderer.material = material;


            //////////ROBOT EARS//////////
            //Right
            robotEarR = new GameObject();
            robotEarR.name = "Robot Ear R";
            meshRenderer = robotEarR.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotEarR.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cube(0.25f); 
            robotEarR.transform.parent = robotHead.transform;
            robotEarR.transform.localPosition = new Vector3(-1, 0, 0);
            meshRenderer.material = material3;

            //R extension
            robotEarEtxR = new GameObject();
            robotEarEtxR.name = "Robot Ear Extension";
            meshRenderer = robotEarEtxR.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotEarEtxR.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cylinder(8,0.1f,0.1f); //(Density,Radius,Height)
            robotEarEtxR.transform.parent = robotEarR.transform;
            robotEarEtxR.transform.localPosition = new Vector3(-0.25f, 0, 0);
            robotEarEtxR.transform.localRotation = Quaternion.Euler(0, 0, -90);
            meshRenderer.material = material2
                ;
            //Left
            robotEarL = new GameObject();
            robotEarL.name = "Robot Ear L";
            meshRenderer = robotEarL.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotEarL.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cube(0.25f);
            robotEarL.transform.parent = robotHead.transform;
            robotEarL.transform.localPosition = new Vector3(1, 0, 0);
            meshRenderer.material = material3;
            
            //L extension
            robotEarEtxL = new GameObject();
            robotEarEtxL.name = "Robot Ear Extension";
            meshRenderer = robotEarEtxL.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotEarEtxL.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cylinder(8, 0.1f, 0.1f); //(Density,Radius,Height)
            robotEarEtxL.transform.parent = robotEarL.transform;
            robotEarEtxL.transform.localPosition = new Vector3(0.25f, 0, 0);
            robotEarEtxL.transform.localRotation = Quaternion.Euler(0, 0, -90);
            meshRenderer.material = material2;

            //////////Eyes//////////
            //Right
            robotEyeR = new GameObject();
            robotEyeR.name = "Robot Eye R";
            meshRenderer = robotEyeR.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotEyeR.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cylinder(8, 0.2f, 0.05f); //(Density,Radius,Height)
            robotEyeR.transform.parent = robotHead.transform;
            robotEyeR.transform.localPosition = new Vector3(-0.4f, 0.35f, 0.75f);
            robotEyeR.transform.localRotation = Quaternion.Euler(90, 0,0);
            meshRenderer.material = material3;

            //Left
            robotEyeL = new GameObject();
            robotEyeL.name = "Robot Eye L";
            meshRenderer = robotEyeL.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotEyeL.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Cylinder(8, 0.2f, 0.05f); //(Density,Radius,Height)
            robotEyeL.transform.parent = robotHead.transform;
            robotEyeL.transform.localPosition = new Vector3(0.4f, 0.35f, 0.75f);
            robotEyeL.transform.localRotation = Quaternion.Euler(90, 0, 0);
            meshRenderer.material = material3;

            //////////Antenna//////////
            robotAntenna = new GameObject();
            robotAntenna.name = "Robot Antenna";
            meshRenderer = robotAntenna.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotAntenna.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Pyramid(0.5f);
            robotAntenna.transform.parent = robotHead.transform;
            robotAntenna.transform.localPosition = new Vector3(0, 0.75f, 0);
            meshRenderer.material = material2;

            //////////Sweep//////////
            //Mouth
            Vector3[] sweepProfile = new Vector3[10];
            sweepProfile[0] = new Vector3(0.0f, -0.012f, 0.0f);
            sweepProfile[1] = new Vector3(0.014f, -0.0114f, 0.0f);
            sweepProfile[2] = new Vector3(0.04f, -0.01f, 0.0f);
            sweepProfile[3] = new Vector3(0.04f, 0.01f, 0.0f);
            sweepProfile[4] = new Vector3(0.014f, 0.0114f, 0.0f);

            sweepProfile[5] = new Vector3(0.0f, 0.012f, 0.0f);
            sweepProfile[6] = new Vector3(-0.014f, 0.0114f, 0.0f);
            sweepProfile[7] = new Vector3(-0.04f, 0.01f, 0.0f);
            sweepProfile[8] = new Vector3(-0.04f, -0.01f, 0.0f);
            sweepProfile[9] = new Vector3(-0.014f, -0.0114f, 0.0f);

            Matrix4x4[] sweepPath;

            //Hold the path instances
            sweepPath = new Matrix4x4[10];
            //create the first transform:
            sweepPath[0] = Matrix4x4.Scale(new Vector3(0, 0, 1)) * Matrix4x4.Translate(new Vector3(0, 0, -0.2f));
            //Adjust the scale for the next path instance
            sweepPath[1] = Matrix4x4.Translate(new Vector3(0, 0, -0.2f));

            //Adjust the position for the next path instances (default scale1) A robot smile :)
            sweepPath[2] = Matrix4x4.Translate(new Vector3(-0.1f, 0, -0.125f));
            sweepPath[3] = Matrix4x4.Translate(new Vector3(0.1f, 0, -0.05f));
            
            sweepPath[4] = Matrix4x4.Translate(new Vector3(-0.1f, 0, 0.05f));           
            sweepPath[5] = Matrix4x4.Translate(new Vector3(0.1f, 0, 0.125f));

            sweepPath[6] = Matrix4x4.Translate(new Vector3(-0.1f, 0, 0.205f));            
            sweepPath[7] = Matrix4x4.Translate(new Vector3(0, 0, 0.255f));

            sweepPath[8] = Matrix4x4.Translate(new Vector3(0, 0, 0.255f));          
            ////Finally the path instances for the other end cap
            sweepPath[9] = Matrix4x4.Scale(new Vector3(0, 0, 1)) * Matrix4x4.Translate(new Vector3(0, 0, 0.255f));


            robotMouth = new GameObject();
            robotMouth.name = "Robot Mouth";          
            meshRenderer = robotMouth.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
            meshFilter = robotMouth.AddComponent<MeshFilter>();
            meshFilter.mesh = MeshUtilities.Sweep(sweepProfile, sweepPath, false);
            meshRenderer.material = material3;

            robotMouth.transform.parent = robotHead.transform;
            robotMouth.transform.localPosition = new Vector3(0, -0.3f, 0.8f);
            robotMouth.transform.localRotation = Quaternion.Euler(-180, -90, 90);

        }
    }
}
