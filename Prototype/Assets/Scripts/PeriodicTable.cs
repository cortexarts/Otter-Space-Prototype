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
    private Transform m_Table;

    private PeriodicTableItem[,] m_TableArray = new PeriodicTableItem[18,7];

    // Use this for initialization
    void Start ()
    {
        m_Elements = Resources.LoadAll<PeriodicTableItem>("Elements");

        for(int i = 0; i < m_Elements.Length; i++)
        {
            m_TableArray[m_Elements[i].GetColumn() - 1, m_Elements[i].GetPeriod() - 1] = m_Elements[i];
        }

        for(int i = 0; i < 18; i++)
        {
            for(int j = 0; j < 7; j++)
            {
                if(m_TableArray[i, j] != null)
                {
                    AddElement(m_TableArray[i, j]);
                }
                else
                {
                    AddPlaceholder();
                }
            }
        }

        //for(int i = 0; i < 18; i++)
        //{
        //    for(int j = 0; j < 7; j++)
        //    {
        //        bool exists = false;
        //        for(int k = 0; k < m_Elements.Length; k++)
        //        {
        //            if(m_Elements[k].GetColumn() == i && m_Elements[k].GetPeriod() == j)
        //            {
        //                exists = true;
        //                AddElement(m_Elements[k]);
        //            }
        //        }

        //        if(!exists)
        //        {
        //            AddPlaceholder();
        //        }
        //    }
        //}
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void AddElement(PeriodicTableItem a_Element)
    {
        GameObject element = Instantiate(m_ElementPrefab, m_Table);

        PeriodicTableDisplay display = element.GetComponent<PeriodicTableDisplay>();

        if(display != null)
        {
            display.Setup(a_Element);
        }
    }

    public void AddPlaceholder()
    {
        GameObject placeholder = Instantiate(m_Placeholder, m_Table);
    }
}
