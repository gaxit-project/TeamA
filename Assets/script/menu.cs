using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
    }

    private void Pause()
    {
        Time.timeScale = 0;  // ���Ԓ�~
        pausePanel.SetActive(true);
    }

    private void Resume()
    {
        Time.timeScale = 1;  // �ĊJ
        pausePanel.SetActive(false);
    }
}