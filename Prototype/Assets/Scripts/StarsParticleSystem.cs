using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsParticleSystem : MonoBehaviour
{
    [SerializeField]
    private List<int> m_LayerOffsets;
    [SerializeField]
    private List<int> m_StarsPerLayer;
    [SerializeField]
    private float m_StarSize = 1f;
    [SerializeField]
    private float m_StarDistance = 10f;
    private float m_StarDistanceSqr;
    private int m_MaxStarCount;

    private Transform m_ParticleTransform;
    private ParticleSystem.Particle[] m_Points;

    // Use this for initialization
    void Start()
    {
        m_ParticleTransform = transform;
        m_StarDistanceSqr = m_StarDistance * m_StarDistance;
        for(int i = 0; i < m_StarsPerLayer.Count; i++)
        {
            m_MaxStarCount += m_StarsPerLayer[i];
        }
    }

    private void CreateStars()
    {
        m_Points = new ParticleSystem.Particle[m_MaxStarCount];
        int accumulatedLayerStarCount = 0;

        for(int i = 0; i < m_StarsPerLayer.Count; i++)
        {
            if(i > 0)
            {
                accumulatedLayerStarCount += m_StarsPerLayer[i - 1];
            }

            for(int j = 0; j < m_StarsPerLayer[i]; j++)
            {
                Vector2 randomPosition = Random.insideUnitCircle * m_StarDistance + new Vector2(m_ParticleTransform.position.x, m_ParticleTransform.position.y);
                m_Points[accumulatedLayerStarCount + j].position = new Vector3(randomPosition.x, randomPosition.y, m_LayerOffsets[i]);
                m_Points[accumulatedLayerStarCount + j].startColor = Color.white;
                m_Points[accumulatedLayerStarCount + j].startSize = m_StarSize;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Points == null)
        {
            CreateStars();
        }

        int accumulatedLayerStarCount = 0;

        for(int i = 0; i < m_StarsPerLayer.Count; i++)
        {
            if(i > 0)
            {
                accumulatedLayerStarCount += m_StarsPerLayer[i - 1];
            }

            for(int j = 0; j < m_StarsPerLayer[i]; j++)
            {
                if((m_Points[accumulatedLayerStarCount + j].position - m_ParticleTransform.position).sqrMagnitude > m_StarDistanceSqr)
                {
                    Vector2 randomPosition = Random.insideUnitCircle * m_StarDistance + new Vector2(m_ParticleTransform.position.x, m_ParticleTransform.position.y);
                    m_Points[accumulatedLayerStarCount + j].position = new Vector3(randomPosition.x, randomPosition.y, m_LayerOffsets[i]);
                }
            }
        }

        GetComponent<ParticleSystem>().SetParticles(m_Points, m_Points.Length);
    }
}
