using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace KIT307_172493
{
    public class CubeExplosion : MonoBehaviour
    {
        [Header("Cube Dimensions")]
        public float cubeSize = 0.2f;
        public int cubesInRow = 5;
        public Material material;
        //public AudioSource audioSource;
        //public AudioClip clip;

        float cubeBreakPoints;
        Vector3 cubesBreak;

        [Header("Explosion Properties")]
        public float expForce = 50f;
        public float expRadius = 4f;
        public float expVertical = 0.4f;

        void Start()
        {
            cubeBreakPoints = cubeSize * cubesInRow / 2;
            cubesBreak = new Vector3(cubeBreakPoints, cubeBreakPoints, cubeBreakPoints);
            //audioSource = gameObject.GetComponent<AudioSource>();
        }       
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "MyRobot")
            {
                //Debug.Log("collision");
                //audioSource.Play();
                explode();
            }
        }

        public void explode()
        {
            gameObject.SetActive(false);

            for (int x = 0; x < cubesInRow; x++)
            {
                for (int y = 0; y < cubesInRow; y++)
                {
                    for (int z = 0; z < cubesInRow; z++)
                    {
                        createPiece(x, y, z);
                    }
                }
            }

            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, expRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(expForce, transform.position, expRadius, expVertical);
                }
            }

        }
        void createPiece(int x, int y, int z)
        {
            GameObject piece;
            piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
            piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesBreak;
            piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
            piece.AddComponent<Rigidbody>();
            piece.GetComponent<Rigidbody>().mass = cubeSize;
            MeshRenderer meshRenderer = piece.GetComponent<MeshRenderer>();
            meshRenderer.material = material;
            Destroy(piece, 5.0f);
        }
    }
}

