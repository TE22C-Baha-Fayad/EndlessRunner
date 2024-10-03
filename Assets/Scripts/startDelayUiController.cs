using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class startDelayUiController : MonoBehaviour
{

    TextMeshProUGUI textMeshProUGUI;
    int DelayAmmount;

    private void OnEnable()
    {
        PlayerController.OnFunctionalityDelayReport += PlayerController_OnFunctionalityDelayReport;
    }

    private void OnDisable()
    {
        PlayerController.OnFunctionalityDelayReport -= PlayerController_OnFunctionalityDelayReport;
    }
    private void PlayerController_OnFunctionalityDelayReport(int ammountSeconds)
    {
        DelayAmmount = ammountSeconds;
    }

    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = DelayAmmount.ToString();
    }

    // Update is called once per frame
    float textChangeTimer = 0;
    void Update()
    {
        textChangeTimer += Time.deltaTime;
        if (textChangeTimer > 1)
        {
            DelayAmmount--;
            textChangeTimer = 0;
        }
        if (DelayAmmount >0)
        {
            textMeshProUGUI.text = "   " + (DelayAmmount).ToString();
        }
        else if (DelayAmmount == 0)
        {
            textMeshProUGUI.text = "Start";
        }
        else
        {
            gameObject.SetActive(false);
        }
        
        
    }
}
