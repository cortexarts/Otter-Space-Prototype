using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicTable : MonoBehaviour
{
    #region Singleton

    public static PeriodicTable instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    [SerializeField]
    private PeriodicTableItem[] m_Elements;
    [SerializeField]
    private GameObject m_ElementPrefab;
    [SerializeField]
    private GameObject m_Placeholder;
    [SerializeField]
    private Transform[] m_Columns;

    private PeriodicTableItem[,] m_ColumnTableArray = new PeriodicTableItem[20, 15];
    private List<GameObject> m_Items;

    // Use this for initialization
    void Start ()
    {
        m_Items = new List<GameObject>();
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

        m_Items.Add(element);
    }

    public void AddPlaceholder(Transform transform)
    {
        Instantiate(m_Placeholder, transform);
    }

    public void CheckDiscoveredStatusWithSymbol(string a_Symbol)
    {
        for(int i = 0; i < m_Items.Count; i++)
        {
            if(m_Items[i].GetComponent<PeriodicTableDisplay>().GetItem().GetSymbol() == a_Symbol)
            {
                if(m_Items[i].GetComponent<PeriodicTableDisplay>().GetItem().GetDiscoveredStatus() == false)
                {
                    m_Items[i].GetComponent<PeriodicTableDisplay>().SetDiscovered(true);
                }
            }
        }
    }

    public void CheckDiscoveredStatus(PeriodicTableItem a_Element)
    {
        for(int i = 0; i < m_Items.Count; i++)
        {
            if(m_Items[i].GetComponent<PeriodicTableDisplay>().GetItem().GetSymbol() == a_Element.GetSymbol())
            {
                if(m_Items[i].GetComponent<PeriodicTableDisplay>().GetItem().GetDiscoveredStatus() == false)
                {
                    m_Items[i].GetComponent<PeriodicTableDisplay>().SetDiscovered(true);
                }
            }
        }
    }
}
