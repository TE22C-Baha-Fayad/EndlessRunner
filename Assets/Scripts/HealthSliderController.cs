using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderController : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider slider;
    private void OnEnable()
    {
        PlayerController.OnPlayerHit += PlayerController_OnPlayerHit;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerHit -= PlayerController_OnPlayerHit;
    }
    private void PlayerController_OnPlayerHit(int ammount)
    {
        slider.value -= ammount/100f;
        
    }

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
