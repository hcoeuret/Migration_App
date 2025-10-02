using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [SerializeField] Dictionary<PanelType, IPanel> panels;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayPanel(object arg)
    {

    }
}
