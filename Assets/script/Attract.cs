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

    /// BGMの処理
    [SerializeField] AudioSource NBGM;
    [SerializeField] AudioSource CBGM;


    // Start is called before the first frame update
    IEnumerator Effect_Look()
    {
        Look_txt.SetActive(true);
        //ここに処理を書く
        //Debug.Log("修正中");
        this.transform.position = new Vector3(Mathf.Floor(enemymove.PreX), enemymove.transform.position.y, Mathf.Floor(enemymove.PreZ)); //Lost_txtとLook_txtを敵の座標に持ってくる

        //1フレーム停止
        yield return new WaitForSeconds(1.0f);

        //ここに再開後の処理を書く
        //Debug.Log("ターンエンド！");
        flag = 1;
       
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

    void chaseBGM()
    {
        NBGM.Pause();
        CBGM.Play();
    }

    void normalBGM()
    {
        CBGM.Pause();
        NBGM.Play();
    }

    void Start()
    {
        ///BGMの処理
        CBGM.Stop();
        NBGM.Play();

        Lost_txt.SetActive(false);
        Look_txt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemymove.sakuteki && flag == 0)
        {
            /// BGMの処理
            chaseBGM();

            Look_txt.SetActive(true);
            StartCoroutine("Effect_Look");
            //Lost_txtとLook_txtを敵の座標に持ってくる
            flag = 1;
        }

        else if(enemymove.sakuteki == false && (enemymove.PreX != enemymove.fromx || enemymove.PreZ != enemymove.fromz) && flag == 1)
        {
            /// BGMの処理
            normalBGM();

            StartCoroutine("Effect_Lost");
            flag = 0;
        }

        else if(enemymove.PreX == enemymove.fromx && enemymove.PreZ == enemymove.fromz)
        {
            Lost_txt.SetActive(false);
            flag = 0;
        }

        else if(flag == 1)
        {
           Look_txt.SetActive(false);
        }

        
    }
}
