using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class FlightUIManager : UIManager
{
    [SerializeField] Camera cam;
    void Awake()
    {
        base.FillPanelDict();
        DisplayPanel(PanelType.FlightMainPanel, null);
    }

    public void ShowEndOfFlight(BirdType bird)
    {
        DisplayPanel(PanelType.FlightEndPanel, bird);
    }

    public void ShowMainFlight()
    {
        DisplayPanel(PanelType.FlightMainPanel, null);
    }

}
