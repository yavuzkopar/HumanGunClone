using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamFoolowPlayer : MonoBehaviour
{
    public Transform camTarget;
    public Vector3 dist;
    public float speed;
    public Transform lookTarget;
    private void LateUpdate()
    {
        Vector3 dPos = camTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, speed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);

    }
}

