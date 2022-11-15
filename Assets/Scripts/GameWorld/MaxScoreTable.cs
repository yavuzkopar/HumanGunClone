using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxScoreTable : MonoBehaviour
{
    public float MaxPoint
    {
        get
        {
            return PlayerPrefs.GetFloat("MaxPoint");
        }
        set
        {
            PlayerPrefs.SetFloat("MaxPoint", value);
        }
    }
    Transform _player;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(transform.position.x, transform.position.y, MaxPoint);
    }

    public void SetMaxPoint()
    {
        if (_player.position.z < MaxPoint) return;
        MaxPoint = _player.position.z;
    }
}
