using UnityEngine;

public class Piyon : MonoBehaviour, ICollectable
{
    public Animator Animator => _animator;

    private Animator _animator;
    private SkinnedMeshRenderer _skinnedMeshRenderer;
    Collider _collider;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        _collider = GetComponent<Collider>();
    }
    public void ChangeColor(Color color)
    {
        _skinnedMeshRenderer.material.color = color;
    }

    public void Collect()
    {
        WeaponManager.Instance.AddChild(this);
        _collider.enabled = false;
    }
}

