using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Melee,
    Ranged
}

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon/Dafault")]
public class WeaponSO : ToolSO
{
    public WeaponType weaponType;

    public override void Use(Resource resource)
    {
        
    }

    protected virtual void Attack(WildAnimal animal)
    {
        
    }
}
