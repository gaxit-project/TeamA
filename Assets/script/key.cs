using UnityEngine;
using UnityEngine.Events;

public class key : MonoBehaviour
{
    public UnityEvent OnDestroyed = new UnityEvent();
    //bool BeKey = true;

    private void OnDestroy()
    {
        OnDestroyed.Invoke();
        Debug.Log("���Q�b�g�I");
        Destroy(gameObject, 0.0f);
        /*if(BeKey == false)
        {
            OnDestroyed.Invoke();
            //Destroy(gameObject, 0.2f);
            Debug.Log("���Q�b�g�I");
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            OnDestroy();
            //bool BeKey = false;
            //Debug.Log("���m�I");
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
