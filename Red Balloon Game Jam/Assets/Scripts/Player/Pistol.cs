using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    // [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    // public void Attack() {
    //     GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, ActiveWeapon.Instance.transform.rotation);
    // }

    // public WeaponInfo GetWeaponInfo() {
    //     return weaponInfo;
    // }
}
