using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safety : MonoBehaviour
{
    GameObject GameManager;//Gamemanager�ǂݍ���
    GameManager gameManager;

    public GameObject node; //�I�u�W�F�N�g�ǂݍ���

    public GameObject enemy; //�I�u�W�F�N�g�ǂݍ���
    public enemymove enemymove;
    public GameObject enemyhantei; //�I�u�W�F�N�g�ǂݍ���
    public GameObject enemy2; //�I�u�W�F�N�g�ǂݍ���
    public enemymove enemymove2;
    public GameObject enemyhantei2; //�I�u�W�F�N�g�ǂݍ���
    public GameObject enemy3; //�I�u�W�F�N�g�ǂݍ���
    public enemymove enemymove3;
    public GameObject enemyhantei3; //�I�u�W�F�N�g�ǂݍ���

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        gameManager = GameManager.GetComponent<GameManager>(); // �X�N���v�g���擾
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Yellow" && node.gameObject.name == "Yellow_Playerr") //���F�ɐG��āA�����������F�̂Ƃ�
        {
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            //Debug.Log("Enter SafeZone");
        }
        else if (other.gameObject.name == "Red" && node.gameObject.name == "Red_Player") //�ԐF�ɐG��āA���������ԐF�̂Ƃ�
        {
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            //Debug.Log("Enter SafeZone");
        }
        else if (other.gameObject.name == "Blue" && node.gameObject.name == "Blue_Player") //�F�ɐG��āA���������F�̂Ƃ�
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
            //Debug.Log("��������!");
            enemymove.sakuteki = true;
            enemyhantei.SetActive(false);   // �����ɂ���
        }
        else if (other.gameObject.name == "Hantei2")
        {
            //Debug.Log("��������!");
            enemymove2.sakuteki = true;
            enemyhantei2.SetActive(false);   // �����ɂ���
        }
        else if (other.gameObject.name == "Hantei3")
        {
            //Debug.Log("��������!");
            enemymove3.sakuteki = true;
            enemyhantei3.SetActive(false);   // �����ɂ���
        }
    }
}
