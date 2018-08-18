using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Music : Sound
{
    [SerializeField]
    private bool m_Loop = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetLoop(bool a_Loop)
    {
        m_Loop = a_Loop;
    }

    public bool GetLoop()
    {
        return m_Loop;
    }
}
