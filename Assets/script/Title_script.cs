using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_script : MonoBehaviour
{
    public void Option_menu()
    {
        FadeManager.Instance.LoadScene("Set", 2.0f);
    }


    public void Start_menu()
    {
        FadeManager.Instance.LoadScene("tutorial", 1.0f);
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
