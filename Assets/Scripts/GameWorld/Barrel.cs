using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : DamageTaker
{
    [SerializeField] float _explotionRange;
    public override void Destruct()
    {
        base.Destruct();
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explotionRange, WeaponManager.Instance.Shootable);
        foreach (var item in colliders)
        {
            if (item.TryGetComponent(out Stone stone))
            {
                stone.Destruct();
            }
        }
    }
}
