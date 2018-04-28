using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCanvasManager : MonoBehaviour
{
    public enum State { Default, Controls, Animation, Playing };
    public State currentState;
    public GameObject panelControls;
    public GameObject panelAnimation;
    public GameObject panelHUD;

    private MenuManager menuManager;
    private CameraController cameraController;

    // Use this for initialization
    void Start ()
    {
        menuManager = GetComponent<MenuManager>();
        cameraController = FindObjectOfType<CameraController>();
        currentState = State.Default;
        ToNextState();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void ToNextState()
    {
        switch (currentState)
        {
            case State.Default:
                panelControls.SetActive(true);
                panelAnimation.SetActive(false);
                currentState = State.Controls;
                break;
            case State.Controls:
                panelControls.SetActive(false);
                panelAnimation.SetActive(true);
                currentState = State.Animation;
                break;
            case State.Animation:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(true);
                cameraController.isZooming = true;
                currentState = State.Playing;
                break;
            default:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(true);
                cameraController.isZooming = true;
                currentState = State.Playing;
                break;
        }
    }
}
