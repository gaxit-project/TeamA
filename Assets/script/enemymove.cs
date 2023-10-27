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
	public bool up = true;
	public bool down = true;
	public bool right = true;
	public bool left = true;
	private Vector3 latestPos;  //前回のPosition

	public float PreX;
	public float PreZ;

	void Start()
	{
	
	}

	IEnumerator EMoveCoroutine()
	{
		//ここに処理を書く
		//Debug.Log("敵がうごいてる!");

		//1フレーム停止
		yield return new WaitForSeconds(1.5f);

		//ここに再開後の処理を書く
		transform.position = new Vector3(Mathf.Floor(this.transform.position.x), 0, Mathf.Floor(this.transform.position.z));
		moveturn.playerTurn = true;
		PreX = this.transform.position.x;
		PreZ = this.transform.position.z;
	}

	IEnumerator ManyEnemyCoroutine()
	{
		//ここに処理を書く
		//Debug.Log("敵がうごいてる!");

		//1フレーム停止
		yield return new WaitForSeconds(0.1f);

		//ここに再開後の処理を書く
		transform.position = new Vector3(Mathf.Floor(this.transform.position.x), 0, Mathf.Floor(this.transform.position.z));
		moveturn.playerTurn = true;
		PreX = this.transform.position.x;
		PreZ = this.transform.position.z;
	}

	/*public void Reposition()
    {
		Debug.Log("敵がうごいてる!");
		ENx / Mathf.Floor = PreX;
		moveturn.playerTurn = true;
		PreX = this.transform.position.x;

	}*/

	void Update()
	{ // ずっと行う
		player = GameObject.Find("player"); //Updataで使うのでオブジェクト読み込み
		moveturn = player.GetComponent<moveturn>(); //同様にスクリプトも読み込み

		Transform ENtransform = this.transform;//transformを取得
		Vector3 pos = ENtransform.position;
		Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
		latestPos = transform.position;  //前回のPositionの更新
		ENtransform.position = pos;  // 座標を設定

		var PLx = player.transform.position.x;
		var PLz = player.transform.position.z;
		var ENx = this.transform.position.x;
		var ENz = this.transform.position.z;

		if (moveturn.playerTurn == false)
		{
			//Debug.Log(moveturn.transform.position + "a");
			//Debug.Log("(" + PLx + "." + PLz + ")" + " " + "(" + ENx + "." + ENz + ")");
			//ENtransform.position += new Vector3(1, 0, 0) * Time.deltaTime;
			//StartCoroutine("EMoveCoroutine");
			if (Mathf.Floor(moveturn.PPreX) < Mathf.Floor(ENx) && left == true)//左
			{
				ENtransform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
				//Debug.Log(ENx + " " + PreX);
				StartCoroutine("EMoveCoroutine");
				up = false;
				down = false;
				right = false;

			}
			else if (Mathf.Floor(moveturn.PPreX) > Mathf.Floor(ENx) && right == true)//右
			{
				ENtransform.position += new Vector3(1, 0, 0) * Time.deltaTime;
				//Debug.Log(ENx + " " + PreX);
				StartCoroutine("EMoveCoroutine");
				up = false;
				down = false;
				left = false;
			}
			else if (Mathf.Floor(moveturn.PPreX) == Mathf.Floor(PreX))
			{
				if (moveturn.PPreZ < ENz && down == true)//下
				{
					ENtransform.position += new Vector3(0, 0, -1) * Time.deltaTime;
					Debug.Log(ENz + " " + PreZ);
					StartCoroutine("EMoveCoroutine");
					up = false;
					right = false;
					left = false;
				}
				else if (moveturn.PPreZ > ENz && up == true)//上
				{
					ENtransform.position += new Vector3(0, 0, 1) * Time.deltaTime;
					//Debug.Log(ENz + " " + PreZ);
					StartCoroutine("EMoveCoroutine");
					down = false;
					right = false;
					left = false;
				}
			}

			if (Mathf.Floor(Mathf.Abs(PreX)) > Mathf.Floor(Mathf.Abs(ENx)))
			{
				if (Mathf.Abs(PreX) - Mathf.Abs(ENx) > 0.9)
				{
					Debug.Log("a");
					moveturn.playerTurn = true;
					//StartCoroutine("ManyEnemyCoroutine");
					PreX = this.transform.position.x;
				}
			}
			else if (Mathf.Floor(Mathf.Abs(PreX)) < Mathf.Floor(Mathf.Abs(ENx)))
			{
				if (Mathf.Abs(ENx) - Mathf.Abs(PreX) > 1.15)
				{
					Debug.Log("a");
					moveturn.playerTurn = true;
					//StartCoroutine("ManyEnemyCoroutine");
					PreX = this.transform.position.x;
				}
			}
			else if (Mathf.Floor(moveturn.PPreX) == Mathf.Floor(PreX))
			{
				if (PreZ > ENz)
				{
					if (PreZ - ENz > 0.8)
					{
						Debug.Log("a");
						moveturn.playerTurn = true;
						//StartCoroutine("ManyEnemyCoroutine");
						PreZ = this.transform.position.z;
					}
				}
				else if (PreZ < ENz)
				{
					if (ENz - PreZ > 1)
					{
						Debug.Log("a");
						moveturn.playerTurn = true;
						//StartCoroutine("ManyEnemyCoroutine");
						PreZ = this.transform.position.z;
					}
				}
			}
		}
		else if (moveturn.playerTurn == true)
		{
			StopCoroutine("EMoveCoroutine");
			transform.position = new Vector3(Mathf.Floor(PreX), 0, Mathf.Floor(PreZ));
			moveturn.playerTurn = true;
			//PreX = this.transform.position.x;
			//PreZ = this.transform.position.z;
			up = true;
			down = true;
			right = true;
			left = true;
		}

		if (diff.magnitude > 0.01f)
		{
			transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
		}

	}
	void FixedUpdate()
	{ // ずっと行う（一定時間ごとに）
	  // 移動する
	  // this.GetComponent<SpriteRenderer>().flipX = leftFlag;
	}
}
