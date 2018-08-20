using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgorundMusic : MonoBehaviour {

    [SerializeField]
    private string m_Clip;

	// Use this for initialization
	void Start ()
    {
        AudioManager.m_Instance.PlayMusic(m_Clip);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
