using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [SerializeField] List<PanelEntries> panelsInput;
    Dictionary<PanelType, GameObject> panels;

    void Awake()
    {
        DontDestroyOnLoad(this);
        FillPanelDict();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayPanel(PanelType pType, object arg)
    {
        if (panels.ContainsKey(pType))
        {
            foreach(var entry in panels)
            {
                entry.Value.SetActive(false);
            }
            panels[pType].SetActive(true);
        }
    }

    void FillPanelDict()
    {
        // Fill the dictionary from the serialized list
        panels = new Dictionary<PanelType, GameObject>();
        foreach (var entry in panelsInput)
        {
            if (entry != null && !panels.ContainsKey(entry.pType))
            {
                panels.Add(entry.pType, entry.panelGO);
            }
            else
            {
                Debug.LogWarning($"Duplicate or null entry for {entry?.pType} in PanelManager.");
            }
        }
    }
}
