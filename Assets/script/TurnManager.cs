using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject player; //�I�u�W�F�N�g�ǂݍ���
    public moveturn moveturn; //�X�N���v�g�ǂݍ���
    public GameObject enemy; //�I�u�W�F�N�g�ǂݍ���
    public enemymove enemymove;
    public GameObject enemy2; //�I�u�W�F�N�g�ǂݍ���
    public enemymove enemymove2;
    public GameObject enemy3; //�I�u�W�F�N�g�ǂݍ���
    public enemymove enemymove3;

    public bool PEnd;
    public bool EEnd;

    // Start is called before the first frame update

    IEnumerator EndPTCoroutine()
    {
        //�����ɏ���������
        //Debug.Log("�C����");


        //1�t���[����~
        yield return new WaitForSeconds(1.0f);

        //�����ɍĊJ��̏���������
        //Debug.Log("�^�[���G���h�I");
        moveturn.PPreX = Mathf.Floor(player.transform.position.x);
        moveturn.PPreZ = Mathf.Floor(player.transform.position.z);
        player.transform.position = new Vector3(Mathf.Floor(moveturn.PPreX), player.transform.position.y, Mathf.Floor(moveturn.PPreZ));
        enemymove.enemyTurn = true;
        enemymove2.enemyTurn = true;
        enemymove3.enemyTurn = true;
        PEnd = false;
        EEnd = true;
    }

    IEnumerator EndETCoroutine()
    {
        //�����ɏ���������
        //Debug.Log("�C����");


        //1�t���[����~
        yield return new WaitForSeconds(1.0f);

        //�����ɍĊJ��̏���������
        //Debug.Log("�^�[���G���h�I");
        enemymove.PreX = Mathf.Floor(enemy.transform.position.x);
        enemymove.PreZ = Mathf.Floor(enemy.transform.position.z);
        enemymove2.PreX = Mathf.Floor(enemy.transform.position.x);
        enemymove2.PreZ = Mathf.Floor(enemy.transform.position.z);
        enemymove3.PreX = Mathf.Floor(enemy.transform.position.x);
        enemymove3.PreZ = Mathf.Floor(enemy.transform.position.z);
        /*
        enemy.transform.position = new Vector3(Mathf.Floor(enemymove.PreX), 0, Mathf.Floor(enemymove.PreZ));
        enemy2.transform.position = new Vector3(Mathf.Floor(enemymove2.PreX), 0, Mathf.Floor(enemymove2.PreZ));
        enemy3.transform.position = new Vector3(Mathf.Floor(enemymove3.PreX), 0, Mathf.Floor(enemymove3.PreZ));
        */
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
            //Debug.Log("���[��܂˂���");
            StartCoroutine("EndPTCoroutine");

        }
        else if (enemymove.enemyTurn == false && EEnd)
        {
            //Debug.Log("���[��܂˂���");
            StartCoroutine("EndETCoroutine");
        }
    }
}
