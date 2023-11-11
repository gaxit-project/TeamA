using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �L�[�������ƁA�X�v���C�g���ړ�����
public class moveturn3 : MonoBehaviour
{
    private Controller controller_;//Xbox�R���g���[���[���󂯕t����悤�ɕϐ��Ƃ��Ē�`

    GameObject GameManager;//Gamemanager�ǂݍ���
    GameManager gameManager;

    public GameObject TurnManagar; //�I�u�W�F�N�g�ǂݍ���
    public TurnManager3 turnmanager; //�I�u�W�F�N�g�ǂݍ���
    public GameObject enemy; //�I�u�W�F�N�g�ǂݍ���
    public enemymove3 enemymove;
    public GameObject enemyhantei; //�I�u�W�F�N�g�ǂݍ���
    public GameObject enemy2; //�I�u�W�F�N�g�ǂݍ���
    public enemymove3 enemymove2;
    public GameObject enemyhantei2; //�I�u�W�F�N�g�ǂݍ���
    public GameObject enemy3; //�I�u�W�F�N�g�ǂݍ���
    public enemymove3 enemymove3;
    public GameObject enemyhantei3; //�I�u�W�F�N�g�ǂݍ���
                                    //public float speed = 2; // �X�s�[�h�FInspector�Ŏw��

    public bool playerTurn;

    public float PPreX;
    public float PPreZ;
    public bool up = true;
    public bool down = true;
    public bool right = true;
    public bool left = true;
    private Vector3 latestPos;  //�O���Position

    //float dph = Input.GetAxis("D_Pad_H");
    //float dpv = Input.GetAxis("D_Pad_V");

    void Start()
    {
        controller_ = new Controller();
        playerTurn = true;
        GameManager = GameObject.Find("GameManager");
        gameManager = GameManager.GetComponent<GameManager>(); // �X�N���v�g���擾
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    /*IEnumerator MoveCoroutine()
	{
		//�����ɏ���������
		Debug.Log("�������Ă�!");

		//1�t���[����~
		yield return new WaitForSeconds(1.0f);

		//�����ɍĊJ��̏���������
		playerTurn = false;
	}*/
    /*
	IEnumerator ZahyouCoroutine()
	{
		//�����ɏ���������
		//Debug.Log("�C����");
		PPreX = Mathf.Floor(this.transform.position.x);
		PPreZ = Mathf.Floor(this.transform.position.z);

		//1�t���[����~
		yield return new WaitForSeconds(0.0f);

		//�����ɍĊJ��̏���������
		Debug.Log("����");
		Debug.Log(Mathf.Floor(PPreX) + " " + this.transform.position.y + " " + Mathf.Floor(PPreZ));
		transform.position = new Vector3(Mathf.Floor(PPreX), this.transform.position.y, Mathf.Floor(PPreZ));
		//playerTurn = false;
	}
	*/


    IEnumerator XZahyouCoroutine()
    {
        //�����ɏ���������
        //Debug.Log("�C����");
        //PPreX = Mathf.Floor(this.transform.position.x);

        //1�t���[����~
        yield return new WaitForSeconds(0.0f);

        //�����ɍĊJ��̏���������
        Debug.Log("����");
        Debug.Log(Mathf.Floor(this.transform.position.x) + " " + this.transform.position.y + " " + Mathf.Floor(PPreZ));
        transform.position = new Vector3(Mathf.Floor(this.transform.position.x), this.transform.position.y, PPreZ);
        playerTurn = false;
        //StartCoroutine("PosKakuteiCoroutine");
        PPreX = this.transform.position.x;
    }

    IEnumerator ZZahyouCoroutine()
    {
        //�����ɏ���������
        //Debug.Log("�C����");
        //PPreZ = Mathf.Floor(this.transform.position.z);

        //1�t���[����~
        yield return new WaitForSeconds(0.0f);

        //�����ɍĊJ��̏���������
        //Debug.Log("����");
        Debug.Log(Mathf.Floor(PPreX) + " " + this.transform.position.y + " " + Mathf.Floor(this.transform.position.z));
        transform.position = new Vector3(PPreX, this.transform.position.y, Mathf.Floor(this.transform.position.z));
        playerTurn = false;
        //StartCoroutine("PosKakuteiCoroutine");
        //PPreZ = this.transform.position.z;
    }

    /*IEnumerator PosKakuteiCoroutine()
    {
        //�����ɏ���������
        //Debug.Log("�C����");

        //1�t���[����~
        yield return new WaitForSeconds(0.5f);

        //�����ɍĊJ��̏���������
        PPreX = Mathf.Floor(this.transform.position.x);
        PPreZ = Mathf.Floor(this.transform.position.z);
        //pl
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Yellow")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            Debug.Log("Enter SafeZone");
        }
        else if (other.gameObject.name == "Red")
        {
            GetComponent<Renderer>().material.color = Color.red;
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            Debug.Log("Enter SafeZone");
        }
        else if (other.gameObject.name == "Blue")
        {
            GetComponent<Renderer>().material.color = Color.blue;
            enemymove.sakuteki = false;
            enemyhantei.SetActive(true);
            enemymove2.sakuteki = false;
            enemyhantei2.SetActive(true);
            enemymove3.sakuteki = false;
            enemyhantei3.SetActive(true);
            Debug.Log("Enter SafeZone");
        }
        else if (other.gameObject.name == "Hantei")
        {
            Debug.Log("��������!");
            enemymove.sakuteki = true;
            enemyhantei.SetActive(false);   // �����ɂ���
        }
        else if (other.gameObject.name == "Hantei2")
        {
            Debug.Log("��������!");
            enemymove2.sakuteki = true;
            enemyhantei2.SetActive(false);   // �����ɂ���
        }
        else if (other.gameObject.name == "Hantei3")
        {
            Debug.Log("��������!");
            enemymove3.sakuteki = true;
            enemyhantei3.SetActive(false);   // �����ɂ���
        }
        else if (other.gameObject.name == "OutZone" && other.gameObject.name != "Blue" && other.gameObject.name != "Red" && other.gameObject.name != "Yellow")
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene("GameOver3");
        }
        else if (other.gameObject.name == "ClearObject")
        {
            Debug.Log("GameClear");
            SceneManager.LoadScene("GameClear3");
        }
    }*/

    void Update()
    { // �����ƍs��
        Transform PLtransform = this.transform;//transform���擾
        Vector3 pos = PLtransform.position;
        Vector3 worldAngle = PLtransform.eulerAngles;// ���[���h���W����ɁA��]���擾
        latestPos = transform.position;  //�O���Position�̍X�V
        var PLx = this.transform.position.x;
        var PLz = this.transform.position.z;
        PLtransform.position = pos;  // ���W��ݒ�
                                     //Vector3 posi = this.transform.position;//���[�J�����W(moveturn���A�^�b�`����Ă���I�u�W�F�N�g�̍��W)���擾
        float dph = Input.GetAxis("D_Pad_H");
        float dpv = Input.GetAxis("D_Pad_V");

        //var gamepad = xbo.current;

        if (playerTurn)
        {
            //Debug.Log("�s�����I");
            //Debug.Log(playerTurn);
            if (dph > 0 && right == true && PLx - PPreX < 1)
            { // �����A�E�L�[�������ꂽ��
                PLtransform.position += new Vector3(1, 0, 0) * Time.deltaTime;
                //Debug.Log("��:" + PLx + " " + "�O:" + PPreX);
                //StartCoroutine("MoveCoroutine");
                worldAngle.y = 45.0f; // ���[���h���W�����y�������ɂ�����]���w�肵���p�x�ɕύX
                PLtransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�
                up = false;
                down = false;
            }
            else if (dph < 0 && left == true && PPreX - PLx < 0.9)
            { // �����A���L�[�������ꂽ��
                PLtransform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
                worldAngle.y = -135.0f; // ���[���h���W�����y�������ɂ�����]���w�肵���p�x�ɕύX
                PLtransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�
                                                      //Debug.Log("��:" + PLx + " " + "�O:" + PPreX);
                                                      //StartCoroutine("MoveCoroutine");
                up = false;
                down = false;
            }
            else if (dpv > 0 && up == true && PLz - PPreZ < 1)
            { // �����A��L�[�������ꂽ��
                PLtransform.position += new Vector3(0, 0, 1) * Time.deltaTime;
                worldAngle.y = -45.0f; // ���[���h���W�����y�������ɂ�����]���w�肵���p�x�ɕύX
                PLtransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�
                                                      //StartCoroutine("MoveCoroutine");
                Debug.Log("��:" + PLz + " " + "�O:" + PPreZ);
                right = false;
                left = false;
            }
            else if (dpv < 0 && down == true && PPreZ - PLz < 0.9)
            { // �����A���L�[�������ꂽ��
                PLtransform.position += new Vector3(0, 0, -1) * Time.deltaTime;
                worldAngle.y = 135.0f; // ���[���h���W�����y�������ɂ�����]���w�肵���p�x�ɕύX
                PLtransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�
                                                      //StartCoroutine("MoveCoroutine");
                Debug.Log("��:" + PLz + " " + "�O:" + PPreZ);
                right = false;
                left = false;
            }
            else if (PPreX - PLx > 0.8 || PLx - PPreX > 1 || PPreZ - PLz > 0.8 || PLz - PPreZ > 1)
            {
                playerTurn = false;
            }

            /*
			if (PPreX > PLx && PPreX - PLx > 0.8)//���s������
            {
				//PPreX = PLx;
				//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
				playerTurn = false;
				//StartCoroutine("XZahyouCoroutine");
			}
			else if (PPreX < PLx && PLx - PPreX > 1)//�E�s������
			{
				//PPreX = PLx;
				//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
				playerTurn = false;
				//StartCoroutine("XZahyouCoroutine");
			}

			if (playerTurn && PPreZ > PLz && PPreZ - PLz > 0.8)//���s������
			{
				//PPreZ = PLz;
				//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
				playerTurn = false;
				Debug.Log("��");
				//StartCoroutine("ZZahyouCoroutine");
				//PPreX = this.transform.position.x;
				//PPreZ = this.transform.position.z;
			}
			else if (PPreZ < PLz && PLz - PPreZ > 1)//��s������
			{
				//PPreZ = PLz;
				//transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
				playerTurn = false;
				//StartCoroutine("ZZahyouCoroutine");
				//PPreX = this.transform.position.x;
				//PPreZ = this.transform.position.z;
			}*/
        }
        else if (playerTurn == false)
        {
            //PPreX = Mathf.Floor(PLx);
            //PPreZ = Mathf.Floor(PLz);
            //StartCoroutine("ZahyouCoroutine");
            //transform.position = new Vector3(Mathf.Floor(PLx), this.transform.position.y, Mathf.Floor(PLz));
            //Debug.Log("a" + Mathf.Floor(PLx) + " " + Mathf.Floor(PLz));
            //Debug.Log("�~�܂�����");
            playerTurn = false;
            //Debug.Log(playerTurn);
            up = true;
            down = true;
            right = true;
            left = true;
            //gameManager.CallInoperable(0.5f); // 2 �b�ԁ@���̃X�N���v�g�𖳌���
        }

        if (Input.GetKey("escape"))
        { // �����A���L�[�������ꂽ��
            Debug.Log("DON!");
            PauseGame();
        }
        if (Input.GetKey("backspace"))
        { // �����A���L�[�������ꂽ��
            Debug.Log("Oh");
            ResumeGame();
        }
    }
    void FixedUpdate()
    { // �����ƍs���i��莞�Ԃ��ƂɁj
      // �ړ�����
      // this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }
}
