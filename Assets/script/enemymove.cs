using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、スプライトが移動する
public class enemymove : MonoBehaviour
{
	public GameObject player; //オブジェクト読み込み
	public moveturn moveturn; //スクリプト読み込み
	public float speed = 2; // スピード：Inspectorで指定

	public bool playerTurn;

	void Start()
	{

	}

	IEnumerator EMoveCoroutine()
	{
		//ここに処理を書く
		Debug.Log("敵がうごいてる!");

		//1フレーム停止
		yield return new WaitForSeconds(1.0f);

		//ここに再開後の処理を書く
		moveturn.playerTurn = true;
	}

	void Update()
	{ // ずっと行う
		player = GameObject.Find("Kamereon"); //Updataで使うのでオブジェクト読み込み
		moveturn = player.GetComponent<moveturn>(); //同様にスクリプトも読み込み

		Vector3 pos = transform.position;
		
		if (moveturn.playerTurn == false)
		{
			Debug.Log("kitayo");
			transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
			StartCoroutine("EMoveCoroutine");
			//moveturn.playerTurn = true;

		}
	}
	void FixedUpdate()
	{ // ずっと行う（一定時間ごとに）
	  // 移動する
	  // this.GetComponent<SpriteRenderer>().flipX = leftFlag;
	}
}
