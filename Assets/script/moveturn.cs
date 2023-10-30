using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、スプライトが移動する
public class moveturn : MonoBehaviour
{
<<<<<<< HEAD

	public float speed = 2; // スピード：Inspectorで指定

=======
	GameObject GameManager;//Gamemanager読み込み
	GameManager gameManager;

	public GameObject enemy; //オブジェクト読み込み
	public enemymove enemymove;
	public float speed = 2; // スピード：Inspectorで指定

	public bool playerTurn;

	public float PPreX;
	public float PPreZ;
	public bool up = true;
	public bool down = true;
	public bool right = true;
	public bool left = true;
	private bool isNormal = false; //通常の床にいるかどうかのBool
	private Vector3 latestPos;  //前回のPosition

	void Start()
	{
		playerTurn = true;
		GameManager = GameObject.Find("GameManager");
		gameManager = GameManager.GetComponent<GameManager>(); // スクリプトを取得
	}

>>>>>>> 7a34e75a2f65191e311aff338a6971ab03dae4e0
	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
	}

<<<<<<< HEAD
	void Update()
	{ // ずっと行う
		if (Input.GetKey("d"))
		{ // もし、右キーが押されたら
			transform.position += speed * transform.right * Time.deltaTime;
		}
		if (Input.GetKey("a"))
		{ // もし、左キーが押されたら
			transform.position -= speed * transform.right * Time.deltaTime;
		}
		if (Input.GetKey("w"))
		{ // もし、上キーが押されたら
			transform.position += speed * transform.forward * Time.deltaTime;
		}
		if (Input.GetKey("s"))
		{ // もし、下キーが押されたら
			transform.position -= speed * transform.forward * Time.deltaTime;
		}
=======
	/*IEnumerator MoveCoroutine()
	{
		//ここに処理を書く
		Debug.Log("うごいてる!");

		//1フレーム停止
		yield return new WaitForSeconds(1.0f);

		//ここに再開後の処理を書く
		playerTurn = false;
	}*/

	IEnumerator ZahyouCoroutine()
	{
		//ここに処理を書く
		Debug.Log("修正中");

		//1フレーム停止
		yield return new WaitForSeconds(0.0f);

		//ここに再開後の処理を書く
		Debug.Log("完了");
		Debug.Log(Mathf.Floor(PPreX) + " " + this.transform.position.y + " " + Mathf.Floor(PPreZ));
		transform.position = new Vector3(Mathf.Floor(PPreX), this.transform.position.y, Mathf.Floor(PPreZ));
		//gameManager.CallInoperable(2.0f); // 2 秒間　このスクリプトを無効に
	}

		void OnTriggerEnter(Collider other) //通常床のゾーンに入った際の処理
	{
		// タグを比較
		if (other.gameObject.tag == "Normal")
		{
			// セーフフラグを外す
			isNormal = true;
			Debug.Log("Enter SafeZone");
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.name == "Yellow")
		{
			GetComponent<Renderer>().material.color = Color.yellow;
			isNormal = true;
			Debug.Log("Enter SafeZone");
		}
		else if (other.gameObject.name == "Red")
        {
			GetComponent<Renderer>().material.color = Color.red;
			isNormal = true;
			Debug.Log("Enter SafeZone");
		}
		else if (other.gameObject.name == "Blue")
		{
			GetComponent<Renderer>().material.color = Color.blue;
			isNormal = true;
			Debug.Log("Enter SafeZone");
		}
	}

	void Update()
	{ // ずっと行う
		Transform PLtransform = this.transform;//transformを取得
		Vector3 pos = PLtransform.position;
		Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
		latestPos = transform.position;  //前回のPositionの更新
		var PLx = this.transform.position.x;
		var PLz = this.transform.position.z;
		PLtransform.position = pos;  // 座標を設定
                                     //Vector3 posi = this.transform.position;//ローカル座標(moveturnがアタッチされているオブジェクトの座標)を取得

        if (isNormal)
        {
			//Debug.Log("");
		}
		
		if (playerTurn == true)
		{
			if (Input.GetKey("d") && right == true)
			{ // もし、右キーが押されたら
				PLtransform.position += new Vector3(1, 0, 0) * Time.deltaTime;
				//Debug.Log(PLx + " " + PPreX);
				//StartCoroutine("MoveCoroutine");
				up = false;
				down = false;
				left = false;
			}
			if (Input.GetKey("a") && left == true)
			{ // もし、左キーが押されたら
				PLtransform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
				//Debug.Log(PLx + " " + PPreX);
				//StartCoroutine("MoveCoroutine");
				up = false;
				down = false;
				right = false;
			}
			if (Input.GetKey("w") && up == true)
			{ // もし、上キーが押されたら
				PLtransform.position += new Vector3(0, 0, 1) * Time.deltaTime;
				//StartCoroutine("MoveCoroutine");
				//Debug.Log(PLz + " " + PPreZ);
				down = false;
				right = false;
				left = false;

			}
			if (Input.GetKey("s") && down == true)
			{ // もし、下キーが押されたら
				PLtransform.position += new Vector3(0, 0, -1) * Time.deltaTime;
				//StartCoroutine("MoveCoroutine");
				//Debug.Log(PLz + " " + PPreZ);
				up = false;
				right = false;
				left = false;
			}

			
			if(Mathf.Abs(PPreX) > Mathf.Abs(PLx))//左行った後
            {
				if (Mathf.Abs(PPreX) - Mathf.Abs(PLx) > 0.9)
				{
					PPreX = PLx;
					StartCoroutine("ZahyouCoroutine");
					playerTurn = false;
				}
			}
            else if (Mathf.Abs(PPreX) < Mathf.Abs(PLx))//右行った後
			{
				if (Mathf.Abs(PLx) - Mathf.Abs(PPreX) > 1)
				{
					PPreX = PLx;
					StartCoroutine("ZahyouCoroutine");
					playerTurn = false;
				}
			}

			if (PPreZ > PLz)//下行った後
			{
				if (Mathf.Abs(PPreZ) - Mathf.Abs(PLz) > 0.9)
				{
					PPreZ = PLz;
					StartCoroutine("ZahyouCoroutine");
					playerTurn = false;
					//PPreX = this.transform.position.x;
					//PPreZ = this.transform.position.z;
				}
			}
			else if (Mathf.Abs(PPreZ) < Mathf.Abs(PLz))//上行った後
			{
				if (Mathf.Abs(PLz) - Mathf.Abs(PPreZ) > 1)
				{
					PPreZ = PLz;
					StartCoroutine("ZahyouCoroutine");
					playerTurn = false;
					//PPreX = this.transform.position.x;
					//PPreZ = this.transform.position.z;
				}
			}

		}
		else if (playerTurn == false)
        {
			//PPreX = this.transform.position.x;
			//PPreZ = this.transform.position.z;
			//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
			Debug.Log("a" + Mathf.Floor(PLx) + " " + Mathf.Floor(PLz));
			up = true;
			down = true;
			right = true;
			left = true;
			//gameManager.CallInoperable(0.5f); // 2 秒間　このスクリプトを無効に
		}

		/*
		//ベクトルの大きさが0.01以上の時に向きを変える処理をする
		//＊＊＊挙動が変になるアクティブ禁止！！＊＊＊
		if (diff.magnitude > 0.01f)
		{
			transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
		}
		*/

>>>>>>> 7a34e75a2f65191e311aff338a6971ab03dae4e0
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
