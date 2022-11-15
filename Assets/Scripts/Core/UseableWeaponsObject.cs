
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponList", menuName = "Custon/Weapon List")]
public class UseableWeaponsObject : ScriptableObject
{
    [SerializeField] private List<Weapon> _weapons;
    public List<Weapon> Weapons { get { return _weapons; } set { _weapons = value; } }
}

