using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float runningSpeed;
    float touchXDelta = 0;

    float newX = 0;
    public float xSpeed;
    [SerializeField] float border;
    void Update()
    {
        InputCheck();
        Move();
    }

    private void Move()
    {
        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -border, border);

        Vector3 newPosition = new Vector3(newX,
              transform.position.y,
            transform.position.z + runningSpeed * Time.deltaTime);

        transform.position = newPosition;
    }

    private void InputCheck()
    {
        // for Mobile
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;

        }
        // for pc
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        else
            touchXDelta = 0;
    }
}


