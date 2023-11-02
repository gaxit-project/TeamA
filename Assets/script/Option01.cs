using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option01 : MonoBehaviour
{
    public void Title()
    {
        FadeManager.Instance.LoadScene("Title", 1.0f);
    }

    public void Next()
    {
        FadeManager.Instance.LoadScene("Map Tsujino", 1.0f);
    }

    public void Next2()
    {
        FadeManager.Instance.LoadScene("Map Kanda", 1.0f);
    }

    public void Re1()
    {
        FadeManager.Instance.LoadScene("tutorial", 1.0f);
    }

    public void Re2()
    {
        FadeManager.Instance.LoadScene("Map Tsujino", 1.0f);
    }

    public void Re3()
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
