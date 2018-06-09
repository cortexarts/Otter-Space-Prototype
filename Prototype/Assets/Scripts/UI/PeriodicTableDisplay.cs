using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeriodicTableDisplay : MonoBehaviour
{
    [SerializeField]
    private PeriodicTableItem m_Item;
    [SerializeField]
    private Text m_Symbol;
    [SerializeField]
    private Text m_Number;

    public void Setup(PeriodicTableItem a_Item)
    {
        m_Item = a_Item;
        m_Symbol.text = a_Item.GetSymbol();
        m_Number.text = a_Item.GetNumber().ToString();
        GetComponent<Image>().color = m_Item.GetColor();
    }
}
