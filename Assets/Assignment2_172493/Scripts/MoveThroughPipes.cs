using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KIT307_172493
{
    public class MoveThroughPipes : MonoBehaviour
    {
        public Transform[] transforms;
        public float speed = 1;
        public Animator animator;
        Transform nextPos;
        int nextPosIndex;

        public float spinDuration = 10f;
        public float targetSpin = 3600f;
        float initSpin = 100f;
        float initSpeed = 100f;
        float acceleration = 5f;
        float startRotTime = 0f;

        private void Start()
        {
            nextPos = transforms[0];
        }
        private void Update()
        {
            moveObject();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "ExplodingCube")
            {
                CalcInitSpeedingConditions();
                startRotTime = Time.time;
                initSpin = transform.localEulerAngles.y;
                StartCoroutine(Rotate());
                speed = speed - 3;
            }
            //if (other.gameObject.name == "CameraTrigger")
            //{
            //    animator.Play("CM vcam2");
            //}
        }
        void moveObject()
        {
            if (transform.position == nextPos.position)
            {
                nextPosIndex++;
                if (nextPosIndex >= transforms.Length)
                {
                    return;
                }
                nextPos = transforms[nextPosIndex];
            }
            else
            {
                Vector3 targetDirection = nextPos.position - transform.position;
                float singleStep = speed * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                Debug.DrawRay(transform.position, newDirection, Color.red);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }

        void CalcInitSpeedingConditions()
        {
            initSpeed = 2 * targetSpin / spinDuration;
            acceleration = -initSpeed / spinDuration;
        }
        float GetRotationByTime(float t) => initSpeed * t + acceleration * t * t / 2;

        IEnumerator Rotate()
        {
            float t = Time.time - startRotTime;
            while (t < spinDuration)
            {
                t = Time.time - startRotTime;
                GetRotationByTime(t);
                transform.localEulerAngles = Vector3.right * (initSpin + GetRotationByTime(t) % 360);
                yield return null;
            }
            transform.localEulerAngles = Vector3.right * (initSpin + GetRotationByTime(t) % 360);
        }
    }
}


