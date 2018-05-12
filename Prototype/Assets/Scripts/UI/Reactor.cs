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
    public GameObject resultPopUp;
    public Text resultHeaderText;
    public Text resultText;

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

    public void EndDrag(GameObject target)
    {
        string targetName = target.name.Substring(7);

        for (int i = 0; i < buttons.Count; i++)
        {
            string buttonName = buttons[i].name.Substring(7);

            if (targetName != buttonName)
            {
                float distance = Vector2.Distance(target.transform.position, buttons[i].transform.position);
                if (distance < maxDistance)
                {
                    for (int f = 0; f < fuelObjects.Count; f++)
                    {
                        for (int e = 0; e < fuelObjects[f].elements.Count; e++)
                        {
                            if (targetName == fuelObjects[f].elements[e])
                            {
                                switch (fuelObjects[f].elements[e])
                                {
                                    case "Hydrogen":
                                        buttons[i].gameObject.SetActive(false);
                                        target.gameObject.SetActive(false);
                                        LiquidHydrogen.transform.position = buttons[i].transform.position;
                                        LiquidHydrogen.gameObject.SetActive(true);
                                        PlayAnimation("Great!", "You made Liquid Hydrogen!");
                                        break;
                                    case "Nitrogen":
                                        buttons[i].gameObject.SetActive(false);
                                        target.gameObject.SetActive(false);
                                        Hydrazine.transform.position = buttons[i].transform.position;
                                        Hydrazine.gameObject.SetActive(true);
                                        PlayAnimation("Great!", "You made Liquid Hydrazine!");
                                        break;
                                    case "Oxygen":
                                        buttons[i].gameObject.SetActive(false);
                                        target.gameObject.SetActive(false);
                                        LiquidOxygen.transform.position = buttons[i].transform.position;
                                        LiquidOxygen.gameObject.SetActive(true);
                                        PlayAnimation("Great!", "You made Liquid Oxygen!");
                                        break;
                                    case "Carbon":
                                        buttons[i].gameObject.SetActive(false);
                                        target.gameObject.SetActive(false);
                                        Coal.transform.position = buttons[i].transform.position;
                                        Coal.gameObject.SetActive(true);
                                        PlayAnimation("Darn!", "You made Coal!");
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

    public void PlayAnimation(string title, string text)
    {
        resultPopUp.GetComponent<Animator>().SetTrigger("PopUp");
        resultHeaderText.text = title;
        resultText.text = text;
    }
}
