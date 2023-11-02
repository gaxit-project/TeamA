using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource SA;

    // Start is called before the first frame update
    void Start()
    {
        SA = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            SA.PlayOneShot(sound1);
        }
    }
}