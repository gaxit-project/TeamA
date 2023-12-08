using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option01 : MonoBehaviour
{
    public void Title()
    {
        SceneManager.LoadScene("Title");
        
    }

    public void Next()
    {
        SceneManager.LoadScene("Map Neo Tsujino");
        
    }

    public void Next2()
    {
        SceneManager.LoadScene("Map Kanda");
        
    }

    public void Re1()
    {
        SceneManager.LoadScene("tutorial");
        
    }

    public void Re2()
    {
        SceneManager.LoadScene("Map Neo Tsujino");
        
    }

    public void Re3()
    {
        SceneManager.LoadScene("Map Kanda");
        
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
