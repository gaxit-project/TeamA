using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutZonescript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        var colliderTest = GetComponent<Collider>();//�R���C�_�[���������߃R���C�_�[���`

        if (other.gameObject.name == "playercube")
        {
            //GetComponent<Renderer>().material.color = Color.yellow;
            FadeManager.Instance.LoadScene("GameOver", 2.0f);
            Debug.Log("�I���I");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}