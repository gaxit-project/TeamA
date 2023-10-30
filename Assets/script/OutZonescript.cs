using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutZonescript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        var colliderTest = GetComponent<Collider>();//コライダーを消すためコライダーを定義

        if (other.gameObject.name == "playercube")
        {
            //GetComponent<Renderer>().material.color = Color.yellow;
            FadeManager.Instance.LoadScene("GameOver", 2.0f);
            Debug.Log("終わり！");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}