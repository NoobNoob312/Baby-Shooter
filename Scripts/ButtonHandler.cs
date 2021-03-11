using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

    public GameObject btnStart;
    public GameObject btnHowToPlay;
    public GameObject btnQuit;

    public GameObject btnResume;
    public GameObject btnRestart;
    public GameObject btnRestartTime;
    public GameObject btnMenu;


    public Canvas gameInformation;
    public Canvas startMenu;
    public Canvas pauseMenu;
    public Canvas backgroundPanel;
    public Canvas howToPlay;

    // Start is called before the first frame update
    void Start()
    {
        btnStart.GetComponent<Button>().onClick.AddListener(buttonStart);
        btnHowToPlay.GetComponent<Button>().onClick.AddListener(buttonHowToPlay);
        btnQuit.GetComponent<Button>().onClick.AddListener(buttonQuit);

        btnResume.GetComponent<Button>().onClick.AddListener(buttonResume);
        btnRestart.GetComponent<Button>().onClick.AddListener(buttonRestart);
        btnRestartTime.GetComponent<Button>().onClick.AddListener(buttonRestart);
        btnMenu.GetComponent<Button>().onClick.AddListener(buttonMenu);

    }

    public void HandleEscape()
    {
        if (!GameManager.Instance.isStartMenu)
        {
            if (!GameManager.Instance.isPaused)
            {
                Time.timeScale = 0;
                GameManager.Instance.isPaused = true;
                backgroundPanel.gameObject.SetActive(true);
                pauseMenu.gameObject.SetActive(true);
            }
            else if (GameManager.Instance.isPaused)
            {
                Time.timeScale = 1;
                GameManager.Instance.isPaused = false;
                backgroundPanel.gameObject.SetActive(false);
                pauseMenu.gameObject.SetActive(false);
            }
        }
        if (GameManager.Instance.isHowToPlay)
        {
            GameManager.Instance.isHowToPlay = false;
            howToPlay.gameObject.SetActive(false);
            startMenu.gameObject.SetActive(true);
        }
    }

    void buttonStart()
    {
        GameManager.Instance.isStartMenu = false;
        GameManager.Instance.isPaused = false;
        gameInformation.gameObject.SetActive(true);
        backgroundPanel.gameObject.SetActive(false);
        GameManager.Instance.RestartBTN(false);
        startMenu.gameObject.SetActive(false);
    }

    void buttonHowToPlay()
    {
        GameManager.Instance.isHowToPlay = true;
        startMenu.gameObject.SetActive(false);
        howToPlay.gameObject.SetActive(true);
    }

    void buttonQuit()
    {
        Application.Quit();
    }

    void buttonResume()
    {
        Time.timeScale = 1;
        GameManager.Instance.isPaused = false;
        backgroundPanel.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
    }

    void buttonRestart()
    {
        backgroundPanel.gameObject.SetActive(false);
        GameManager.Instance.RestartBTN(true);
        pauseMenu.gameObject.SetActive(false);
    }

    void buttonMenu()
    {
        GameManager.Instance.isStartMenu = true;
        pauseMenu.gameObject.SetActive(false);
        startMenu.gameObject.SetActive(true);
    }

}
