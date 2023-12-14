using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public Text NowTurn;
    public GameObject player; //オブジェクト読み込み
    public moveturn moveturn; //スクリプト読み込み
    public GameObject enemy; //オブジェクト読み込み
    public enemymove enemymove;
    public GameObject enemy2; //オブジェクト読み込み
    public enemymove enemymove2;
    public GameObject enemy3; //オブジェクト読み込み
    public enemymove enemymove3;

    public bool PEnd;
    public bool EEnd;

    private int count;
    public bool OneCount;

    // Start is called before the first frame update

    IEnumerator EndPTCoroutine()
    {
        //ここに処理を書く
        //Debug.Log("修正中");


        //1フレーム停止
        yield return new WaitForSeconds(0.5f);

        //ここに再開後の処理を書く
        //Debug.Log("ターンエンド！");
        moveturn.PPreX = Mathf.Floor(player.transform.position.x);
        moveturn.PPreZ = Mathf.Floor(player.transform.position.z);
        player.transform.position = new Vector3(Mathf.Floor(moveturn.PPreX), player.transform.position.y, Mathf.Floor(moveturn.PPreZ));
        enemymove.enemyTurn = true;
        enemymove2.enemyTurn = true;
        enemymove3.enemyTurn = true;
        PEnd = false;
        EEnd = true;
        OneCount = true;
    }

    IEnumerator EndETCoroutine()
    {
        //ここに処理を書く
        Debug.Log("修正中");


        //1フレーム停止
        yield return new WaitForSeconds(0.5f);

        //ここに再開後の処理を書く
        //Debug.Log("ターンエンド！");
        enemymove.PreX = Mathf.Floor(enemy.transform.position.x);
        enemymove.PreZ = Mathf.Floor(enemy.transform.position.z);
        enemymove2.PreX = Mathf.Floor(enemy2.transform.position.x);
        enemymove2.PreZ = Mathf.Floor(enemy2.transform.position.z);
        enemymove3.PreX = Mathf.Floor(enemy3.transform.position.x);
        enemymove3.PreZ = Mathf.Floor(enemy3.transform.position.z);
        
        enemy.transform.position = new Vector3(Mathf.Floor(enemymove.PreX), enemymove.transform.position.y, Mathf.Floor(enemymove.PreZ));
        enemy2.transform.position = new Vector3(Mathf.Floor(enemymove2.PreX), enemymove.transform.position.y, Mathf.Floor(enemymove2.PreZ));
        enemy3.transform.position = new Vector3(Mathf.Floor(enemymove3.PreX), enemymove.transform.position.y, Mathf.Floor(enemymove3.PreZ));
        
        moveturn.playerTurn = true;
        PEnd = true;
        EEnd = false;
        //Debug.Log("いいですと");
    }

    public void CountTurn()
    {
        OneCount = false;
        count++;
        Debug.Log(count);
        NowTurn.text = "現在のターン数 : " + count.ToString();

    }

    void Start()
    {
       PEnd = true;
       EEnd = false;
        count = 0;
        OneCount = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveturn.playerTurn == false && PEnd)
        {
            Debug.Log("たーんまねっじ");
            StartCoroutine("EndPTCoroutine");

        }
        else if ((enemymove.enemyTurn == false && enemymove2.enemyTurn == false && enemymove3.enemyTurn == false) && EEnd)
        {
            //Debug.Log("たーんまねっじ");
            StartCoroutine("EndETCoroutine");
        }

        if(moveturn.playerTurn == true && OneCount)
        {
            CountTurn();
        }
    }
}
