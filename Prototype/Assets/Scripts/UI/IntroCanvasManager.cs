using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCanvasManager : MonoBehaviour
{
    public enum State { Default, Controls, Animation, Crafting, Notebook, Dialogue, Help, Fuel, Playing };
    public State currentState;
    public GameObject panelControls;
    public GameObject panelAnimation;
    public GameObject panelHUD;
    public GameObject panelLab;
    public GameObject panelNotebook;
    public GameObject panelDialogue;
    public GameObject panelControlsSide;
    public GameObject panelcontrolsBottom;

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
                panelAnimation.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Controls;
                break;
            case State.Controls:
                panelControls.SetActive(false);
                panelHUD.SetActive(false);
                panelAnimation.SetActive(true);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Animation;
                break;
            case State.Animation:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(true);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(true);
                cameraController.isZooming = false;
                m_DialogueManager.PlayDialogue(0, true);
                currentState = State.Crafting;
                break;
            case State.Crafting:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                panelNotebook.SetActive(true);
                panelDialogue.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Notebook;
                break;
            case State.Notebook:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(true);
                cameraController.isZooming = false;
                m_DialogueManager.PlayDialogue(1, false);
                currentState = State.Dialogue;
                break;
            case State.Dialogue:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(true);
                panelControlsSide.SetActive(false);
                panelcontrolsBottom.SetActive(false);
                m_DialogueManager.PlayDialogue(2, false);
                cameraController.isZooming = true;
                currentState = State.Help;
                break;
            case State.Help:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(true);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(false);
                panelControlsSide.SetActive(false);
                panelcontrolsBottom.SetActive(false);
                currentState = State.Fuel;
                break;
            case State.Fuel:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(true);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(false);
                panelControlsSide.SetActive(true);
                panelcontrolsBottom.SetActive(true);
                currentState = State.Playing;
                break;
            default:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(true);
                panelLab.SetActive(false);
                panelDialogue.SetActive(false);
                panelNotebook.SetActive(false);
                cameraController.isZooming = true;
                currentState = State.Playing;
                break;
        }
    }

    public void ToPreviousState()
    {
        switch(currentState)
        {
            case State.Animation:
                panelControls.SetActive(true);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Controls;
                break;
            case State.Crafting:
                panelControls.SetActive(false);
                panelAnimation.SetActive(true);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Animation;
                break;
        }
    }
}
