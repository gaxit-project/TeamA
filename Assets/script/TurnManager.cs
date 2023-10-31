using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject player; //オブジェクト読み込み
    public moveturn moveturn; //スクリプト読み込み
    public GameObject enemy; //オブジェクト読み込み
    public enemymove enemymove;

    public bool PEnd;
    public bool EEnd;

    // Start is called before the first frame update

    IEnumerator EndPTCoroutine()
    {
        //ここに処理を書く
        //Debug.Log("修正中");


        //1フレーム停止
        yield return new WaitForSeconds(1.0f);

        //ここに再開後の処理を書く
        //Debug.Log("ターンエンド！");
        moveturn.PPreX = Mathf.Floor(player.transform.position.x);
        moveturn.PPreZ = Mathf.Floor(player.transform.position.z);
        player.transform.position = new Vector3(Mathf.Floor(moveturn.PPreX), player.transform.position.y, Mathf.Floor(moveturn.PPreZ));
        enemymove.enemyTurn = true;
        PEnd = false;
        EEnd = true;
    }

    IEnumerator EndETCoroutine()
    {
        //ここに処理を書く
        //Debug.Log("修正中");


        //1フレーム停止
        yield return new WaitForSeconds(1.0f);

        //ここに再開後の処理を書く
        //Debug.Log("ターンエンド！");
        enemymove.PreX = Mathf.Floor(enemy.transform.position.x);
        enemymove.PreZ = Mathf.Floor(enemy.transform.position.z);
        enemy.transform.position = new Vector3(Mathf.Floor(enemymove.PreX), 0, Mathf.Floor(enemymove.PreZ));
        moveturn.playerTurn = true;
        PEnd = true;
        EEnd = false;
    }

    void Start()
    {
       PEnd = true;
       EEnd = false;
}

    // Update is called once per frame
    void Update()
    {
        if(moveturn.playerTurn == false && PEnd)
        {
            //Debug.Log("たーんまねっじ");
            StartCoroutine("EndPTCoroutine");

        }
        else if (enemymove.enemyTurn == false && EEnd)
        {
            //Debug.Log("たーんまねっじ");
            StartCoroutine("EndETCoroutine");
        }
    }
}
