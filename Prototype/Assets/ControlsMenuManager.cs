using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsMenuManager : MonoBehaviour
{
    // Targets
    [SerializeField]
    private Image m_Image;
    [SerializeField]
    private Text m_Title;
    [SerializeField]
    private Text m_Description;
    [SerializeField]
    private GameObject m_DotsDisplay;
    [SerializeField]
    private Sprite m_Dot;
    [SerializeField]
    private Color m_ActiveDotColor;
    [SerializeField]
    private Color m_InactiveDotColor;

    // List of controls
    [SerializeField]
    private ControlsUIObject[] m_ControlObjects;

    private List<GameObject> m_Dots;
    private IntroCanvasManager m_IntroCanvasManager;
    private int m_CurrentControl = 0;

    // Use this for initialization
    void Start ()
    {
        m_Dots = new List<GameObject>();
        m_IntroCanvasManager = FindObjectOfType<IntroCanvasManager>();

        if(m_IntroCanvasManager == null)
        {
            Debug.LogWarning("Failed to find IntroCanvasManager!");
        }

        m_ControlObjects = Resources.LoadAll<ControlsUIObject>("Controls");

        if(m_ControlObjects.Length < 1)
        {
            Debug.LogWarning("Failed to find Control Objects!");
        }

        ResetControl();
        ResetDots();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ResetControl()
    {
        m_CurrentControl = 0;
        m_Image.sprite = m_ControlObjects[m_CurrentControl].m_Sprite;
        m_Title.text = m_ControlObjects[m_CurrentControl].m_Title;
        m_Description.text = m_ControlObjects[m_CurrentControl].m_Description;
    }

    public void ResetDots()
    {
        if(m_Dots.Count < 1)
        {
            for(int i = 0; i < m_ControlObjects.Length; i++)
            {
                GameObject dot = new GameObject("Image_dot");
                dot.transform.parent = m_DotsDisplay.transform;
                dot.AddComponent<RectTransform>();
                dot.GetComponent<RectTransform>().localScale = Vector3.one;
                dot.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 16.0f);
                dot.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 16.0f);
                dot.GetComponent<RectTransform>().parent = m_DotsDisplay.transform;
                dot.AddComponent<Image>();
                dot.GetComponent<Image>().sprite = m_Dot;

                if(i == 0)
                {
                    dot.GetComponent<Image>().color = m_ActiveDotColor;
                }
                else
                {
                    dot.GetComponent<Image>().color = m_InactiveDotColor;
                }

                m_Dots.Add(dot);
            }
        }
        else
        {
            for(int i = 0; i < m_Dots.Count; i++)
            {
                if(i == 0)
                {
                    m_Dots[i].GetComponent<Image>().color = m_ActiveDotColor;
                }
                else
                {
                    m_Dots[i].GetComponent<Image>().color = m_InactiveDotColor;
                }
            }
        }
    }

    public void ToNextControl()
    {
        if(m_CurrentControl < m_ControlObjects.Length - 1)
        {
            m_CurrentControl++;
            m_Image.sprite = m_ControlObjects[m_CurrentControl].m_Sprite;
            m_Title.text = m_ControlObjects[m_CurrentControl].m_Title;
            m_Description.text = m_ControlObjects[m_CurrentControl].m_Description;

            for(int i = 0; i < m_Dots.Count; i++)
            {
                if(i == m_CurrentControl)
                {
                    m_Dots[i].GetComponent<Image>().color = m_ActiveDotColor;
                }
                else
                {
                    m_Dots[i].GetComponent<Image>().color = m_InactiveDotColor;
                }
            }
        }
        else
        {
            m_IntroCanvasManager.ToNextState();
        }
    }
}
