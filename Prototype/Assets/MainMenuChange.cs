using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuChange : MonoBehaviour
{

    [Header("Desired aesthetic")]
    [SerializeField]
    private Color m_Color;

    [SerializeField]
    private Color m_RingColor;

    [SerializeField]
    private Sprite m_EarthSprite;

    [SerializeField]
    private float m_Duration = 0.0f;

    [Header("Targets")]
    [SerializeField]
    private SpriteRenderer m_EarthTarget;

    [SerializeField]
    private List<Image> m_TargetImages;

    [SerializeField]
    private List<SpriteRenderer> m_TargetRings;

    [SerializeField]
    private List<Text> m_TargetText;

    private Color m_DefaultColor;
    private Color m_DefaultRingColor;
    private float m_time = 0.0f;

	// Use this for initialization
	void Start ()
    {
        m_DefaultColor = m_TargetText[0].color;
        m_DefaultRingColor = m_TargetRings[0].color;
    }
	
	// Update is called once per frame
	void Update ()
    {
        foreach(Image item in m_TargetImages)
        {
            item.color = Color.Lerp(m_DefaultColor, m_Color, m_time);
        }

        foreach(Text item in m_TargetText)
        {
            item.color = Color.Lerp(m_DefaultColor, m_Color, m_time);
        }

        Color ringColor = Color.Lerp(m_DefaultRingColor, m_RingColor, m_time);

        for(int i = 0; i < m_TargetRings.Count; i++)
        {
            m_TargetRings[i].color = new Color(ringColor.r, ringColor.g, ringColor.b, 1.0f / (1.0f * i + 1));
        }

        if(m_time >= m_Duration)
        {
            m_EarthTarget.sprite = m_EarthSprite;

            m_time = m_Duration;
        }
        else
        {
            m_time += Time.deltaTime / m_Duration;
        }
    }
}
