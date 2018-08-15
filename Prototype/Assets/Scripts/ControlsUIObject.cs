using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Control", menuName = "Control")]
public class ControlsUIObject : ScriptableObject
{
    public Sprite m_Sprite;
    public string m_Title;
    public string m_Description;
}
