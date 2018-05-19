using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : MonoBehaviour
{

	#region Singleton

	public static Crafter instance;

	private void Awake()
	{
		instance = this;
	}

	#endregion

	public Item slot01;
	public Item slot02;

	public Recipe[] recipes;

	public Transform resultsParent;
	public GameObject itemPrefab;
	public GameObject ghostItemPrefab;

	private List<Item> knownItems;

	private void Start()
	{
		recipes = Resources.LoadAll<Recipe>("Recipes");
	}

	public void AddItem(Item item, int slot)
	{
		//Debug.Log("Add item to Crafter: " + item.name);

		if (slot == 1)
		{
			slot01 = item;
		} else if (slot == 2)
		{
			slot02 = item;
		}

		UpdateResult();
	}

	public void RemoveItem(int slot)
	{
		//Debug.Log("Remove from slot " + slot);

		if (slot == 1)
		{
			slot01 = null;
		} else if (slot == 2)
		{
			slot02 = null;
		}

		UpdateResult();
	}

	void UpdateResult()
	{
		ClearPreviousResult();

		Item[] results = GetResults();
		Item[] resultsInInventory = GetResultsInInventory();
		if (results != null && results.Length != 0)
		{
			foreach (Item result in results)
			{
				CreateItem(result);
			}
		}

		if (resultsInInventory != null && resultsInInventory.Length != 0)
		{
			foreach (Item result in resultsInInventory)
			{
				CreateGhostItem(result);
			}
		}
	}

	void CreateItem (Item item)
	{
		GameObject itemObj = Instantiate(itemPrefab, resultsParent);
		ItemDisplay display = itemObj.GetComponent<ItemDisplay>();
		if (display != null)
			display.Setup(item);

		Animator anim = itemObj.GetComponent<Animator>();
		anim.SetBool("Pickup", false);

		if (!Discoveries.instance.HasDiscovered(item))
		{
			Discoveries.instance.Discover(item);
		}
	}

	void CreateGhostItem (Item item)
	{
		GameObject itemObj = Instantiate(ghostItemPrefab, resultsParent);
		ItemDisplay display = itemObj.GetComponent<ItemDisplay>();

		if (display != null)
			display.Setup(item);
	}

	void ClearPreviousResult ()
	{
		foreach (Transform child in resultsParent)
		{
			Destroy(child.gameObject);
		}
	}

	Item[] GetResults ()
	{
		if (slot01 == null || slot02 == null)
			return null;

		List<Item> items = new List<Item>();

		foreach (Recipe recipe in recipes)
		{
			if ((recipe.input01 == slot01 && recipe.input02 == slot02) ||
				(recipe.input01 == slot02 && recipe.input02 == slot01) ||
				(recipe.altInput01 == slot02 && recipe.altInput02 == slot01) ||
				(recipe.altInput02 == slot02 && recipe.altInput01 == slot01) ||
				(recipe.alt02Input01 == slot02 && recipe.alt02Input02 == slot01) ||
				(recipe.alt02Input02 == slot02 && recipe.alt02Input01 == slot01))
			{
				if (!Inventory.instance.HasItem(recipe.result))
				{
					items.Add(recipe.result);
				}
			}
		}

		return items.ToArray();
	}

	Item[] GetResultsInInventory()
	{
		if (slot01 == null || slot02 == null)
			return null;

		List<Item> items = new List<Item>();

		foreach (Recipe recipe in recipes)
		{
			if ((recipe.input01 == slot01 && recipe.input02 == slot02) ||
				(recipe.input01 == slot02 && recipe.input02 == slot01) ||
				(recipe.altInput01 == slot02 && recipe.altInput02 == slot01) ||
				(recipe.altInput02 == slot02 && recipe.altInput01 == slot01) ||
				(recipe.alt02Input01 == slot02 && recipe.alt02Input02 == slot01) ||
				(recipe.alt02Input02 == slot02 && recipe.alt02Input01 == slot01))
			{
				if (Inventory.instance.HasItem(recipe.result))
				{
					items.Add(recipe.result);
				}
			}
		}

		return items.ToArray();
	}

}
