using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainFlightPanel : MonoBehaviour, IPanel
{
    [SerializeField] private Slider timeLeftSlider;
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private Button cancelButton;
    private Coroutine timerCoroutine;

    private int counterValue = 0;   
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void ShowPanel(object arg)
    {
        counterValue = AppState.Instance.counter;
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
        timerCoroutine = StartCoroutine(TimerCoroutine());
    }
    void Start()
    {
        timerCoroutine = null;
        cancelButton.onClick.AddListener(CancelWait);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CancelWait()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }

        AppManager.Instance.SwitchToMapScene();
    }

    private IEnumerator TimerCoroutine()
    {
        

        while (counterValue > 0)
        {
            counterText.text = counterValue.ToString();
            yield return new WaitForSeconds(1f);
            counterValue--;
        }


    }
}
