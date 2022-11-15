using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    WeaponManager weaponManager;
    private void Start()
    {
        weaponManager = WeaponManager.Instance;
    }
    private void Update()
    {
        if (weaponManager.CurrentWeapon == null) return;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, weaponManager.CurrentWeapon.WeaponRange, weaponManager.Shootable))
        {
            weaponManager.CurrentWeapon.Shoot();
        }
    }
}
