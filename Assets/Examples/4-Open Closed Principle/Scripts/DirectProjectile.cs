using UnityEngine;

namespace OpenClosedPrinciple
{
    public class DirectProjectile : Projectile {
        public void SetForce(Vector3 force){
            GetComponent<Rigidbody2D>().AddForce(force);
        }
    }
}