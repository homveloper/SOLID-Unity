using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SingleResponsibility
{
    public class SpaceShipParticle : MonoBehaviour
    {
        [SerializeField] private GameObject thrusterParticle;
        [SerializeField] private GameObject destoryParticle;

        // Start is called before the first frame update

        private void Awake()
        {
            GetComponent<SpaceShipEngine>().ThrustChanged += ThrustChanged;

            SpaceShipHealth spaceShipHealth;

            if(TryGetComponent<SpaceShipHealth>(out spaceShipHealth)){
                spaceShipHealth.OnDie += Destroyed;
            }
        }

        private void ThrustChanged(float thrust)
        {
            thrusterParticle.SetActive(thrust > 0f);
        }

        private void Destroyed()
        {
            Instantiate(destoryParticle, transform.position, Quaternion.identity);
        }
    }

}