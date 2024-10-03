using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreDiplayController : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMeshProUGUI;
    int score;
    private void OnEnable()
    {
        PlayerController.OnDayCountReport += PlayerController_OnDayCountReport;
    }

    private void OnDisable()
    {
        PlayerController.OnDayCountReport -= PlayerController_OnDayCountReport;
    }
    private void PlayerController_OnDayCountReport(int count)
    {
        score = count;
    }


    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = $"Score: {score/2} Days";
    }
}
