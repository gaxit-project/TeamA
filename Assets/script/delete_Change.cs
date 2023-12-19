using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_Change : MonoBehaviour
{
    GameObject GameManager;//Gamemanager読み込み
    GameManager gameManager;

    public Material Red;
    public Material Blue;
    public Material Yellow;
    public Material transparent;


    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        gameManager = GameManager.GetComponent<GameManager>(); // スクリプトを取得
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Yellow_Player")
        {
            GetComponent<Renderer>().material = transparent;
        }
        else if (other.gameObject.name == "Red_Player")
        {
            GetComponent<Renderer>().material = transparent;
        }
        else if (other.gameObject.name == "Blue_Player")
        {
            GetComponent<Renderer>().material = transparent;
        }
        else if (gameObject.name == "Yellow_Change")
        {
            GetComponent<Renderer>().material = Yellow;

        }
        else if (gameObject.name == "Red_Change")
        {
            GetComponent<Renderer>().material = Red;

        }
        else if (gameObject.name == "Blue_Change")
        {
            GetComponent<Renderer>().material = Blue;

        }
    }
}
