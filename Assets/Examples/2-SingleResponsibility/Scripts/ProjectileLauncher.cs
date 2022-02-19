using UnityEngine;

namespace SingleResponsibility
{
    public class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D projectilePrefab;
        [SerializeField] private Transform weaponMountPosition;
        [SerializeField] private float fireForce = 10f;

        private void Awake() {
            GetComponent<SpaceShipInput>().onPrimary += FireWeapon;
        }

        private void FireWeapon()
        {
            Rigidbody2D spawnedProjectile = Instantiate(projectilePrefab, weaponMountPosition.position, weaponMountPosition.rotation);
            spawnedProjectile.AddForce(spawnedProjectile.transform.up * fireForce);
        }

    }
}