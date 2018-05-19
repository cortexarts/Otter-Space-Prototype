using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Reward", menuName = "Reward")]
public class Reward : ScriptableObject
{
	public int itemsRequired;
	public Item[] items;
}
