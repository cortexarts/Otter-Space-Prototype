using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject {

	public Sprite icon;
    public string m_Symbol;
	[TextArea]
	public string discoveryText;
	public string discoveryTitle;

	public Color customColor;

	public string customSound;

	[HideInInspector]
	public GameObject itemObject;

}
