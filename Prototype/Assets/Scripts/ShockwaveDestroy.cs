using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveDestroy : MonoBehaviour {

    public AnimationClip Shockwave;
    private float AnimationTime;

	// Use this for initialization
	void Start () {
        AnimationTime = Shockwave.length;
    }

    // Update is called once per frame
    void Update () {
        AnimationTime -= Time.deltaTime;
        if (AnimationTime <= 0) DestroyObject(this.gameObject);
    }
}
