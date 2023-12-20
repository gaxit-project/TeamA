using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public key target;
    public GameObject CloseDoor;
    public GameObject OpenDoor;

    void OnDisable()
    {
        target.OnDestroyed.RemoveAllListeners();
    }

    void OnEnable()
    {
        target.OnDestroyed.AddListener(() => {
            Debug.Log("ガチャ！");
            Destroy(gameObject, 0.5f);
            CloseDoor.SetActive(false);   // 無効にする
            OpenDoor.SetActive(true);   // 無効にする
        });
    }
}
