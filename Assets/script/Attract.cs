using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : MonoBehaviour
{
    public GameObject enemy; //�I�u�W�F�N�g�ǂݍ���
    public enemymove enemymove;
    public GameObject Lost_txt;
    public GameObject Look_txt;
    public int flag = 0; //flag��0�̎���

    /// BGM�̏���
    [SerializeField] AudioSource NBGM;
    [SerializeField] AudioSource CBGM;


    // Start is called before the first frame update
    IEnumerator Effect_Look()
    {
        Look_txt.SetActive(true);
        //�����ɏ���������
        //Debug.Log("�C����");
        this.transform.position = new Vector3(Mathf.Floor(enemymove.PreX), enemymove.transform.position.y, Mathf.Floor(enemymove.PreZ)); //Lost_txt��Look_txt��G�̍��W�Ɏ����Ă���

        //1�t���[����~
        yield return new WaitForSeconds(1.0f);

        //�����ɍĊJ��̏���������
        //Debug.Log("�^�[���G���h�I");
        flag = 1;
       
    }

    IEnumerator Effect_Lost()
    {
        //�����ɏ���������
        //Debug.Log("�C����");
        Lost_txt.SetActive(true);

        this.transform.position = new Vector3(Mathf.Floor(enemymove.PreX), enemymove.transform.position.y, Mathf.Floor(enemymove.PreZ)); //Lost_txt��Look_txt��G�̍��W�Ɏ����Ă���

        //1�t���[����~
        yield return new WaitForSeconds(0.0f);

        

        //�����ɍĊJ��̏���������
        //Debug.Log("�^�[���G���h�I");

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
        ///BGM�̏���
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
            /// BGM�̏���
            chaseBGM();

            Look_txt.SetActive(true);
            StartCoroutine("Effect_Look");
            //Lost_txt��Look_txt��G�̍��W�Ɏ����Ă���
            flag = 1;
        }

        else if(enemymove.sakuteki == false && (enemymove.PreX != enemymove.fromx || enemymove.PreZ != enemymove.fromz) && flag == 1)
        {
            /// BGM�̏���
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
