using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_true : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("t"))
        {
            Debug.Log("true!");
            this.gameObject.SetActive(true);
        }
    }
}
