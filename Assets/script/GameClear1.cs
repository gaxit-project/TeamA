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
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
        Application.Quit();//ゲームプレイ終了
#endif
    }
}
