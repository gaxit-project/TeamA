using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Set_script : MonoBehaviour
{
    public void Back_menu()
    {
        FadeManager.Instance.LoadScene("Title",2.0f);
    }

    public void Exit_menu()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
        Application.Quit();//�Q�[���v���C�I��
#endif
    }

}
