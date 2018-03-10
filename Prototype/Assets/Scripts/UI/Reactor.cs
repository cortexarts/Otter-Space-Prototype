using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Reactor : MonoBehaviour
{
    public List<FuelObject> fuelObjects;
    public Button LiquidHydrogen;
    public Button Methane;
    public Button Hydrazine;
    public Button LiquidOxygen;
    public Button Coal;
    public List<Button> buttons;
    public List<string> names;

    public float maxDistance;

    private float offsetX;
    private float offsetY;

    public void BeginDrag(GameObject target)
    {
        offsetX = target.transform.position.x - Input.mousePosition.x;
        offsetY = target.transform.position.y - Input.mousePosition.y;
    }

    public void OnDrag(GameObject target)
    {
        target.transform.position = new Vector3(offsetX + Input.mousePosition.x, offsetY + Input.mousePosition.y);
    }

    public void EndDrag()
    {
        for (int i = 0; i < buttons.Count - 1; i++)
        {
            for (int j = 1; j < buttons.Count; j++)
            {
                float distance = Vector2.Distance(buttons[i].transform.position, buttons[j].transform.position);
                if (distance < maxDistance)
                {
                    for (int f = 0; f < fuelObjects.Count; f++)
                    {
                        for (int e = 0; e < fuelObjects[f].elements.Count; e++)
                        {
                            if (names[e] == fuelObjects[f].elements[e])
                            {
                                if (fuelObjects[f].elements[e] == names[e])
                                {
                                    switch (fuelObjects[f].elements[e])
                                    {
                                        case "Hydrogen":
                                            buttons[i].gameObject.SetActive(false);
                                            buttons[j].gameObject.SetActive(false);
                                            LiquidHydrogen.transform.position = buttons[i].transform.position;
                                            LiquidHydrogen.gameObject.SetActive(true);
                                            break;
                                        case "Nitrogen":
                                            buttons[i].gameObject.SetActive(false);
                                            buttons[j].gameObject.SetActive(false);
                                            Hydrazine.transform.position = buttons[i].transform.position;
                                            Hydrazine.gameObject.SetActive(true);
                                            break;
                                        case "Oxygen":
                                            buttons[i].gameObject.SetActive(false);
                                            buttons[j].gameObject.SetActive(false);
                                            LiquidOxygen.transform.position = buttons[i].transform.position;
                                            LiquidOxygen.gameObject.SetActive(true);
                                            break;
                                        case "Carbon":
                                            buttons[i].gameObject.SetActive(false);
                                            buttons[j].gameObject.SetActive(false);
                                            Coal.transform.position = buttons[i].transform.position;
                                            Coal.gameObject.SetActive(true);
                                            break;
                                        default:
                                            Debug.LogWarning("No reaction results!");
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
