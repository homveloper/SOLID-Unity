using UnityEngine;
using System;

namespace SingleResponsibility
{
    [RequireComponent(typeof(SpaceShipInput))]
    public class SpaceShipEngine : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float turnSpeed;
        private float lastTrust = float.MinValue;
        private SpaceShipInput spaceShipInput;
        public event Action<float> ThrustChanged = delegate{};

        private void Awake() {
            spaceShipInput = GetComponent<SpaceShipInput>();
        }
        private void Update() {
            if(lastTrust != spaceShipInput.Vertical){
                ThrustChanged(spaceShipInput.Vertical);
            }

            lastTrust = spaceShipInput.Vertical;

            transform.position += transform.up * spaceShipInput.Vertical * moveSpeed * Time.deltaTime;
            transform.Rotate(-Vector3.forward * spaceShipInput.Horizontal * turnSpeed * Time.deltaTime);
        }   
    }
}