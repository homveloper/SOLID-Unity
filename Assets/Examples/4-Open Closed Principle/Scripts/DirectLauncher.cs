using UnityEngine;

namespace OpenClosedPrinciple
{
    public class DirectLauncher : MonoBehaviour, ILauncher
    {
        [SerializeField] private DirectProjectile prefab;

        public void Launch(ProjectileWeapon projectileWeapon)
        {
            Instantiate(prefab, projectileWeapon.transform.position, Quaternion.identity).SetForce(projectileWeapon.transform.forward);
        }
    }

}