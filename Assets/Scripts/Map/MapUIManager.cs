using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MapUIManager : MonoBehaviour
{
 
    [SerializeField] List<PanelEntries> panelsInput;
    Dictionary<PanelType, GameObject> panels;

    void Awake()
    {
        FillPanelDict();
        DisplayPanel(PanelType.MapMainPanel, null);
    }

    public void DisplayPanel(PanelType pType, object arg)
    {
        if (panels.ContainsKey(pType))
        {
            foreach (var entry in panels)
            {
                entry.Value.SetActive(false);
            }
            panels[pType].SetActive(true);

            // Find the component implementing IPanel
            var panelInterface = panels[pType].GetComponent<IPanel>();
            if (panelInterface != null)
            {
                panelInterface.ShowPanel(arg);
            }
            else
            {
                Debug.LogWarning($"Panel {pType} does not implement IPanel interface.");
            }
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
