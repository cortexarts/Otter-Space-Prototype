using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Element", menuName = "Item/Element")]
public class PeriodicTableItem : ScriptableObject
{
    [SerializeField]
    private string m_Symbol;
    [SerializeField]
    private int m_Number;
    [SerializeField]
    private Color m_Color = Color.black;
    [SerializeField]
    private bool m_IsDiscovered = false;
    [SerializeField]
    private int m_Column;
    [SerializeField]
    private int m_Period;

    public string GetSymbol()
    {
        return m_Symbol;
    }

    public int GetNumber()
    {
        return m_Number;
    }

    public int GetColumn()
    {
        return m_Column;
    }

    public int GetPeriod()
    {
        return m_Period;
    }

    public Color GetColor()
    {
        return m_Color;
    }

    public bool GetDiscoveredStatus()
    {
        return m_IsDiscovered;
    }

    public void SetDiscoveredStatus(bool a_Status)
    {
        m_IsDiscovered = a_Status;
    }
}
