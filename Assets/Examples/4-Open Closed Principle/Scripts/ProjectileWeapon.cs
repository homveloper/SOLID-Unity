using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenClosedPrinciple
{

    public class ProjectileWeapon : MonoBehaviour
    {
        [SerializeField] private float firePerSecond = 1f;
        private float nextTime = 0f;

        private void Awake() {
            GetComponent<SpaceShipInput>().onPrimary += FireWeapon;
        }

        private bool CanFire()
        {
            return Time.time >= nextTime;
        }

        private void FireWeapon()
        {
            if(!CanFire()) return;

            nextTime = Time.time + firePerSecond;
            GetComponent<ILauncher>().Launch(this);
        }
    }

}