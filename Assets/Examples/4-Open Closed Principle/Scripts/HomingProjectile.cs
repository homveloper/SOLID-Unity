using UnityEngine;

namespace OpenClosedPrinciple
{
    public class HomingProjectile : Projectile
    {
        private Transform target;
        private Rigidbody2D rigidbody2D;

        [SerializeField] private float rotateSpeed = 200f;
        [SerializeField] private float speed = 5f;

        private void Awake() {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (target == null) return;

            Debug.Log(target);

            Vector2 direction = (target.position - transform.position).normalized;
            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rigidbody2D.angularVelocity = -rotateAmount * rotateSpeed;
            rigidbody2D.velocity = transform.up * speed;
        }
        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}