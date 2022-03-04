using UnityEngine;
using System;

namespace OpenClosedPrinciple
{
    public class SpaceShipHealth : MonoBehaviour
    {

        [SerializeField] private int health;
        [SerializeField] private int maxHealth;

        public event Action OnDie = delegate{};

        private void Awake() {
            health = maxHealth;
        }

        public int Health{
            get{
                return health;
            }

            set{
                health = value;

                if(health < 0)
                {
                    Die();
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Projectile projectile;

            if (other.collider.TryGetComponent<Projectile>(out projectile))
            {
                // Debug.Log(projectile);
                TakeDamage(projectile.Damage);
                // Destroy(projectile.gameObject);
            }
        }


        public void Die(){
            OnDie();
            Destroy(gameObject);
        }

        public void TakeDamage(int value){
            Health -= value;
        }
    }
}