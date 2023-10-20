using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clear : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject item = GameObject.FindWithTag("Goal");
        Debug.Log(item.name);
        if (collision.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene("GameClear");
        }
    }
}