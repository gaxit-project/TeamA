using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、スプライトが移動する
public class enemymove : MonoBehaviour
{
	public GameObject TurnManagar; //オブジェクト読み込み
	public TurnManager turnmanager; //オブジェクト読み込み
	public GameObject player; //オブジェクト読み込み
	public GameObject Hantei; //オブジェクト読み込み
	public moveturn moveturn; //スクリプト読み込み
	public GameObject JunkaiCube; //巡回の際、行ってほしい座標に置くオブジェクト
	public float speed = 2; // スピード：Inspectorで指定

	public bool enemyTurn;
	public bool sakuteki = false;//プレイヤーを見つけたかどうか
	public bool junkai;//プレイヤーを見つけたかどうか true:junkaiCubeまで行く false:座標(fromX, fromZ)まで戻る
	public bool up = true;
	public bool down = true;
	public bool right = true;
	public bool left = true;
	private Vector3 latestPos;  //前回のPosition

	public float PreX;
	public float PreZ;

	public float fromx;
	public float fromz;

	void Start()
	{
		enemyTurn = false;
		fromx = PreX;
		fromz = PreZ;
	}

	IEnumerator EMoveCoroutine()
	{
		//ここに処理を書く
		//Debug.Log("敵がうごいてる!");

		//1フレーム停止
		yield return new WaitForSeconds(1.5f);

		//ここに再開後の処理を書く
		transform.position = new Vector3(Mathf.Floor(this.transform.position.x), this.transform.position.y, Mathf.Floor(this.transform.position.z));
		enemyTurn = false;
		PreX = this.transform.position.x;
		PreZ = this.transform.position.z;
	}

	IEnumerator ESakutekiCoroutine()
	{
		//ここに処理を書く
		Transform ENtransform = this.transform;//transformを取得
		Vector3 worldAngle = ENtransform.eulerAngles;
		//Debug.Log("敵がうごいてる!");

		//1フレーム停止
		yield return new WaitForSeconds(1.0f);

		//ここに再開後の処理を書く
		worldAngle.y = worldAngle.y + 90.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
		ENtransform.eulerAngles = worldAngle; // 回転角度を設定
		transform.position = new Vector3(Mathf.Floor(this.transform.position.x), this.transform.position.y, Mathf.Floor(this.transform.position.z));
		enemyTurn = false;
		PreX = this.transform.position.x;
		PreZ = this.transform.position.z;
		Debug.Log("・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・");
	}

	void Update()
	{ // ずっと行う
		player = GameObject.Find("player"); //Updataで使うのでオブジェクト読み込み
		moveturn = player.GetComponent<moveturn>(); //同様にスクリプトも読み込み

		Transform ENtransform = this.transform;//transformを取得
		Vector3 pos = ENtransform.position;
		Vector3 worldAngle = ENtransform.eulerAngles;
		latestPos = transform.position;  //前回のPositionの更新
		ENtransform.position = pos;  // 座標を設定

		var PLx = player.transform.position.x;
		var PLz = player.transform.position.z;
		var ENx = this.transform.position.x;
		var ENz = this.transform.position.z;

		if (enemyTurn == true && sakuteki == false && junkai == false)
        {
			if(fromx == ENx && fromz == ENz)
            {
				Debug.Log("監視中!");
				StartCoroutine("ESakutekiCoroutine");
				junkai = true;
			}
			else if (fromx == ENx && fromz == ENz)
			{
				//Debug.Log("監視中!");
				StartCoroutine("ESakutekiCoroutine");
				junkai = true;
			}
			if (Mathf.Floor(fromx) < Mathf.Floor(ENx) && left == true && Mathf.Abs(PreX) - Mathf.Abs(ENx) < 0.9)//左
			{
				ENtransform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
				worldAngle.y = -90.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				ENtransform.eulerAngles = worldAngle; // 回転角度を設定
				Debug.Log(ENx + " " + PreX);
				StartCoroutine("EMoveCoroutine");
				StopCoroutine("ESakutekiCoroutine");
				up = false;
				down = false;
				right = false;

			}
			else if (Mathf.Floor(fromx) > Mathf.Floor(ENx) && right == true && Mathf.Abs(ENx) - Mathf.Abs(PreX) < 1.15)//右
			{
				ENtransform.position += new Vector3(1, 0, 0) * Time.deltaTime;
				worldAngle.y = 90.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				ENtransform.eulerAngles = worldAngle; // 回転角度を設定
				Debug.Log(ENx + " " + PreX);
				StartCoroutine("EMoveCoroutine");
				StopCoroutine("ESakutekiCoroutine");
				up = false;
				down = false;
				left = false;
			}
			else if (Mathf.Floor(fromx) == Mathf.Floor(PreX))
			{
				if (fromz < ENz && down == true && PreZ - ENz < 0.9)//下
				{
					ENtransform.position += new Vector3(0, 0, -1) * Time.deltaTime;
					worldAngle.y = 180.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
					ENtransform.eulerAngles = worldAngle; // 回転角度を設定
					Debug.Log(ENz + " " + PreZ);
					StartCoroutine("EMoveCoroutine");
					StopCoroutine("ESakutekiCoroutine");
					up = false;
					right = false;
					left = false;
				}
				else if (fromz > ENz && up == true && ENz - PreZ < 1)//上
				{
					ENtransform.position += new Vector3(0, 0, 1) * Time.deltaTime;
					worldAngle.y = 0.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
					ENtransform.eulerAngles = worldAngle; // 回転角度を設定
					Debug.Log(ENz + " " + PreZ);
					StartCoroutine("EMoveCoroutine");
					StopCoroutine("ESakutekiCoroutine");
					down = false;
					right = false;
					left = false;
				}
			}
			else if (Mathf.Abs(PreX) - Mathf.Abs(ENx) > 0.9 || Mathf.Abs(ENx) - Mathf.Abs(PreX) > 1.15 || PreZ - ENz > 0.9 || ENz - PreZ > 1)
			{
				enemyTurn = false;
			}
		}
		else if (enemyTurn && junkai == true && sakuteki == false)
        {
			Debug.Log("巡回中");
			if (JunkaiCube.transform.position.x == ENx && JunkaiCube.transform.position.z == ENz)
			{
				Debug.Log("索敵中");
				junkai = false;
				StartCoroutine("ESakutekiCoroutine");
			}
			if (Mathf.Floor(JunkaiCube.transform.position.x) < Mathf.Floor(ENx) && left == true && Mathf.Abs(PreX) - Mathf.Abs(ENx) < 0.9)//左
			{
				ENtransform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
				worldAngle.y = -90.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				ENtransform.eulerAngles = worldAngle; // 回転角度を設定
				Debug.Log(ENx + " " + PreX);
				StartCoroutine("EMoveCoroutine");
				StopCoroutine("ESakutekiCoroutine");
				up = false;
				down = false;
				right = false;
			}
			else if (Mathf.Floor(JunkaiCube.transform.position.x) > Mathf.Floor(ENx) && right == true && Mathf.Abs(ENx) - Mathf.Abs(PreX) < 1.15)//右
			{
				ENtransform.position += new Vector3(1, 0, 0) * Time.deltaTime;
				worldAngle.y = 90.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				ENtransform.eulerAngles = worldAngle; // 回転角度を設定
				Debug.Log(ENx + " " + PreX);
				StartCoroutine("EMoveCoroutine");
				StopCoroutine("ESakutekiCoroutine");
				up = false;
				down = false;
				left = false;
			}
			else if (Mathf.Floor(JunkaiCube.transform.position.x) == Mathf.Floor(PreX))
			{
				if (JunkaiCube.transform.position.z < ENz && down == true && PreZ - ENz < 0.9)//下
				{
					ENtransform.position += new Vector3(0, 0, -1) * Time.deltaTime;
					worldAngle.y = 180.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
					ENtransform.eulerAngles = worldAngle; // 回転角度を設定
					Debug.Log(ENz + " " + PreZ);
					StartCoroutine("EMoveCoroutine");
					StopCoroutine("ESakutekiCoroutine");
					up = false;
					right = false;
					left = false;
				}
				else if (JunkaiCube.transform.position.z > ENz && up == true && ENz - PreZ < 1)//上
				{
					ENtransform.position += new Vector3(0, 0, 1) * Time.deltaTime;
					worldAngle.y = 0.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
					ENtransform.eulerAngles = worldAngle; // 回転角度を設定
					Debug.Log(ENz + " " + PreZ);
					StartCoroutine("EMoveCoroutine");
					StopCoroutine("ESakutekiCoroutine");
					down = false;
					right = false;
					left = false;
				}
			}
			else if (Mathf.Abs(PreX) - Mathf.Abs(ENx) > 0.9 || Mathf.Abs(ENx) - Mathf.Abs(PreX) > 1.15 || PreZ - ENz > 0.9 || ENz - PreZ > 1)
			{
				enemyTurn = false;
			}
		}
		else if (enemyTurn == true && sakuteki == true)
		{
			if (Mathf.Floor(moveturn.PPreX) < Mathf.Floor(ENx) && left == true && Mathf.Abs(PreX) - Mathf.Abs(ENx) < 0.9)//左
			{
				ENtransform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
				worldAngle.y = -90.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				ENtransform.eulerAngles = worldAngle; // 回転角度を設定
				Debug.Log(ENx + " " + PreX);
				StartCoroutine("EMoveCoroutine");
				up = false;
				down = false;
				right = false;

			}
			else if (Mathf.Floor(moveturn.PPreX) > Mathf.Floor(ENx) && right == true && Mathf.Abs(ENx) - Mathf.Abs(PreX) < 1.15)//右
			{
				ENtransform.position += new Vector3(1, 0, 0) * Time.deltaTime;
				worldAngle.y = 90.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
				ENtransform.eulerAngles = worldAngle; // 回転角度を設定
				Debug.Log(ENx + " " + PreX);
				StartCoroutine("EMoveCoroutine");
				up = false;
				down = false;
				left = false;
			}
			else if (Mathf.Floor(moveturn.PPreX) == Mathf.Floor(PreX))
			{
				if (moveturn.PPreZ < ENz && down == true && PreZ - ENz < 0.9)//下
				{
					ENtransform.position += new Vector3(0, 0, -1) * Time.deltaTime;
					worldAngle.y = 180.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
					ENtransform.eulerAngles = worldAngle; // 回転角度を設定
					Debug.Log(ENz + " " + PreZ);
					StartCoroutine("EMoveCoroutine");
					up = false;
					right = false;
					left = false;
				}
				else if (moveturn.PPreZ > ENz && up == true && ENz - PreZ < 1)//上
				{
					ENtransform.position += new Vector3(0, 0, 1) * Time.deltaTime;
					worldAngle.y = 0.0f; // ワールド座標を基準にy軸を軸にした回転を指定した角度に変更
					ENtransform.eulerAngles = worldAngle; // 回転角度を設定
					Debug.Log(ENz + " " + PreZ);
					StartCoroutine("EMoveCoroutine");
					down = false;
					right = false;
					left = false;
				}
			}
			else if (Mathf.Abs(PreX) - Mathf.Abs(ENx) > 0.9 || Mathf.Abs(ENx) - Mathf.Abs(PreX) > 1.15 || PreZ - ENz > 0.9 || ENz - PreZ > 1)
            {
				enemyTurn = false;
			}
		}
		else if (enemyTurn == false)
		{
			up = true;
			down = true;
			right = true;
			left = true;
		}

	}
	void FixedUpdate()
	{ // ずっと行う（一定時間ごとに）

	}
}
