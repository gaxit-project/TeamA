using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_script : MonoBehaviour
{
    public void Option_menu()
    {
        SceneManager.LoadScene("Set");
    }


    public void Start_menu()
    {
        SceneManager.LoadScene("tutorial");
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
