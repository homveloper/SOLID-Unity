using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traditional
{
    public class SpaceShip : MonoBehaviour
    {

        [SerializeField] private int health = 100;
        [SerializeField] private int maxHealth = 100;

        [SerializeField] private float moveSpeed;
        [SerializeField] private float turnSpeed;
        [SerializeField] private float fireForce;
        [SerializeField] private Rigidbody2D projectile;
        [SerializeField] private Transform weaponMountPosition;
        [SerializeField] private GameObject thrusterParticles;


        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health += value;

                if (health <= 0)
                {
                    Die();
                }
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            health = maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            FireWeapon();
            Move();
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            transform.position += transform.up * vertical * moveSpeed * Time.deltaTime;
            transform.Rotate(-Vector3.forward * horizontal * turnSpeed * Time.deltaTime);
        }

        private void FireWeapon()
        {
            if (Input.GetButtonDown("PrimaryFire"))
            {
                Rigidbody2D spawnedProjectile = Instantiate(projectile, weaponMountPosition.position, weaponMountPosition.rotation);
                spawnedProjectile.AddForce(spawnedProjectile.transform.up * fireForce);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Projectile projectile;

            if (other.collider.TryGetComponent<Projectile>(out projectile))
            {
                Debug.Log(projectile);
                TakeDamage(projectile.Damage);
                Destroy(projectile.gameObject);
            }
        }

        public void TakeDamage(int value)
        {
            Health -= value;
        }
    }
}
