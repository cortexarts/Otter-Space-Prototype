using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject {

	public Sprite icon;
	[TextArea]
	public string discoveryText;
	public string discoveryTitle;

	public Color customColor = Color.black;

	public string customSound;

	[HideInInspector]
	public GameObject itemObject;

}
