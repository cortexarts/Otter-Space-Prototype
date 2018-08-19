using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsParticleSystem : MonoBehaviour
{
    [SerializeField]
    private List<Color> m_Colors;

    [SerializeField]
    private List<int> m_LayerOffsets;

    [SerializeField]
    private List<int> m_StarsPerLayer;

    [SerializeField]
    private float m_StarSize = 1f;

    [SerializeField]
    private float m_StarDistance = 10f;

    [SerializeField]
    private float smoothing = 1f;

    private Vector3 previousCenterPosition;		// position of cam in previous frame

    private float m_StarDistanceSqr;
    private int m_MaxStarCount;
    private float[] parallaxScales;     // camera's movement / background movement

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
                m_Points[accumulatedLayerStarCount + j].startColor = m_Colors[Random.Range(0, m_Colors.Count)];
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

            parallaxScales = new float[m_Points.Length];
            for(int i = 0; i < m_Points.Length; ++i)
            {
                parallaxScales[i] = m_Points[i].position.z * -1;
            }
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
                    //Vector2 randomPosition = Random.insideUnitCircle * m_StarDistance + new Vector2(m_ParticleTransform.position.x, m_ParticleTransform.position.y);
                    float offsetX = m_Points[accumulatedLayerStarCount + j].position.x - m_ParticleTransform.position.x;
                    float offsetY = m_Points[accumulatedLayerStarCount + j].position.y - m_ParticleTransform.position.y;

                    Vector2 randomPosition = Random.insideUnitCircle * m_StarDistance + new Vector2(m_ParticleTransform.position.x - offsetX, m_ParticleTransform.position.y - offsetY);
                    m_Points[accumulatedLayerStarCount + j].position = new Vector3(randomPosition.x, randomPosition.y, m_LayerOffsets[i]);
                }
                else
                {
                    // the parallax is the opposite of the cam movement because the prev. frame is mult. by the cale
                    float parallax = (previousCenterPosition.x - m_ParticleTransform.position.x) * parallaxScales[i];

                    // set a target x pos which is the current pos + parallax
                    float backgroundTargetPosX = m_Points[accumulatedLayerStarCount + j].position.x + parallax;

                    // create a target pos which is the backgrounds current pos with its target x pos
                    Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, m_Points[accumulatedLayerStarCount + j].position.y, m_Points[accumulatedLayerStarCount + j].position.z);

                    // fade between current pos and the target position using lerp
                    m_Points[accumulatedLayerStarCount + j].position = Vector3.Lerp(m_Points[accumulatedLayerStarCount + j].position, backgroundTargetPos, smoothing * Time.deltaTime);
                }
            }
        }

        // set the previousCamPs to the cams pos at the end of the frame
        previousCenterPosition = m_ParticleTransform.position;

        GetComponent<ParticleSystem>().SetParticles(m_Points, m_Points.Length);
    }
}
