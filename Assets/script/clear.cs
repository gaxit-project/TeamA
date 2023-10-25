using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject item = GameObject.FindWithTag("Goal");
        Debug.Log(item.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            FadeManager.Instance.LoadScene("GameClear", 2.0f);
        }
    }
}