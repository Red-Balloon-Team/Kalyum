using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasser : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;

    public void Attack()
    {
        
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
