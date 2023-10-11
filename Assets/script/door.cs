using UnityEngine;

public class door : MonoBehaviour
{
    public key target;

    void OnDisable()
    {
        target.OnDestroyed.RemoveAllListeners();
    }

    void OnEnable()
    {
        target.OnDestroyed.AddListener(()=>{
            Debug.Log("ÉKÉ`ÉÉÅI");
            Destroy(gameObject, 0.5f);
        });
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
