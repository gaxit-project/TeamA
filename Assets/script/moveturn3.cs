using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// キーを押すと、スプライトが移動する
public class moveturn3 : MonoBehaviour
{
    private Controller controller_;//Xboxコントローラーが受け付けるように変数として定義

    GameObject GameManager;//Gamemanager読み込み
    GameManager gameManager;

    public GameObject TurnManagar; //オブジェクト読み込み
    public TurnManager3 turnmanager; //オブジェクト読み込み
    public GameObject enemy; //オブジェクト読み込み
    public enemymove3 enemymove;
    public GameObject enemyhantei; //オブジェクト読み込み
    public GameObject enemy2; //オブジェクト読み込み
    public enemymove3 enemymove2;
    public GameObject enemyhantei2; //オブジェクト読み込み
    public GameObject enemy3; //オブジェクト読み込み
    public enemymove3 enemymove3;
    public GameObject enemyhantei3; //オブジェクト読み込み
                                    //public float speed = 2; // スピード：Inspectorで指定

    public bool playerTurn;

    public float PPreX;
    public float PPreZ;
    public bool up = true;
    public bool down = true;
    public bool right = true;
    public bool left = true;
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
        //PPreX = Mathf.Floor(this.transform.position.x);

        //1フレーム停止
        yield return new WaitForSeconds(0.0f);

        //ここに再開後の処理を書く
        Debug.Log("完了");
        Debug.Log(Mathf.Floor(this.transform.position.x) + " " + this.transform.position.y + " " + Mathf.Floor(PPreZ));
        transform.position = new Vector3(Mathf.Floor(this.transform.position.x), this.transform.position.y, PPreZ);
        playerTurn = false;
        //StartCoroutine("PosKakuteiCoroutine");
        PPreX = this.transform.position.x;
    }

    IEnumerator ZZahyouCoroutine()
    {
        //ここに処理を書く
        //Debug.Log("修正中");
        //PPreZ = Mathf.Floor(this.transform.position.z);

        //1フレーム停止
        yield return new WaitForSeconds(0.0f);

        //ここに再開後の処理を書く
        //Debug.Log("完了");
        Debug.Log(Mathf.Floor(PPreX) + " " + this.transform.position.y + " " + Mathf.Floor(this.transform.position.z));
        transform.position = new Vector3(PPreX, this.transform.position.y, Mathf.Floor(this.transform.position.z));
        playerTurn = false;
        //StartCoroutine("PosKakuteiCoroutine");
        //PPreZ = this.transform.position.z;
    }

    /*IEnumerator PosKakuteiCoroutine()
    {
        //ここに処理を書く
        //Debug.Log("修正中");

        //1フレーム停止
        yield return new WaitForSeconds(0.5f);

        //ここに再開後の処理を書く
        PPreX = Mathf.Floor(this.transform.position.x);
        PPreZ = Mathf.Floor(this.transform.position.z);
        //pl
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Yellow")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            Debug.Log("Enter SafeZone");
        }
        else if (other.gameObject.name == "Red")
        {
            GetComponent<Renderer>().material.color = Color.red;
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            Debug.Log("Enter SafeZone");
        }
        else if (other.gameObject.name == "Blue")
        {
            GetComponent<Renderer>().material.color = Color.blue;
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            Debug.Log("Enter SafeZone");
        }
        else if (other.gameObject.name == "Hantei")
        {
            Debug.Log("見つかった!");
            enemymove.sakuteki = true;
            enemyhantei.SetActive(false);   // 無効にする
        }
        else if (other.gameObject.name == "Hantei2")
        {
            Debug.Log("見つかった!");
            enemymove2.sakuteki = true;
            enemyhantei2.SetActive(false);   // 無効にする
        }
        else if (other.gameObject.name == "Hantei3")
        {
            Debug.Log("見つかった!");
            enemymove3.sakuteki = true;
            enemyhantei3.SetActive(false);   // 無効にする
        }
        else if (other.gameObject.name == "OutZone" && other.gameObject.name != "Blue" && other.gameObject.name != "Red" && other.gameObject.name != "Yellow")
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene("GameOver3");
        }
        else if (other.gameObject.name == "ClearObject")
        {
            Debug.Log("GameClear");
            SceneManager.LoadScene("GameClear3");
        }
    }*/

    void Update()
    { // ずっと行う
        Transform PLtransform = this.transform;//transformを取得
        Vector3 pos = PLtransform.position;
        Vector3 worldAngle = PLtransform.eulerAngles;// ワールド座標を基準に、回転を取得
        latestPos = transform.position;  //前回のPositionの更新
        var PLx = this.transform.position.x;
        var PLz = this.transform.position.z;
        PLtransform.position = pos;  // 座標を設定
                                     //Vector3 posi = this.transform.position;//ローカル座標(moveturnがアタッチされているオブジェクトの座標)を取得
        float dph = Input.GetAxis("D_Pad_H");
        float dpv = Input.GetAxis("D_Pad_V");

        //var gamepad = xbo.current;

        if (playerTurn)
        {
            //Debug.Log("行くぜ！");
            //Debug.Log(playerTurn);
            if (dph > 0 && right == true && PLx - PPreX < 1)
            { // もし、右キーが押されたら
                PLtransform.position += new Vector3(1, 0, 0) * Time.deltaTime;
                //Debug.Log("今:" + PLx + " " + "前:" + PPreX);
                //StartCoroutine("MoveCoroutine");
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
                                                      //Debug.Log("今:" + PLx + " " + "前:" + PPreX);
                                                      //StartCoroutine("MoveCoroutine");
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
                                                      //StartCoroutine("MoveCoroutine");
                Debug.Log("今:" + PLz + " " + "前:" + PPreZ);
                right = false;
                left = false;
            }
            else if (PPreX - PLx > 0.8 || PLx - PPreX > 1 || PPreZ - PLz > 0.8 || PLz - PPreZ > 1)
            {
                playerTurn = false;
            }

            /*
			if (PPreX > PLx && PPreX - PLx > 0.8)//左行った後
            {
				//PPreX = PLx;
				//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
				playerTurn = false;
				//StartCoroutine("XZahyouCoroutine");
			}
			else if (PPreX < PLx && PLx - PPreX > 1)//右行った後
			{
				//PPreX = PLx;
				//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
				playerTurn = false;
				//StartCoroutine("XZahyouCoroutine");
			}

			if (playerTurn && PPreZ > PLz && PPreZ - PLz > 0.8)//下行った後
			{
				//PPreZ = PLz;
				//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
				playerTurn = false;
				Debug.Log("ぬ");
				//StartCoroutine("ZZahyouCoroutine");
				//PPreX = this.transform.position.x;
				//PPreZ = this.transform.position.z;
			}
			else if (PPreZ < PLz && PLz - PPreZ > 1)//上行った後
			{
				//PPreZ = PLz;
				//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
				playerTurn = false;
				//StartCoroutine("ZZahyouCoroutine");
				//PPreX = this.transform.position.x;
				//PPreZ = this.transform.position.z;
			}*/
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
            //Debug.Log(playerTurn);
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
    void FixedUpdate()
    { // ずっと行う（一定時間ごとに）
      // 移動する
      // this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }
}
