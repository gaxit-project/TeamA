using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_false: MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("f"))
        {
            Debug.Log("false!");
            this.gameObject.SetActive(false);
        }
    }
}
