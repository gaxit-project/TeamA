using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TurnManagar; //�I�u�W�F�N�g�ǂݍ���
    public TurnManager turnmanager; //�I�u�W�F�N�g�ǂݍ���
    public GameObject enemy; //�I�u�W�F�N�g�ǂݍ���
    public enemymove enemymove;
    public GameObject enemyhantei; //�I�u�W�F�N�g�ǂݍ���
    public GameObject enemy2; //�I�u�W�F�N�g�ǂݍ���
    public enemymove enemymove2;
    public GameObject enemyhantei2; //�I�u�W�F�N�g�ǂݍ���
    public GameObject enemy3; //�I�u�W�F�N�g�ǂݍ���
    public enemymove enemymove3;
    public GameObject enemyhantei3; //�I�u�W�F�N�g�ǂݍ���
                                    //public float speed = 2; // �X�s�[�h�FInspector�Ŏw��
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
            SceneManager.LoadScene("GameOver");
        }
        else if (other.gameObject.name == "ClearObject")
        {
            Debug.Log("GameClear");
            SceneManager.LoadScene("GameClear");
        }
    }


}
