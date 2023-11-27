using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KIT307_172493
{
    public class CinemachineSwitcher : MonoBehaviour
    {

        public Animator animator;
        // Start is called before the first frame update

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "CameraTrigger")
            {
                animator.Play("CM vcam2");
                //Debug.Log("CAM2");

            }
            if (other.gameObject.name == "CameraTrigger (1)")
            {
                animator.Play("CM vcam3");
                //Debug.Log("CAM3");

            }
        }

    }

}
