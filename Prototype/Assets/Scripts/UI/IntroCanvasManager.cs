using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCanvasManager : MonoBehaviour
{
    public enum State { Default, Controls, Animation, Crafting, Notebook, Dialogue, Playing };
    public State currentState;
    public GameObject panelControls;
    public GameObject panelAnimation;
    public GameObject panelHUD;
    public GameObject panelLab;
    public GameObject panelNotebook;
    public GameObject panelDialogue;

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
                cameraController.isZooming = false;
                currentState = State.Animation;
                break;
            case State.Animation:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(true);
                panelNotebook.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Crafting;
                break;
            case State.Crafting:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                panelNotebook.SetActive(true);
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
                m_DialogueManager.PlayDialogue(1);
                currentState = State.Dialogue;
                break;
            case State.Dialogue:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                panelDialogue.SetActive(false);
                cameraController.isZooming = true;
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
