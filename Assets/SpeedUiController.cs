using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpeedUiController : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMeshProUGUI;
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = "Speed: " + PlayerController.speed.ToString("0.0")+"m/s";
    }
}
