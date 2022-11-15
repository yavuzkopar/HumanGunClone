using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DropObject : MonoBehaviour
{
    const float POS_Y = 0.8f;
    [SerializeField] float jumpPower = 1;

    public void Drop()
    {
        transform.SetParent(null);
        Vector3 targetPos = transform.position + Vector3.forward;
        targetPos.y = POS_Y;
        transform.DOJump(targetPos, jumpPower, 1, 1);
    }
}
