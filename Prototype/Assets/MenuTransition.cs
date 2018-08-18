using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTransition : MonoBehaviour
{
    [SerializeField]
    private Sprite m_TransitionSprite;

    [SerializeField]
    private Transform m_Parent;

    [SerializeField]
    private float m_TransitionSpeed = 0;

    [SerializeField]
    private float m_TargetScale = 0;

    private GameObject m_Transition;
    private bool m_Transitioning = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(m_Transitioning && m_Transition.transform.localScale.x < m_TargetScale)
        {
            Vector3 scale = m_Transition.transform.localScale;
            scale.x += Time.deltaTime * m_TransitionSpeed;
            scale.y += Time.deltaTime * m_TransitionSpeed;
            m_Transition.transform.localScale = scale;
        }
        else if(m_Transitioning)
        {
            m_Transitioning = false;
            MenuManager menuManager = GetComponent<MenuManager>();
            menuManager.NextScene();
        }
    }

    public void StartTransition()
    {
        if(!m_Transitioning)
        {
            Vector3 mousePosition = Input.mousePosition;
            m_Transition = new GameObject("Transition Sprite");
            m_Transition.AddComponent<RectTransform>();
            m_Transition.GetComponent<RectTransform>().SetParent(m_Parent);
            m_Transition.GetComponent<RectTransform>().position = mousePosition;
            m_Transition.AddComponent<Image>();
            m_Transition.GetComponent<Image>().sprite = m_TransitionSprite;
            m_Transition.GetComponent<Image>().color = Color.white;

            m_Transitioning = true;
        }
    }

    public bool GetIsTransitioning()
    {
        return m_Transition;
    }
}
