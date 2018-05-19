using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialCounter : MonoBehaviour {

	public Text counterText;
	private int totalNumOfMats;

	private void Start()
	{
		totalNumOfMats = Resources.LoadAll<Item>("Items").Length;
	}

	private void Update()
	{
		int numOfItems = Inventory.instance.items.Count;
		counterText.text = numOfItems + "/" + totalNumOfMats;
	}

}
