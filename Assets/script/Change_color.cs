using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_color : MonoBehaviour
{
	GameObject GameManager;//Gamemanager読み込み
	GameManager gameManager;

    public GameObject node; //オブジェクト読み込み

    public Material Red;
	public Material Blue;
	public Material Yellow;
	public Material Normal;


    void Start()
	{
		GameManager = GameObject.Find("GameManager");
		gameManager = GameManager.GetComponent<GameManager>(); // スクリプトを取得
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.name == "Yellow_Change")
		{
            node.GetComponent<Renderer>().material = Yellow;
			gameObject.name = "Yellow_Player";
		}
		else if (other.gameObject.name == "Red_Change")
		{
            node.GetComponent<Renderer>().material = Red;
			gameObject.name = "Red_Player";
		}
		else if (other.gameObject.name == "Blue_Change")
		{
            node.GetComponent<Renderer>().material = Blue;
			gameObject.name = "Blue_Player";
		}
		else if (other.gameObject.name == "Normal_Change")
		{
            node.GetComponent<Renderer>().material = Normal;
            gameObject.name = "Normal_Player";

        }
	}
}

