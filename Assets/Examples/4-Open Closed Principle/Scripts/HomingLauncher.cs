using UnityEngine;

namespace OpenClosedPrinciple
{
    public class HomingLauncher : MonoBehaviour, ILauncher
    {
        [SerializeField] private HomingProjectile prefab;

        public void Launch(ProjectileWeapon projectileWeapon)
        {
            Instantiate(prefab,
                        projectileWeapon.transform.position, 
                        Quaternion.identity)
                        .SetTarget(FindObjectOfType<Target>().transform);
        }
    }

}