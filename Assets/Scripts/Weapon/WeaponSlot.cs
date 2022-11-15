using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponSlot : MonoBehaviour
{
    public Color Color => _color;
    [SerializeField] private Color _color;

    public int AnimTriggerName { get; private set; }
    [SerializeField] string animName;

    private void Awake()
    {
        AnimTriggerName = Animator.StringToHash(animName);
    }
}
