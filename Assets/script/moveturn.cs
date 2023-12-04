using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、スプライトが移動する
public class moveturn : MonoBehaviour
{
	private Controller controller_;//Xboxコントローラーが受け付けるように変数として定義

	GameObject GameManager;//Gamemanager読み込み
	GameManager gameManager;

	public GameObject TurnManagar; //オブジェクト読み込み
	public TurnManager turnmanager ; //オブジェクト読み込み
	public GameObject enemy; //オブジェクト読み込み
	public enemymove enemymove;
	public GameObject enemyhantei; //オブジェクト読み込み
	public GameObject enemy2; //オブジェクト読み込み
	public enemymove enemymove2;
	public GameObject enemyhantei2; //オブジェクト読み込み
	public GameObject enemy3; //オブジェクト読み込み
	public enemymove enemymove3;
	public GameObject enemyhantei3; //オブジェクト読み込み
								   //public float speed = 2; // スピード：Inspectorで指定

	public bool playerTurn;

	public float PPreX;
	public float PPreZ;
	public bool up = true;
	public bool down = true;
	public bool right = true;
	public bool left = true;
	public bool sousaR = false;
	public bool sousaL = false;
	public bool sousaU = false;
	public bool sousaD = false;

	private Vector3 latestPos;  //前回のPosition

	//float dph = Input.GetAxis("D_Pad_H");
	//float dpv = Input.GetAxis("D_Pad_V");

	void Start()
	{
		controller_ = new Controller();
		playerTurn = true;
		GameManager = GameObject.Find("GameManager");
		gameManager = GameManager.GetComponent<GameManager>(); // スクリプトを取得
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
	}

	/*IEnumerator MoveCoroutine()
	{
		//ここに処理を書く
		Debug.Log("うごいてる!");

		//1フレーム停止
		yield return new WaitForSeconds(1.0f);

		//ここに再開後の処理を書く
		playerTurn = false;
	}*/
	/*
	IEnumerator ZahyouCoroutine()
	{
		//ここに処理を書く
		//Debug.Log("修正中");
		PPreX = Mathf.Floor(this.transform.position.x);
		PPreZ = Mathf.Floor(this.transform.position.z);

		//1フレーム停止
		yield return new WaitForSeconds(0.0f);

		//ここに再開後の処理を書く
		Debug.Log("完了");
		Debug.Log(Mathf.Floor(PPreX) + " " + this.transform.position.y + " " + Mathf.Floor(PPreZ));
		transform.position = new Vector3(Mathf.Floor(PPreX), this.transform.position.y, Mathf.Floor(PPreZ));
		//playerTurn = false;
	}
	*/

	
	IEnumerator XZahyouCoroutine()
	{
		//ここに処理を書く
		//Debug.Log("修正中");

		//1フレーム停止
		yield return new WaitForSeconds(0.0f);

		//ここに再開後の処理を書く
		Debug.Log("完了");
		Debug.Log(Mathf.Floor(this.transform.position.x) + " " + this.transform.position.y + " " + Mathf.Floor(PPreZ));
		transform.position = new Vector3(Mathf.Floor(this.transform.position.x), this.transform.position.y, PPreZ);
		playerTurn = false;
		PPreX = this.transform.position.x;
	}

	IEnumerator ZZahyouCoroutine()
	{
		//ここに処理を書く
		//Debug.Log("修正中");

		//1フレーム停止
		yield return new WaitForSeconds(0.0f);

		//ここに再開後の処理を書く
		//Debug.Log("完了");
		Debug.Log(Mathf.Floor(PPreX) + " " + this.transform.position.y + " " + Mathf.Floor(this.transform.position.z));
		transform.position = new Vector3(PPreX, this.transform.position.y, Mathf.Floor(this.transform.position.z));
		playerTurn = false;
	}

	IEnumerator PosKakuteiCoroutine()
	{
		//ここに処理を書く
		//Debug.Log("修正中");

		//1フレーム停止
		yield return new WaitForSeconds(0.5f);

		//ここに再開後の処理を書く
		PPreX = Mathf.Floor(this.transform.position.x);
		PPreZ = Mathf.Floor(this.transform.position.z);
	}

	void Update()
	{ // ずっと行う
		Transform PLtransform = this.transform;//transformを取得
		Vector3 pos = PLtransform.position;
		Vector3 worldAngle = PLtransform.eulerAngles;// ワールド座標を基準に、回転を取得
		latestPos = transform.position;  //前回のPositionの更新
		var PLx = this.transform.position.x;
		var PLz = this.transform.position.z;
		PLtransform.position = pos;  // 座標を設定
		float dph = Input.GetAxis("D_Pad_H");
		float dpv = Input.GetAxis("D_Pad_V");

		if (playerTurn)
		{
			/*
			if ((dph > 0 || Input.GetKey("d")) && right == true && PLx - PPreX < 1)
			{ // もし、右キーが押されたら
				PLtransform.position += new Vector3(1, 0, 0) * Time.deltaTime;
				worldAngle.y = 45.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				PLtransform.eulerAngles = worldAngle; // 回転角度を設定
				up = false;
				down = false;
			}
			else if (dph < 0 && left == true && PPreX - PLx < 0.9)
			{ // もし、左キーが押されたら
				PLtransform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
				worldAngle.y = -135.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				PLtransform.eulerAngles = worldAngle; // 回転角度を設定
				up = false;
				down = false;
			}
			else if (dpv > 0 && up == true && PLz - PPreZ < 1)
			{ // もし、上キーが押されたら
				PLtransform.position += new Vector3(0, 0, 1) * Time.deltaTime;
				worldAngle.y = -45.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				PLtransform.eulerAngles = worldAngle; // 回転角度を設定
													  //StartCoroutine("MoveCoroutine");
				Debug.Log("今:" + PLz + " " + "前:" + PPreZ);
				right = false;
				left = false;
			}
			else if (dpv < 0 && down == true && PPreZ - PLz < 0.9)
			{ // もし、下キーが押されたら
				PLtransform.position += new Vector3(0, 0, -1) * Time.deltaTime;
				worldAngle.y = 135.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				PLtransform.eulerAngles = worldAngle; // 回転角度を設定
				Debug.Log("今:" + PLz + " " + "前:" + PPreZ);
				right = false;
				left = false;
			}
			*/
			if ((dph > 0 || Input.GetKey("d")) && sousaR == false)
            {
				sousaR = true;
				worldAngle.y = 45.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				PLtransform.eulerAngles = worldAngle; // 回転角度を設定
			}
			else if (sousaR && PLx - PPreX < 1)
            {
				PLtransform.position += new Vector3(1, 0, 0) * Time.deltaTime;
			}
			else if ((dph < 0 || Input.GetKey("a")) && sousaL == false)
			{
				sousaL = true;
				worldAngle.y = -135.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				PLtransform.eulerAngles = worldAngle; // 回転角度を設定
			}
			else if (sousaL && PPreX - PLx < 0.9)
			{
				PLtransform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
			}
			else if ((dpv> 0 || Input.GetKey("w")) && sousaU == false)
			{
				sousaU = true;
				worldAngle.y = -45.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				PLtransform.eulerAngles = worldAngle; // 回転角度を設定
			}
			else if (sousaU && PLz - PPreZ < 1)
			{
				PLtransform.position += new Vector3(0, 0, 1) * Time.deltaTime;
			}
			else if ((dpv < 0 || Input.GetKey("s")) && sousaD == false)
			{
				sousaD = true;
				worldAngle.y = 135.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				PLtransform.eulerAngles = worldAngle; // 回転角度を設定
			}
			else if (sousaD && PPreZ - PLz < 0.9)
			{
				PLtransform.position += new Vector3(0, 0, -1) * Time.deltaTime;
			}
			else if(PPreX - PLx > 0.8 || PLx - PPreX > 1 || PPreZ - PLz > 0.8 || PLz - PPreZ > 1)
            {
				playerTurn = false;
			}
		}
		else if (playerTurn == false)
        {
			playerTurn = false;
			up = true;
			down = true;
			right = true;
			left = true;
			sousaR = false;
			sousaL = false;
			sousaU = false;
			sousaD = false;
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

	}
}
