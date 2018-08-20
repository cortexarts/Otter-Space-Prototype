using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    #region Singleton

    public static MenuManager m_Instance;

    private void Awake()
    {
        m_Instance = this;
    }

    #endregion

    public GameObject optionsPanel;
    public GameObject pausePanel;
    public bool isPaused = false;
    public float elapsedtime = 0f;
    public float timeInScene = 0;

    private string m_NextScene;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePause();
        }

        timeInScene += Time.fixedDeltaTime;
        elapsedtime = Time.realtimeSinceStartup;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void ToggleOptions()
    {
        if (optionsPanel.activeInHierarchy)
        {
            optionsPanel.SetActive(false);
        }
        else
        {
            optionsPanel.SetActive(true);
        }
    }

    public void SwitchScene(string a_name)
    {
        m_NextScene = a_name;

        MenuTransition menuTransition = GetComponent<MenuTransition>();

        if(menuTransition.GetIsTransitioning() == false)
        {
            menuTransition.StartTransition();
        }
    }

    public void TogglePanel(GameObject a_Panel)
    {
        if(a_Panel.activeInHierarchy)
        {
            a_Panel.SetActive(false);
        }
        else
        {
            a_Panel.SetActive(true);
        }
    }

    public void OpenURL(string a_URL)
    {
        Application.OpenURL(a_URL);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NextScene()
    {
        timeInScene = 0;
        SceneManager.LoadScene(m_NextScene);
    }
}
