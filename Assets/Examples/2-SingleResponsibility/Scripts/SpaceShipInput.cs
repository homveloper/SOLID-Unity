using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace SingleResponsibility
{
    public class SpaceShipInput : MonoBehaviour
    {
        private float horizontal;
        private float vertical;
        private bool primaryInput;
        public event Action onPrimary = delegate { };

        public float Horizontal { get { return horizontal; } }
        public float Vertical { get { return vertical; } }
        public bool PrimaryFire { get { return primaryInput; } }

        // Update is called once per frame
        void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            if (Input.GetButtonDown("PrimaryFire"))
            {
                onPrimary();
            }
        }
    }
}