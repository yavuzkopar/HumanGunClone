using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class WeaponManager : MonoBehaviour
{

    public List<Piyon> Children;// { get; private set; }
    public Weapon CurrentWeapon { get; private set; }
    public LayerMask Shootable;
    [SerializeField] Piyon _piyonPrefab;


    #region Setup
    public static WeaponManager Instance { get; private set; }
    [SerializeField] Piyon _firstPiyon;

    public List<Weapon> weapons = new List<Weapon>();
    private void Awake()
    {
        Instance = this;
        Children = new List<Piyon>();
        Children.Add(_firstPiyon);
        Setup();
    }

    private void Setup()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < GameManager.Instance.weaponsObject.Weapons.Count; i++)
        {
            Weapon weapon = Instantiate(GameManager.Instance.weaponsObject.Weapons[i], player);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
            weapons.Add(weapon);
        }
        for (int i = 0; i < weapons.Count - 1; i++)
        {
            weapons[i].target = weapons[i + 1];
        }
        for (int i = 1; i < weapons.Count; i++)
        {
            weapons[i].previousWeapon = weapons[i - 1];
        }
        weapons[0].previousWeapon = null;
        weapons[0].EnableCollider(true);
    }
    #endregion

    #region Adding
    public void AddMultiple(int amount)
    {
        if (CurrentWeapon == null) ChangeWeapon(weapons[0]);
        for (int i = 0; i < amount; i++)
        {
            Piyon piyon = Instantiate(_piyonPrefab);
            AddChild(piyon);
        }
    }
    public void AddChild(Piyon piyon)
    {
        if (CurrentWeapon == null) ChangeWeapon(weapons[0]);
        if (CurrentWeapon.target == null && Children.Count >= CurrentWeapon.Slots.Length) return;
        if (!Children.Contains(piyon))
        {
            Children.Add(piyon);

        }
        if (Children.Count > CurrentWeapon.Slots.Length)
        {
            ChangeWeapon(CurrentWeapon.target);
            return;
        }
        SetChild(piyon, CurrentWeapon);
    }
    #endregion

    #region Removing
    public void RemoveAll()
    {
        RemoveMultiple(Children.Count);
    }

    public void RemoveMultiple(int amount)
    {
        int a = Children.Count - amount;
        for (int i = Children.Count - 1; i >= a; i--)
        {

            if (Children.Count <= 0) return;
            if (i < 0) return;

            RemoveChild(Children[i]);
        }
    }

    private void RemoveChild(Piyon piyon)
    {
        Children.Remove(piyon);
        piyon.transform.DOLocalMove(Random.onUnitSphere, 0.5f).OnComplete(() => Destroy(piyon.gameObject));
        if (Children.Count <= 1 && !GameManager.Instance.IsGameOver)
        {
            GameManager.Instance.GameOver();
            return;
        }

        if (CurrentWeapon.previousWeapon == null) return;

        if (Children.Count <= CurrentWeapon.previousWeapon.Slots.Length)
        {
            ChangeWeapon(CurrentWeapon.previousWeapon);
        }
    }
    #endregion

    #region Changes
    private void ChangeWeapon(Weapon targetWeapon)
    {
        if (targetWeapon == null) return;

        for (int i = 0; i < Children.Count; i++)
        {

            Children[i].transform.SetParent(targetWeapon.Slots[i].transform);
            Children[i].transform.DOLocalMove(Vector3.zero, 0.5f);
            Children[i].transform.DOLocalRotateQuaternion(Quaternion.identity, 0.5f);
            Children[i].Animator.SetTrigger(targetWeapon.Slots[i].AnimTriggerName);
            Children[i].ChangeColor(targetWeapon.Slots[i].Color);
        }

        CurrentWeapon = targetWeapon;

    }
    private void SetChild(Piyon piyon, Weapon targetWeapon)
    {
        piyon.transform.SetParent(targetWeapon.Slots[Children.Count - 1].transform);
        piyon.transform.DOLocalMove(Vector3.zero, 0.5f);
        piyon.transform.DOLocalRotateQuaternion(Quaternion.identity, 0.5f);
        piyon.Animator.SetTrigger(targetWeapon.Slots[Children.Count - 1].AnimTriggerName);
        piyon.ChangeColor(targetWeapon.Slots[Children.Count - 1].Color);
    }
    #endregion

}

