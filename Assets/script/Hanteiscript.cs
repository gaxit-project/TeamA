using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanteiscript : MonoBehaviour
{
    public GameObject enemy; //オブジェクト読み込み
    public enemymove enemymove;
    public bool sakuteki = false;//プレイヤーを見つけたかどうか

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        var colliderTest = GetComponent<Collider>();//コライダーを消すためコライダーを定義

        if (other.gameObject.name == "playercube")
        {
            //GetComponent<Renderer>().material.color = Color.yellow;
            colliderTest.enabled = false;//コライダー無効化、これがないとプレイヤーのコライダーとぶつかって場所がずれてしまう
            Debug.Log("プレイヤーだ！");
            enemymove.sakuteki = true;
            this.gameObject.SetActive(false);   // 無効にする
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
