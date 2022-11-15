using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMove : MonoBehaviour
{
    [SerializeField] float _speed, _range;

    void Update()
    {
        transform.localPosition = new Vector3(Mathf.Sin(Time.time * _speed) * _range, transform.localPosition.y, transform.localPosition.z);
    }
}
