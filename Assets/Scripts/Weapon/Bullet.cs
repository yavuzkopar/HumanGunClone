using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [HideInInspector] public Weapon weapon;
    Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
        _rigidbody.velocity = Vector3.forward * speed;
        Invoke("DisableObject", 3f);
    }
    void DisableObject()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagealbe damagealbe))
        {
            damagealbe.TakeDamage(weapon.Damage);
            gameObject.SetActive(false);
        }

    }
}

