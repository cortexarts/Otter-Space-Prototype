using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocks : MonoBehaviour {

	#region Singleton

	public static Unlocks instance;

	private void Awake()
	{
		instance = this;
	}

	#endregion

	private Inventory inventory;

	public List<Reward> rewards;

	public Item armyDefeatItem;
	public Item castleDefeatItem;
	public Item wizardItem;
	public bool armyDefeat;
	public bool castleDefeat;
	public Item armyItem;
	public Item castleItem;
	public Item enemiesTriggerItem01;
	public Item enemiesTriggerItem02;
	public Item enemiesTriggerItem03;
	public Item enemiesTriggerItem04;

	private bool wizardAdded = false;
	private bool enemiesAdded = false;

	private void Start()
	{
		inventory = Inventory.instance;
		rewards = new List<Reward>(Resources.LoadAll<Reward>("Rewards"));
	}

	private void Update()
	{
		Reward[] rewardsArray = rewards.ToArray();
		foreach (Reward reward in rewardsArray)
		{
			if (reward.itemsRequired == inventory.GetAmount() && reward.itemsRequired != 0)
			{
				Unlock(reward);
				rewards.Remove(reward);
			}
		}
	}

	void Unlock (Reward reward)
	{
		foreach (Item item in reward.items)
		{
			Debug.Log(item.name + " UNLOCKED!!!");
			Discoveries.instance.Discover(item);
			Inventory.instance.AddItem(item, false);
		}
	}

	public void OnItemAdded (Item item)
	{
		if (!wizardAdded)
		{
			if (item == castleDefeatItem)
				castleDefeat = true;

			if (item == armyDefeatItem)
				armyDefeat = true;

			if (castleDefeat && armyDefeat)
			{
				wizardAdded = true;
				Discoveries.instance.Discover(wizardItem);
				Inventory.instance.AddItem(wizardItem, false);
			}
		}

		if (!enemiesAdded)
		{
			if(	item == enemiesTriggerItem01 || item == enemiesTriggerItem02 ||
				item == enemiesTriggerItem03 || item == enemiesTriggerItem04)
			{
				enemiesAdded = true;

				Discoveries.instance.Discover(castleItem);
				Inventory.instance.AddItem(castleItem, false);

				Discoveries.instance.Discover(armyItem);
				Inventory.instance.AddItem(armyItem, false);
			}
		}
		
	}

}
