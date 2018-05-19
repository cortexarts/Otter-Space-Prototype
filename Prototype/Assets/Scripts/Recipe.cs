using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject {

	public Item input01;
	public Item input02;

	public Item result;

	public Item altInput01;
	public Item altInput02;

	public Item alt02Input01;
	public Item alt02Input02;

}
