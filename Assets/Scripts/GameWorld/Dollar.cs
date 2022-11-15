using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dollar : DropObject, ICollectable
{
    public void Collect()
    {
        gameObject.SetActive(false);
        GameManager.Instance.DollarEnabling();
    }
}
