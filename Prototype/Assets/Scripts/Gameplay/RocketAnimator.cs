using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAnimator : MonoBehaviour {

    [SerializeField]
    private GameObject m_ForwardThrusters;
    [SerializeField]
    private GameObject m_BackwardsThrusters;
    [SerializeField]
    private GameObject m_TurnLeftThrusters;
    [SerializeField]
    private GameObject m_TurnRightThrusters;
    
	// Update is called once per frame
	void Update () {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        ValueDependendAnimation(inputVertical, m_BackwardsThrusters, m_ForwardThrusters);
        ValueDependendAnimation(-inputHorizontal, m_TurnLeftThrusters, m_TurnRightThrusters);
    }

    //Using a value which is between 1 and -1 it is decided which gameobject to turn on
    //Max when the value is greater then 0
    //Min when the value is less then 0
    private void ValueDependendAnimation(float value, GameObject min, GameObject max)
    {
        if (value > 0)
        {
            if (!max.activeInHierarchy)
            {
                max.SetActive(true);
                min.SetActive(false);
            }
            foreach (Transform t in max.GetComponentInChildren<Transform>())
                t.localScale = new Vector3(value, value, 1);
        }
        else if (value < 0) {
            if (!min.activeInHierarchy)
            {
                max.SetActive(false);
                min.SetActive(true);
            }
            foreach (Transform t in min.GetComponentInChildren<Transform>())
                t.localScale = new Vector3(-value, -value, 1);
        }
        else if (value == 0)
        {
            max.SetActive(false);
            min.SetActive(false);
        }
    }
}
