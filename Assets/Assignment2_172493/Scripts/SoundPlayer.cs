using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KIT307_172493
{   
    public class SoundPlayer : MonoBehaviour
    {
        public AudioSource audioSource;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "MyRobot")
            {
                //Debug.Log("Sound Play");
                audioSource.Play();
            }
        }
    }

}
