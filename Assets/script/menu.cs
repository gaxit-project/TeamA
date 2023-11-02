using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;

    public bool menu = true;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
    }

    private void Pause()
    {
        Time.timeScale = 0;  // éûä‘í‚é~
        pausePanel.SetActive(true);
    }

    private void Resume()
    {
        Time.timeScale = 1;  // çƒäJ
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown("joystick button 3") && menu)
        { 
            Pause();
            menu = false; 
        }
        else if (Input.GetKeyDown("joystick button 3") && menu == false)
        {
            Resume();
            menu = true;
        }
    }
}
