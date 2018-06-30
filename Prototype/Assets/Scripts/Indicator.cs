﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public Texture2D icon; //The icon. Preferably an arrow pointing upwards.
    public Vector4 RGBA;
    public float iconSize = 15f;
    [HideInInspector]
    public GUIStyle gooey; //GUIStyle to make the box around the icon invisible. Public so that everything has the default stats.
    Vector2 indRange;
    float scaleRes = Screen.width / 500; //The width of the screen divided by 500. Will make the GUI scale automatically.
    public string m_ObjectName;
    Camera cam;
    bool visible = true; //Whether or not the object is visible in the camera.

    void Start()
    {
        visible = false;

        cam = Camera.main; //Don't use Camera.main in a looping method, its very slow, as Camera.main actually
                           //does a GameObject.Find for an object tagged with MainCamera.

        indRange.x = Screen.width - (Screen.width / 6);
        indRange.y = Screen.height - (Screen.height / 7);
        indRange /= 2f;

        gooey.normal.textColor = new Vector4(0, 0, 0, 0); //Makes the box around the icon invisible.
        m_ObjectName = "Asteroid";
    }

    void OnGUI()
    {
        if (!visible)
        {
            Vector3 dir = transform.position - cam.transform.position;
            dir = Vector3.Normalize(dir);
            dir.y *= -1f;

            Vector2 indPos = new Vector2(indRange.x * dir.x, indRange.y * dir.y);
            indPos = new Vector2((Screen.width / 2) + indPos.x,
                              (Screen.height / 2) + indPos.y);

            Vector3 pdir = transform.position - cam.ScreenToWorldPoint(new Vector3(indPos.x, indPos.y,
                                                                                    transform.position.z));
            pdir = Vector3.Normalize(pdir);

            float angle = Mathf.Atan2(pdir.x, pdir.y) * Mathf.Rad2Deg;

            GUI.color = new Color(RGBA.x, RGBA.y, RGBA.z, RGBA.w);
            GUI.Label(new Rect(indPos.x, indPos.y, scaleRes * iconSize * 2, scaleRes * iconSize), m_ObjectName);
            GUIUtility.RotateAroundPivot(angle, indPos); //Rotates the GUI. Only rotates GUI drawn after the rotate is called, not before.
            GUI.Box(new Rect(indPos.x, indPos.y, scaleRes * iconSize, scaleRes * iconSize), icon, gooey);
            GUIUtility.RotateAroundPivot(0, indPos); //Rotates GUI back to the default so that GUI drawn after is not rotated.
            RGBA.w -= Time.deltaTime * 0.2f;
        }
    }

    void OnBecameInvisible()
    {
        visible = false;
    }

    //Turns off the indicator if object is onscreen.
    void OnBecameVisible()
    {
        visible = true;
    }
}
