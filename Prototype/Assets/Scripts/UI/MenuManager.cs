using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject pausePanel;
    public bool isPaused = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
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

    public void SwitchScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
