using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndFlightPanel : MonoBehaviour, IPanel
{
    [SerializeField] private Button backToMapButton;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private FlightController fcontroller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backToMapButton.onClick.AddListener(fcontroller.SwitchToFlightMain);
    }

    public void ShowPanel(object arg)
    {
        if (arg is BirdType bird)
        {
            nameText.text = bird.ToString();
            titleText.text = (bird == BirdType.Dead) ? "Flight interrupted :( \n Your bird is :"
                : "Congratulation ! \n You unlocked :";
            
        }
        else
        {
            Debug.Log("invalid arg");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
