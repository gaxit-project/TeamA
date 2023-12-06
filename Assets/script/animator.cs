using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator : MonoBehaviour  //アニメーションのon,off
{
    [SerializeField] Animator anim;

    private Vector3 _prevPosition;
    int flag = 0;

    // Start is called before the first frame update
    void Start()
    {
        _prevPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        var position = transform.position;

        if(_prevPosition.x != position.x || _prevPosition.z != position.z)
        {
            anim.SetBool("Walking", true);
            flag = 1;
        }
        else if(flag == 1)
        {
            Invoke("Walking_Stop", 0.7f);
            flag = 0;
        }

        _prevPosition = position;
    }

    void Walking_Stop()
    {
        anim.SetBool("Walking", false);
    }
}
