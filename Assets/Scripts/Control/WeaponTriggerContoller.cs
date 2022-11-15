using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTriggerContoller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICollectable collectable))
        {
            collectable.Collect();
        }
    }
}

