using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanteiscript : MonoBehaviour
{
    public GameObject enemy; //�I�u�W�F�N�g�ǂݍ���
    public enemymove enemymove;
    public bool sakuteki = false;//�v���C���[�����������ǂ���

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
            colliderTest.enabled = false;//�R���C�_�[�������A���ꂪ�Ȃ��ƃv���C���[�̃R���C�_�[�ƂԂ����ďꏊ������Ă��܂�
            Debug.Log("�v���C���[���I");
            enemymove.sakuteki = true;
            this.gameObject.SetActive(false);   // �����ɂ���
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
