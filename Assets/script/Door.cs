using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public key target;

    void OnDisable()
    {
        target.OnDestroyed.RemoveAllListeners();
    }

    void OnEnable()
    {
        target.OnDestroyed.AddListener(() => {
            Debug.Log("�K�`���I");
            Destroy(gameObject, 0.5f);
        });
    }
}
