using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DayUiController : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMeshProUGUI;
    [SerializeField][Range(0.1f,1f)] float colorLerpSpeed = 1f;
    [SerializeField] Color dayColor;
    [SerializeField] Color nightColor;

    bool isDay = true;

    float timer = 0;
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    
    }

    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime *colorLerpSpeed;
        if(timer > 1)
        {
            timer = 1;
        }
        if (isDay)
            textMeshProUGUI.color = Color.Lerp(dayColor, nightColor, timer);
        else if (!isDay)
            textMeshProUGUI.color = Color.Lerp(nightColor, dayColor, timer);

        if (textMeshProUGUI.color == nightColor)
        {
            isDay = false;
            timer = 0;
        }
        else if (textMeshProUGUI.color == dayColor)
        {
            isDay = true;
            timer = 0;
        }
    }
}
