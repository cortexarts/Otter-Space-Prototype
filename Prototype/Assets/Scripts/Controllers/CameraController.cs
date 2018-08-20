using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Singleton

    public static CameraController m_Instance;

    private void Awake()
    {
        m_Instance = this;
    }

    #endregion

    public Transform target;
    public float minSize = 10.0f;
    public float maxSize = 25.0f;
    public float damping = 1.0f;
    public float lookAheadFactor = 3.0f;
    public float lookAheadReturnSpeed = 0.5f;
    public float lookAheadMoveThreshold = 0.1f;
    public float zoomSpeed = 0.1f;
    public bool isZooming = false;

    private float m_OffsetZ;
    private Vector3 m_LastTargetPosition;
    private Vector3 m_CurrentVelocity;
    private Vector3 m_LookAheadPos;
    private Camera mainCamera;

    // Use this for initialization
    private void Start()
    {
        m_LastTargetPosition = target.position;
        m_OffsetZ = (transform.position - target.position).z;
        transform.parent = null;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isZooming)
        {
            ChangeSize();
        }
    }

    private void FixedUpdate()
    {
        // Only update lookahead position if accelerating or changed direction
        float xMoveDelta = (target.position - m_LastTargetPosition).x;

        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
            m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
            m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

        transform.position = newPos;

        m_LastTargetPosition = target.position;
    }

    public void ChangeSize()
    {
        float size = (mainCamera.orthographicSize - zoomSpeed);
        if (size < minSize || size > maxSize)
        {
            isZooming = false;
        }
        mainCamera.orthographicSize = Mathf.Clamp(size, minSize, maxSize);
    }
}
