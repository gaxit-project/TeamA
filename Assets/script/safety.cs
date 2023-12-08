using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    BoxCollider boxCol; //20231116�ǉ� �v���C���[�̃R���C�_�[�ǂݍ��ݗp�̕ϐ�
    public int flag = 0; //20231116�ǉ� �R���C�_�[�̈ʒu��ς������̃t���O(flag = 0: �ʒu��ς��Ă��Ȃ���ԁAflag = 1:�ʒu��ς��Ă�����)

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        gameManager = GameManager.GetComponent<GameManager>(); // �X�N���v�g���擾
        boxCol = GetComponent<BoxCollider>(); //20231116 �R���C�_�[�̃R���|�[�l���g�̎擾
        boxCol.size = new Vector3((float)0.4, 1, (float)0.4);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Yellow" && node.gameObject.name == "Yellow_Player") //���F�ɐG��āA�����������F�̂Ƃ�
        {
            /*if (flag == 0 && other.gameObject.name == "Hantei" && other.gameObject.name == "Hantei2" && other.gameObject.name == "Hantei3") // �ʒu�����炵�Ă��Ȃ���Ԃ��A�G�̔��������ꍇ
            {
                boxCol.size = new Vector3((float)0.2, (float)0.1, (float)0.2);
            }*/
            boxCol.size = new Vector3((float)0.4, (float)0.1, (float)0.4);
            //boxCol.enabled = false;
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            //Debug.Log("Enter SafeZone");
            //flag = 1;
        }
        else if (other.gameObject.name == "Red" && node.gameObject.name == "Red_Player") //�ԐF�ɐG��āA���������ԐF�̂Ƃ�
        {
            /*if (flag == 0 && other.gameObject.name == "Hantei" && other.gameObject.name == "Hantei2" && other.gameObject.name == "Hantei3") // �ʒu�����炵�Ă��Ȃ���Ԃ��A�G�̔��������ꍇ
            {
                boxCol.size = new Vector3((float)0.2, (float)0.1, (float)0.2);
            }*/
            boxCol.size = new Vector3((float)0.4, (float)0.1, (float)0.4);
            //boxCol.enabled = false;
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            //Debug.Log("Enter SafeZone");
            //flag = 1;
        }
        else if (other.gameObject.name == "Blue" && node.gameObject.name == "Blue_Player") //�F�ɐG��āA���������F�̂Ƃ�
        {
            /*if (flag == 0 && other.gameObject.name == "Hantei" && other.gameObject.name == "Hantei2" && other.gameObject.name == "Hantei3") // �ʒu�����炵�Ă��Ȃ���Ԃ��A�G�̔��������ꍇ
            {
                boxCol.size = new Vector3((float)0.2, (float)0.1, (float)0.2);
            }*/
            boxCol.size = new Vector3((float)0.4, (float)0.1, (float)0.4);
            //boxCol.enabled = false;
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            Debug.Log("Enter SafeZone");
            //flag = 1;
        }


        if (other.gameObject.name == "Hantei")
        {
            /*if (flag == 1) // �ʒu�����炵�Ă�����
            {
                boxCol.size = new Vector3((float)0.2, 1, (float)0.2);
            }*/
            //Debug.Log("��������!");
            enemymove.sakuteki = true;
            enemyhantei.SetActive(false);   // �����ɂ���
        }
        else if (other.gameObject.name == "Hantei2")
        {
            /*if (flag == 1) // �ʒu�����炵�Ă�����
            {
                boxCol.size = new Vector3((float)0.2, 1, (float)0.2);
            }*/
            //Debug.Log("��������!");
            enemymove2.sakuteki = true;
            enemyhantei2.SetActive(false);   // �����ɂ���
        }
        else if (other.gameObject.name == "Hantei3")
        {
            /*if (flag == 1) // �ʒu�����炵�Ă�����
            {
                boxCol.size = new Vector3((float)0.2, 1, (float)0.2);
            }*/
            //Debug.Log("��������!");
            enemymove3.sakuteki = true;
            enemyhantei3.SetActive(false);   // �����ɂ���
        }
        
    }



    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Red" || other.gameObject.name == "Blue" || other.gameObject.name == "Yellow")
        {
            boxCol.size = new Vector3((float)0.1, 1, (float)0.1);
            //boxCol.enabled = true;
            Debug.Log("exit");
        }

    }
}
