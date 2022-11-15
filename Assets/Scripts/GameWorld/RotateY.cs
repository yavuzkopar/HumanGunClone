using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateY : MonoBehaviour
{
    [SerializeField] float _speed;
    void Update()
    {
        transform.Rotate(Vector3.up, _speed * Time.deltaTime);
    }
}

