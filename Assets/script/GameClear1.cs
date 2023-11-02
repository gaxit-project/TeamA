using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear1 : MonoBehaviour
{
    public void Title()
    {
        FadeManager.Instance.LoadScene("Title", 1.0f);
    }

    public void Restart()
    {
        FadeManager.Instance.LoadScene("Map Kanda", 1.0f);
    }


    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
        Application.Quit();//�Q�[���v���C�I��
#endif
    }
}
