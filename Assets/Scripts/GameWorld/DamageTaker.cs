using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DamageTaker : MonoBehaviour, IDamagealbe
{
    [SerializeField] int _health;
    TextMesh _textMesh;
    DropObject _dropObject;
    protected void Start()
    {
        _textMesh = GetComponentInChildren<TextMesh>();
        _textMesh.text = _health.ToString();
        _dropObject = GetComponentInChildren<DropObject>();
    }
    public void TakeDamage(int amount)
    {
        _health -= amount;
        _textMesh.text = _health.ToString();
        transform.DOShakeScale(.2f);
        if (_health <= 0)
        {
            Destruct();
        }
    }
    public virtual void Destruct()
    {
        if (_dropObject != null)
            _dropObject.Drop();
        Destroy(gameObject);


    }
}
