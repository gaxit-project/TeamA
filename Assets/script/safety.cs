using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        gameManager = GameManager.GetComponent<GameManager>(); // スクリプトを取得
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Yellow" && node.gameObject.name == "Yellow_Playerr") //黄色に触れて、かつ自分も黄色のとき
        {
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            //Debug.Log("Enter SafeZone");
        }
        else if (other.gameObject.name == "Red" && node.gameObject.name == "Red_Player") //赤色に触れて、かつ自分も赤色のとき
        {
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            //Debug.Log("Enter SafeZone");
        }
        else if (other.gameObject.name == "Blue" && node.gameObject.name == "Blue_Player") //青色に触れて、かつ自分も青色のとき
        {
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            //Debug.Log("Enter SafeZone");
        }
        else if (other.gameObject.name == "Hantei")
        {
            //Debug.Log("見つかった!");
            enemymove.sakuteki = true;
            enemyhantei.SetActive(false);   // 無効にする
        }
        else if (other.gameObject.name == "Hantei2")
        {
            //Debug.Log("見つかった!");
            enemymove2.sakuteki = true;
            enemyhantei2.SetActive(false);   // 無効にする
        }
        else if (other.gameObject.name == "Hantei3")
        {
            //Debug.Log("見つかった!");
            enemymove3.sakuteki = true;
            enemyhantei3.SetActive(false);   // 無効にする
        }
    }
}
