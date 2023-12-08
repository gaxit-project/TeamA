using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class safety : MonoBehaviour
{
    GameObject GameManager;//Gamemanager読み込み
    GameManager gameManager;

    public GameObject node; //オブジェクト読み込み

    public GameObject enemy; //オブジェクト読み込み
    public enemymove enemymove;
    public GameObject enemyhantei; //オブジェクト読み込み
    public GameObject enemy2; //オブジェクト読み込み
    public enemymove enemymove2;
    public GameObject enemyhantei2; //オブジェクト読み込み
    public GameObject enemy3; //オブジェクト読み込み
    public enemymove enemymove3;
    public GameObject enemyhantei3; //オブジェクト読み込み
    BoxCollider boxCol; //20231116追加 プレイヤーのコライダー読み込み用の変数
    public int flag = 0; //20231116追加 コライダーの位置を変えたかのフラグ(flag = 0: 位置を変えていない状態、flag = 1:位置を変えている状態)

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        gameManager = GameManager.GetComponent<GameManager>(); // スクリプトを取得
        boxCol = GetComponent<BoxCollider>(); //20231116 コライダーのコンポーネントの取得
        boxCol.size = new Vector3((float)0.4, 1, (float)0.4);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Yellow" && node.gameObject.name == "Yellow_Player") //黄色に触れて、かつ自分も黄色のとき
        {
            /*if (flag == 0 && other.gameObject.name == "Hantei" && other.gameObject.name == "Hantei2" && other.gameObject.name == "Hantei3") // 位置をずらしていない状態かつ、敵の判定もある場合
            {
                boxCol.size = new Vector3((float)0.2, (float)0.1, (float)0.2);
            }*/
            boxCol.size = new Vector3((float)0.4, (float)0.1, (float)0.4);
            //boxCol.enabled = false;
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            //Debug.Log("Enter SafeZone");
            //flag = 1;
        }
        else if (other.gameObject.name == "Red" && node.gameObject.name == "Red_Player") //赤色に触れて、かつ自分も赤色のとき
        {
            /*if (flag == 0 && other.gameObject.name == "Hantei" && other.gameObject.name == "Hantei2" && other.gameObject.name == "Hantei3") // 位置をずらしていない状態かつ、敵の判定もある場合
            {
                boxCol.size = new Vector3((float)0.2, (float)0.1, (float)0.2);
            }*/
            boxCol.size = new Vector3((float)0.4, (float)0.1, (float)0.4);
            //boxCol.enabled = false;
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            //Debug.Log("Enter SafeZone");
            //flag = 1;
        }
        else if (other.gameObject.name == "Blue" && node.gameObject.name == "Blue_Player") //青色に触れて、かつ自分も青色のとき
        {
            /*if (flag == 0 && other.gameObject.name == "Hantei" && other.gameObject.name == "Hantei2" && other.gameObject.name == "Hantei3") // 位置をずらしていない状態かつ、敵の判定もある場合
            {
                boxCol.size = new Vector3((float)0.2, (float)0.1, (float)0.2);
            }*/
            boxCol.size = new Vector3((float)0.4, (float)0.1, (float)0.4);
            //boxCol.enabled = false;
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            Debug.Log("Enter SafeZone");
            //flag = 1;
        }


        if (other.gameObject.name == "Hantei")
        {
            /*if (flag == 1) // 位置をずらしている状態
            {
                boxCol.size = new Vector3((float)0.2, 1, (float)0.2);
            }*/
            //Debug.Log("見つかった!");
            enemymove.sakuteki = true;
            enemyhantei.SetActive(false);   // 無効にする
        }
        else if (other.gameObject.name == "Hantei2")
        {
            /*if (flag == 1) // 位置をずらしている状態
            {
                boxCol.size = new Vector3((float)0.2, 1, (float)0.2);
            }*/
            //Debug.Log("見つかった!");
            enemymove2.sakuteki = true;
            enemyhantei2.SetActive(false);   // 無効にする
        }
        else if (other.gameObject.name == "Hantei3")
        {
            /*if (flag == 1) // 位置をずらしている状態
            {
                boxCol.size = new Vector3((float)0.2, 1, (float)0.2);
            }*/
            //Debug.Log("見つかった!");
            enemymove3.sakuteki = true;
            enemyhantei3.SetActive(false);   // 無効にする
        }
        
    }



    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Red" || other.gameObject.name == "Blue" || other.gameObject.name == "Yellow")
        {
            boxCol.size = new Vector3((float)0.1, 1, (float)0.1);
            //boxCol.enabled = true;
            Debug.Log("exit");
        }

    }
}
