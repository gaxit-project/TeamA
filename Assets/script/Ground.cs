using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        //�{�[���ɂԂ������Ƃ�
        if (other.gameObject.tag == "player")
        {
            Debug.Log("�{�[���ɂԂ������I");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
