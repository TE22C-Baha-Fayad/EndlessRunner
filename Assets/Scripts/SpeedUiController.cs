using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpeedUiController : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMeshProUGUI;
    private void OnEnable()
    {
        PlayerController.OnSpeedReport += PlayerController_OnSpeedReport;
    }
    private void OnDisable()
    {
        PlayerController.OnSpeedReport -= PlayerController_OnSpeedReport;
    }
    void Start()
    {
        
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        
    }

    private void PlayerController_OnSpeedReport(float speed)
    {
        textMeshProUGUI.text = "Speed: " + speed.ToString("0.0") + "m/s";
    }


}
