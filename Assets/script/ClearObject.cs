using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ClearObject : MonoBehaviour
{
    public UnityEvent OnDestroyed = new UnityEvent();
    //bool BeKey = true;

    private void OnDestroy()
    {
        OnDestroyed.Invoke();
        Debug.Log("クリアマスに入った！");
        Destroy(gameObject, 0.0f);
        //SceneManager.LoadScene("GameClear");
        /*if(BeKey == false)
        {
            OnDestroyed.Invoke();
            //Destroy(gameObject, 0.2f);
            Debug.Log("鍵ゲット！");
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            OnDestroy();
            //bool BeKey = false;
            //Debug.Log("検知！");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
