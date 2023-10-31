using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、スプライトが移動する
public class Change_color : MonoBehaviour
{
	GameObject GameManager;//Gamemanager読み込み
	GameManager gameManager;

	public GameObject normal; //オブジェクト読み込み
	public GameObject col; //オブジェクト読み込み
	private Vector3 latestPos;  //前回のPosition

	void Start()
	{
		GameManager = GameObject.Find("GameManager");
		gameManager = GameManager.GetComponent<GameManager>(); // スクリプトを取得
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.name == "Yellow")
		{
			GetComponent<Renderer>().material.color = Color.yellow;
			normal.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
			col.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
		}
		else if (other.gameObject.name == "Red")
		{
			GetComponent<Renderer>().material.color = Color.red;
			normal.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
			col.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 255);
		}
		else if (other.gameObject.name == "Blue")
		{
			GetComponent<Renderer>().material.color = Color.blue;
			normal.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
			col.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 255);
		}
	}
}

/*	void Update()
	{ // ずっと行う
		Transform PLtransform = this.transform;//transformを取得
		Vector3 pos = PLtransform.position;
		Vector3 worldAngle = PLtransform.eulerAngles;// ワールド座標を基準に、回転を取得
		latestPos = transform.position;  //前回のPositionの更新
		var PLx = this.transform.position.x;
		var PLz = this.transform.position.z;
		PLtransform.position = pos;  // 座標を設定
									 //Vector3 posi = this.transform.position;//ローカル座標(moveturnがアタッチされているオブジェクトの座標)を取得
*/
		
	/*	if (playerTurn)
		{
			//Debug.Log("行くぜ！");
			//Debug.Log(playerTurn);
			if (Input.GetKey("d") && right == true)
			{ // もし、右キーが押されたら
				PLtransform.position += new Vector3(1, 0, 0) * Time.deltaTime;
				Debug.Log("今:" + PLx + " " + "前:" + PPreX);
				//StartCoroutine("MoveCoroutine");
				worldAngle.y = 45.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				PLtransform.eulerAngles = worldAngle; // 回転角度を設定
				up = false;
				down = false;
			}
			if (Input.GetKey("a") && left == true)
			{ // もし、左キーが押されたら
				PLtransform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
				worldAngle.y = -135.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				PLtransform.eulerAngles = worldAngle; // 回転角度を設定
				Debug.Log("今:" + PLx + " " + "前:" + PPreX);
				//StartCoroutine("MoveCoroutine");
				up = false;
				down = false;
			}
			if (Input.GetKey("w") && up == true)
			{ // もし、上キーが押されたら
				PLtransform.position += new Vector3(0, 0, 1) * Time.deltaTime;
				worldAngle.y = -45.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				PLtransform.eulerAngles = worldAngle; // 回転角度を設定
													  //StartCoroutine("MoveCoroutine");
				Debug.Log("今:" + PLz + " " + "前:" + PPreZ);
				right = false;
				left = false;
			}
			if (Input.GetKey("s") && down == true)
			{ // もし、下キーが押されたら
				PLtransform.position += new Vector3(0, 0, -1) * Time.deltaTime;
				worldAngle.y = 135.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				PLtransform.eulerAngles = worldAngle; // 回転角度を設定
													  //StartCoroutine("MoveCoroutine");
				Debug.Log("今:" + PLz + " " + "前:" + PPreZ);
				right = false;
				left = false;
			}

			if (PPreX > PLx && PPreX - PLx > 0.95)//左行った後
            {
				//PPreX = PLx;
				//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
				playerTurn = false;
				StartCoroutine("XZahyouCoroutine");
			}
			else if (PPreX < PLx && PLx - PPreX > 1)//右行った後
			{
				//PPreX = PLx;
				//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
				playerTurn = false;
				StartCoroutine("XZahyouCoroutine");
			}

			if (PPreZ > PLz && PPreZ - PLz > 0.95)//下行った後
			{
				//PPreZ = PLz;
				//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
				playerTurn = false;
				StartCoroutine("ZZahyouCoroutine");
				//PPreX = this.transform.position.x;
				//PPreZ = this.transform.position.z;
			}
			else if (PPreZ < PLz && PLz - PPreZ > 1)//上行った後
			{
				//PPreZ = PLz;
				//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
				playerTurn = false;
				StartCoroutine("ZZahyouCoroutine");
				//PPreX = this.transform.position.x;
				//PPreZ = this.transform.position.z;
			}
		}
		else if (playerTurn == false)
        {
			//PPreX = Mathf.Floor(PLx);
			//PPreZ = Mathf.Floor(PLz);
			//StartCoroutine("ZahyouCoroutine");
			//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
			//Debug.Log("a" + Mathf.Floor(PLx) + " " + Mathf.Floor(PLz));
			//Debug.Log("止まったよ");
			playerTurn = false;
			Debug.Log(playerTurn);
			up = true;
			down = true;
			right = true;
			left = true;
			//gameManager.CallInoperable(0.5f); // 2 秒間　このスクリプトを無効に
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

} :*/

