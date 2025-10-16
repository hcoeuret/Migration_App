using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class FlightUIManager : UIManager
{   void Awake()
    {
        base.FillPanelDict();
        DisplayPanel(PanelType.FlightMainPanel, null);
    }

}
