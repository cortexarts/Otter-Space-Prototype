using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicTable : MonoBehaviour
{
    [SerializeField]
    private PeriodicTableItem[] m_Elements;
    [SerializeField]
    private GameObject m_ElementPrefab;
    [SerializeField]
    private GameObject m_Placeholder;
    [SerializeField]
    private Transform[] m_Columns;

    private PeriodicTableItem[,] m_ColumnTableArray = new PeriodicTableItem[20, 15];

    // Use this for initialization
    void Start ()
    {
        m_Elements = Resources.LoadAll<PeriodicTableItem>("Elements");

        for(int i = 0; i < m_Elements.Length; i++)
        {
            m_ColumnTableArray[m_Elements[i].GetColumn() - 1, m_Elements[i].GetPeriod() - 1] = m_Elements[i];
        }

        for(int i = 0; i < 18; i++)
        {
            for(int j = 0; j < 7; j++)
            {
                if(m_ColumnTableArray[i, j] != null)
                {
                    AddElement(m_ColumnTableArray[i, j], m_Columns[i]);
                }
                else
                {
                    AddPlaceholder(m_Columns[i]);
                }
            }
        }

        for(int i = 18; i < 20; i++)
        {
            for(int j = 0; j < 15; j++)
            {
                if(m_ColumnTableArray[i, j] != null)
                {
                    AddElement(m_ColumnTableArray[i, j], m_Columns[i]);
                }
                else
                {
                    AddPlaceholder(m_Columns[i]);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void AddElement(PeriodicTableItem a_Element, Transform transform)
    {
        GameObject element = Instantiate(m_ElementPrefab, transform);

        PeriodicTableDisplay display = element.GetComponent<PeriodicTableDisplay>();

        if(display != null)
        {
            display.Setup(a_Element);
        }
    }

    public void AddPlaceholder(Transform transform)
    {
        Instantiate(m_Placeholder, transform);
    }
}
