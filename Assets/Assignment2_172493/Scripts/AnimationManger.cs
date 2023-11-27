using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KIT307_172493
{
    public class AnimationManger : MonoBehaviour
    {
        //public Transform lamp;
        public Transform robot;
        public AnimationCurve curve;
        Animation anim;
        AnimationClip clipWave, clipWave2, clipWave3;
        float time;
        // Update is called once per frame

        // Start is called before the first frame update
        void Start()
        {
            anim = robot.gameObject.AddComponent<Animation>();

            ////Walk Anim
            clipWave = new AnimationClip();
            clipWave.legacy = true;

            //Walk Arm Left
            Keyframe[] keysWalkAL;
            keysWalkAL = new Keyframe[4];
            keysWalkAL[0] = new Keyframe(0.0f, 0.0f);
            keysWalkAL[1] = new Keyframe(0.5f, -40.0f);
            keysWalkAL[2] = new Keyframe(1.0f, 0.0f);
            keysWalkAL[3] = new Keyframe(1.5f, 40.0f);
            //keysWalkAL[4] = new Keyframe(4.0f, 0.0f);

            //Walk Arm Right
            Keyframe[] keysWalkAR;
            keysWalkAR = new Keyframe[4];
            keysWalkAR[0] = new Keyframe(0.0f, 0.0f);
            keysWalkAR[1] = new Keyframe(0.5f, 40.0f);
            keysWalkAR[2] = new Keyframe(1.0f, 0.0f);
            keysWalkAR[3] = new Keyframe(1.5f, -40.0f);
            //keysWalkAR[4] = new Keyframe(4.0f, 0.0f);

            //Walk Leg left
            Keyframe[] keysWalkL;
            keysWalkL = new Keyframe[4];
            keysWalkL[0] = new Keyframe(0.0f, 0.0f);
            keysWalkL[1] = new Keyframe(0.5f, 40.0f);
            keysWalkL[2] = new Keyframe(1.0f, 0.0f);
            keysWalkL[3] = new Keyframe(1.5f, -40.0f);
            //keysWalkL[4] = new Keyframe(4.0f, 0.0f);

            //Walk Leg right
            Keyframe[] keysWalkR;
            keysWalkR = new Keyframe[4];
            keysWalkR[0] = new Keyframe(0.0f, 0.0f);
            keysWalkR[1] = new Keyframe(0.5f, -40.0f);
            keysWalkR[2] = new Keyframe(1.0f, 0.0f);
            keysWalkR[3] = new Keyframe(1.5f, 40.0f);
            //keysWalkR[4] = new Keyframe(4.0f, 0.0f);

            AnimationCurve curveArrayWalkAL = new AnimationCurve(keysWalkAL);
            clipWave.SetCurve("Robot Body/Arm Joint L", typeof(Transform), "localEulerAngles.x", curveArrayWalkAL);
            clipWave.wrapMode = WrapMode.Loop;

            AnimationCurve curveArrayWalkAR = new AnimationCurve(keysWalkAR);
            clipWave.SetCurve("Robot Body/Arm Joint R", typeof(Transform), "localEulerAngles.x", curveArrayWalkAR);
            clipWave.wrapMode = WrapMode.Loop;

            AnimationCurve curveArrayWalkL = new AnimationCurve(keysWalkL);
            clipWave.SetCurve("Robot Body/Leg Joint L", typeof(Transform), "localEulerAngles.x", curveArrayWalkL);
            clipWave.wrapMode = WrapMode.Loop;

            AnimationCurve curveArrayWalkR = new AnimationCurve(keysWalkR);
            clipWave.SetCurve("Robot Body/Leg Joint R", typeof(Transform), "localEulerAngles.x", curveArrayWalkR);
            clipWave.wrapMode = WrapMode.Loop;

            anim.AddClip(clipWave, "Robot Move");
            //anim.Play("Robot Move");

            ///////////////////////////////////////////////////
            //Flailing
            clipWave2 = new AnimationClip();
            clipWave2.legacy = true;

            //Walk Arm Left
            Keyframe[] keysFlailArmL;
            keysFlailArmL = new Keyframe[3];
            keysFlailArmL[0] = new Keyframe(0.0f, 120.0f);
            keysFlailArmL[1] = new Keyframe(1.0f, 90.0f);
            keysFlailArmL[2] = new Keyframe(2.0f, 120.0f);

            //Walk Arm Right
            Keyframe[] keysFlailArmR;
            keysFlailArmR = new Keyframe[3];
            keysFlailArmR[0] = new Keyframe(0.0f, -120.0f);
            keysFlailArmR[1] = new Keyframe(1.0f, -90.0f);
            keysFlailArmR[2] = new Keyframe(2.0f, -120.0f);


            //Walk Leg left
            Keyframe[] keysFlailLegL;
            keysFlailLegL = new Keyframe[3];
            keysFlailLegL[0] = new Keyframe(0.0f, 100.0f);
            keysFlailLegL[1] = new Keyframe(1.0f, 40.0f);
            keysFlailLegL[2] = new Keyframe(2.0f, 100.0f);


            //Walk Leg right
            Keyframe[] keysFlailLegR;
            keysFlailLegR = new Keyframe[3];
            keysFlailLegR[0] = new Keyframe(0.0f, -100.0f);
            keysFlailLegR[1] = new Keyframe(1.0f, -40.0f);
            keysFlailLegR[2] = new Keyframe(2.0f, -100.0f);

            AnimationCurve curveArrayFlailArmL = new AnimationCurve(keysFlailArmL);
            clipWave2.SetCurve("Robot Body/Arm Joint L", typeof(Transform), "localEulerAngles.z", curveArrayFlailArmL);
            clipWave2.wrapMode = WrapMode.PingPong;

            AnimationCurve curveArrayFlailArmR = new AnimationCurve(keysFlailArmR);
            clipWave2.SetCurve("Robot Body/Arm Joint R", typeof(Transform), "localEulerAngles.z", curveArrayFlailArmR);
            clipWave2.wrapMode = WrapMode.PingPong;

            AnimationCurve curveArrayFlailLegL = new AnimationCurve(keysFlailLegL);
            clipWave2.SetCurve("Robot Body/Leg Joint L", typeof(Transform), "localEulerAngles.z", curveArrayFlailLegL);
            clipWave2.wrapMode = WrapMode.PingPong;

            AnimationCurve curveArraFlailLegR = new AnimationCurve(keysFlailLegR);
            clipWave2.SetCurve("Robot Body/Leg Joint R", typeof(Transform), "localEulerAngles.z", curveArraFlailLegR);
            clipWave2.wrapMode = WrapMode.PingPong;

            anim.AddClip(clipWave2, "Robot Flail");

            //////////////////////////////////////////////////////////////////////////
            //Look at Camera and Wave      
            clipWave3 = new AnimationClip();
            clipWave3.legacy = true;

            //Walk Arm Left
            Keyframe[] keysWaveL;
            keysWaveL = new Keyframe[3];
            keysWaveL[0] = new Keyframe(0.0f, 110.0f);
            keysWaveL[1] = new Keyframe(0.5f, 80.0f);
            keysWaveL[2] = new Keyframe(1.0f, 110.0f);

            //Walk Arm Right
            Keyframe[] keysWaveR;
            keysWaveR = new Keyframe[3];
            keysWaveR[0] = new Keyframe(0.0f, -110.0f);
            keysWaveR[1] = new Keyframe(0.5f, -80.0f);
            keysWaveR[2] = new Keyframe(1.0f, -110.0f);

            //Walk Leg left
            Keyframe[] keysWaveLL;
            keysWaveLL = new Keyframe[1];
            keysWaveLL[0] = new Keyframe(0.0f, 0.0f);

            //Walk Leg right
            Keyframe[] keysWaveLR;
            keysWaveLR = new Keyframe[1];
            keysWaveLR[0] = new Keyframe(0.0f, 0.0f);          

            AnimationCurve curveArrayWaveL = new AnimationCurve(keysWaveL);
            clipWave3.SetCurve("Robot Body/Arm Joint L", typeof(Transform), "localEulerAngles.z", curveArrayWaveL);
            clipWave3.wrapMode = WrapMode.Loop;

            AnimationCurve curveArrayWaveR = new AnimationCurve(keysWaveR);
            clipWave3.SetCurve("Robot Body/Arm Joint R", typeof(Transform), "localEulerAngles.z", curveArrayWaveR);
            clipWave3.wrapMode = WrapMode.Loop;

            AnimationCurve curveArrayWaveLL = new AnimationCurve(keysWaveLL);
            clipWave3.SetCurve("Robot Body/Leg Joint L", typeof(Transform), "localEulerAngles.x", curveArrayWaveLL);
            clipWave3.wrapMode = WrapMode.Once;

            AnimationCurve curveArrayWaveLR = new AnimationCurve(keysWaveLR);
            clipWave3.SetCurve("Robot Body/Leg Joint R", typeof(Transform), "localEulerAngles.x", curveArrayWaveLR);
            clipWave3.wrapMode = WrapMode.Once;

            anim.AddClip(clipWave3, "Robot Wave");
        }

        void Update()
        {
            time = Time.fixedTime;
            animationSwitch();

            ////lamp.localPosition = new Vector3(0, curve.Evaluate(Time.time), 0);
            //Transform head = robot.Find("Lamp Base/Base Joint/Elbow Joint/Shade Joint");
            //head.LookAt(Camera.main.transform);
        }

        void animationSwitch()
        {
            if (time <= 27.0f)
            {
                anim.Play("Robot Flail");
            }

            if (time > 27.0f && time <= 39.0f)
            {
                anim.Play("Robot Move");
            }
            if (time > 39.0f)
            {
                anim.Play("Robot Wave");

                robot.LookAt(Camera.main.transform);
            }
            if (time > 42.0f)
            {
                SceneManager.LoadScene("Credits");
            }
        }
    }
}

