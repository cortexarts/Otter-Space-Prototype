using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPool : MonoBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		if (DragHandler.objBeingDragged == null)
			return;

		DragHandler.objBeingDragged.transform.SetParent(transform);

		Item item = DragHandler.GetItemBeingDragged();

		if (!Inventory.instance.HasItem(item))
			Inventory.instance.AssignItem(item);
	}
}
