using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponSlot[] Slots => _slots;
    public float WeaponRange { get; private set; }
    public int Damage { get; private set; }

    [HideInInspector] public Weapon target;
    [HideInInspector] public Weapon previousWeapon;

    [Header("Requirements")]
    [SerializeField] private WeaponSlot[] _slots;
    [SerializeField] Transform _bulletParent;
    [SerializeField] Bullet _bulletPrefab;

    [Header("Weapon Stats")]
    [SerializeField] float _attackSpeed = 1f;
    [SerializeField] int _damage;
    [SerializeField] float _weaponRange;

    readonly List<Bullet> bullets = new List<Bullet>();
    int _bulletIndex;
    float _timer;
    Animator _animator;
    Collider _collider;

    //Setup
    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab, _bulletParent);
            bullet.transform.localPosition = Vector3.zero;
            bullet.transform.localRotation = Quaternion.identity;
            bullet.weapon = this;
            bullets.Add(bullet);
        }
        _timer = 1;
        Damage = _damage + GameManager.Instance.DamageModifier;
        WeaponRange = _weaponRange + GameManager.Instance.WeaponRangeModifier;
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
        _bulletIndex = 0;
    }
    private void Update()
    {
        _timer -= Time.deltaTime * _attackSpeed;
    }

    public void Shoot()
    {
        if (_timer > 0) return;
        _timer = 1;

        // object pool
        if (_bulletIndex >= 10)
            _bulletIndex = 0;
        bullets[_bulletIndex].gameObject.SetActive(true);
        _bulletIndex++;
        _animator.SetTrigger("attack");

    }
    public void EnableCollider(bool value)
    {
        _collider.enabled = value;
    }

}

