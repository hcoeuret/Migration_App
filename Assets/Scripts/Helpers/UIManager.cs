using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    //Set as a singleton
    public static UIManager Instance { get; private set; }

    [SerializeField] List<PanelEntries> panelsInput;
    Dictionary<PanelType, GameObject> panels;

    public void DisplayPanel(PanelType pType, object arg)
    {
        if (panels.ContainsKey(pType))
        {
            foreach(var entry in panels)
            {
                entry.Value.SetActive(false);
            }
            panels[pType].SetActive(true);
            panels[pType].GetComponent<IPanel>()?.ShowPanel(arg);            ;
        }
    }

    protected void FillPanelDict()
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
