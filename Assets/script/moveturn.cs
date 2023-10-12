using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、スプライトが移動する
public class moveturn : MonoBehaviour
{
	public GameObject enemy; //オブジェクト読み込み
	public enemymove enemymove;
	public float speed = 2; // スピード：Inspectorで指定

	public bool playerTurn;

	void Start()
	{
		playerTurn = true;

	}

	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
	}

	IEnumerator MoveCoroutine()
	{
		//ここに処理を書く
		Debug.Log("うごいてる!");

		//1フレーム停止
		yield return new WaitForSeconds(1.0f);

		//ここに再開後の処理を書く
		playerTurn = false;
	}

	void Update()
	{ // ずっと行う
		Vector3 pos = transform.position;

		if (playerTurn == true)
		{
			if (Input.GetKey("d"))
			{ // もし、右キーが押されたら
				transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
				Debug.Log("ikuo");
				StartCoroutine("MoveCoroutine");
			}
			if (Input.GetKey("a"))
			{ // もし、左キーが押されたら
				transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
				StartCoroutine("MoveCoroutine");
			}
			if (Input.GetKey("w"))
			{ // もし、上キーが押されたら
				transform.position += new Vector3(0, 0, 1) * Time.deltaTime;
				StartCoroutine("MoveCoroutine");
				
			}
			if (Input.GetKey("s"))
			{ // もし、下キーが押されたら
				transform.position += new Vector3(0, 0, -1) * Time.deltaTime;
				StartCoroutine("MoveCoroutine");
			}

		}

		
		if (Input.GetKey("escape"))
		{ // もし、下キーが押されたら
			Debug.Log("DON!");
			PauseGame();
		}
		if (Input.GetKey("backspace"))
		{ // もし、下キーが押されたら
			Debug.Log("Oh");
			ResumeGame();
		}
	}
	void FixedUpdate()
	{ // ずっと行う（一定時間ごとに）
	  // 移動する
	  // this.GetComponent<SpriteRenderer>().flipX = leftFlag;
	}
}
