using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_color : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Change_Red"))
        {
            this.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
            Debug.Log("Change_Red");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}