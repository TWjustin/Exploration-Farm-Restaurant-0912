using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Items/Weapon/Melee Weapon")]
public class MeleeWeaponSO : WeaponSO
{
    private void Awake()
    {
        weaponType = WeaponType.Melee;
    }
    
}
