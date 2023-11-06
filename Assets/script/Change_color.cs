using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_color : MonoBehaviour
{
	GameObject GameManager;//Gamemanager読み込み
	GameManager gameManager;

	public GameObject normal; //オブジェクト読み込み
	public GameObject col; //オブジェクト読み込み

	void Start()
	{
		GameManager = GameObject.Find("GameManager");
		gameManager = GameManager.GetComponent<GameManager>(); // スクリプトを取得
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.name == "Yellow_Change")
		{
			GetComponent<Renderer>().material.color = Color.yellow;
			normal.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
			col.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
		}
		else if (other.gameObject.name == "Red_Change")
		{
			GetComponent<Renderer>().material.color = Color.red;
			normal.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
			col.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 255);
		}
		else if (other.gameObject.name == "Blue_Change")
		{
			GetComponent<Renderer>().material.color = Color.blue;
			normal.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
			col.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 255);
		}
	}
}

