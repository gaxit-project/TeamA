using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : MonoBehaviour
{
    public GameObject enemy; //オブジェクト読み込み
    public enemymove enemymove;
    public GameObject Lost_txt;
    public GameObject Look_txt;
    public int flag = 0; //flagが0の時は


    // Start is called before the first frame update
    IEnumerator Effect_Look()
    {
        //ここに処理を書く
        //Debug.Log("修正中");
        this.transform.position = new Vector3(Mathf.Floor(enemymove.PreX), enemymove.transform.position.y, Mathf.Floor(enemymove.PreZ)); //Lost_txtとLook_txtを敵の座標に持ってくる

        //1フレーム停止
        yield return new WaitForSeconds(0.0f);

        //ここに再開後の処理を書く
        //Debug.Log("ターンエンド！");
       
    }

    IEnumerator Effect_Lost()
    {
        //ここに処理を書く
        //Debug.Log("修正中");
        Lost_txt.SetActive(true);

        this.transform.position = new Vector3(Mathf.Floor(enemymove.PreX), enemymove.transform.position.y, Mathf.Floor(enemymove.PreZ)); //Lost_txtとLook_txtを敵の座標に持ってくる

        //1フレーム停止
        yield return new WaitForSeconds(0.0f);

        

        //ここに再開後の処理を書く
        //Debug.Log("ターンエンド！");

    }

    void Start()
    {
        Lost_txt.SetActive(false);
        Look_txt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemymove.sakuteki && flag == 0)
        {
            Look_txt.SetActive(true);
            //StartCoroutine("Effect_Look");
            this.transform.position = new Vector3(enemy.transform.position.x, enemymove.transform.position.y, enemy.transform.position.z); //Lost_txtとLook_txtを敵の座標に持ってくる
            flag = 1;
        }

        else if(enemymove.sakuteki == false && (enemymove.PreX != enemymove.fromx || enemymove.PreZ != enemymove.fromz) && flag == 1)
        {
            StartCoroutine("Effect_Lost");
        }

        else if(enemymove.PreX == enemymove.fromx && enemymove.PreZ == enemymove.fromz)
        {
            Lost_txt.SetActive(false);
        }

        else if(flag == 1)
        {
            Look_txt.SetActive(false);
        }

        
    }
}
