using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KIT307_172493
{    public class TorusSystem : MonoBehaviour
    {
        [Header("Items required")]
        public TorusGenerator torusPrefab;
        private TorusGenerator[] tori;

        [Header("Number of Pipes")]
        public int numPipes;

        // Start is called before the first frame update
        void Awake()
        {
            tori = new TorusGenerator[numPipes];
            for (int i = 0; i < tori.Length; i++)
            {
                //Torus curTorus = torus[i];
                TorusGenerator curTorus = tori[i] = Instantiate<TorusGenerator>(torusPrefab);
                curTorus.transform.SetParent(transform, false);
                if (i > 0)
                {
                    curTorus.AlignPipes(tori[i - 1]);
                }
            }
        }

        // Update is called once per frame  
        void Update()
        {

        }
    }

}
