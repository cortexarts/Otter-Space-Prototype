using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCanvasManager : MonoBehaviour
{
    #region Singleton

    public static IntroCanvasManager m_Instance;

    private void Awake()
    {
        m_Instance = this;
    }

    #endregion

    public enum State { Default, Controls, Crafting, Notebook, Dialogue, Help, Fuel, Playing };
    public State currentState;
    public GameObject panelControls;
    public GameObject panelHUD;
    public GameObject panelLab;
    public GameObject panelNotebook;
    public GameObject panelDialogue;
    public GameObject panelControlsSide;
    public GameObject panelcontrolsBottom;
    public GameObject canvasRadar;
    public GameObject canvasPlayer;
    public GameObject panelShooting;

    private CameraController cameraController;
    private DialogueManager m_DialogueManager;

    // Use this for initialization
    void Start ()
    {
        cameraController = FindObjectOfType<CameraController>();
        m_DialogueManager = GetComponent<DialogueManager>();
        currentState = State.Default;
        ToNextState();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyUp(KeyCode.Return))
        {
            ToNextState();
        }
        if(Input.GetKeyUp(KeyCode.Backspace))
        {
            ToPreviousState();
        }
    }

    public void ToNextState()
    {
        switch (currentState)
        {
            case State.Default:
                panelControls.SetActive(true);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(false);
                canvasPlayer.SetActive(false);
                canvasRadar.SetActive(false);
                panelShooting.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Controls;
                break;
            case State.Controls:
                panelControls.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(true);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(false);
                canvasPlayer.SetActive(false);
                canvasRadar.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Crafting;
                break;
            case State.Crafting:
                panelControls.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                panelNotebook.SetActive(true);
                panelDialogue.SetActive(true);
                canvasRadar.SetActive(false);
                cameraController.isZooming = false;
                m_DialogueManager.PlayDialogue(1, false);
                currentState = State.Notebook;
                break;
            case State.Notebook:
                panelControls.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(true);
                canvasRadar.SetActive(false);
                canvasPlayer.SetActive(false);
                cameraController.isZooming = false;
                m_DialogueManager.PlayDialogue(2, false);
                currentState = State.Dialogue;
                break;
            case State.Dialogue:
                panelControls.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(true);
                panelControlsSide.SetActive(false);
                panelcontrolsBottom.SetActive(false);
                canvasRadar.SetActive(false);
                m_DialogueManager.PlayDialogue(3, false);
                cameraController.isZooming = true;
                currentState = State.Help;
                break;
            case State.Help:
                panelControls.SetActive(false);
                panelHUD.SetActive(true);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(false);
                panelControlsSide.SetActive(false);
                canvasPlayer.SetActive(false);
                panelcontrolsBottom.SetActive(false);
                canvasRadar.SetActive(false);
                currentState = State.Fuel;
                break;
            case State.Fuel:
                panelControls.SetActive(false);
                panelHUD.SetActive(true);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(false);
                panelControlsSide.SetActive(true);
                canvasPlayer.SetActive(false);
                panelcontrolsBottom.SetActive(true);
                canvasRadar.SetActive(false);
                panelShooting.SetActive(false);
                currentState = State.Playing;
                break;
            default:
                panelControls.SetActive(false);
                panelHUD.SetActive(true);
                panelLab.SetActive(false);
                panelDialogue.SetActive(false);
                panelNotebook.SetActive(false);
                canvasPlayer.SetActive(false);
                canvasRadar.gameObject.SetActive(false);
                panelShooting.SetActive(false);
                cameraController.isZooming = true;
                currentState = State.Playing;
                break;
        }
    }

    public void ToPreviousState()
    {
        switch(currentState)
        {
            case State.Crafting:
                panelControls.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Controls;
                break;
        }
    }

    public State GetCurrentState()
    {
        return currentState;
    }
}
