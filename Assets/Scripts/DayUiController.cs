using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DayUiController : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMeshProUGUI;
    [SerializeField][Range(0.1f, 1f)] float colorLerpSpeed = 1f;
    [SerializeField] Color dayColor;
    [SerializeField] Color nightColor;

    public delegate void DayShiftIncrement();
    public static event DayShiftIncrement OnDayShiftIncrement;
    int daysCounter = 0;

    bool isDay = true;

    float timer = 0;

    private void OnEnable()
    {
        BackgroundImageController.OnDayTimeStateChanged += BackgroundImageController_OnDayTimeStateChanged;
    }
    private void OnDisable()
    {
        BackgroundImageController.OnDayTimeStateChanged -= BackgroundImageController_OnDayTimeStateChanged;
    }
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void BackgroundImageController_OnDayTimeStateChanged(bool isDay)
    {
        timer = 0;
        this.isDay = isDay;
        if (!isDay)
            daysCounter++;
            OnDayShiftIncrement?.Invoke();

        textMeshProUGUI.text = "Day " + daysCounter.ToString();
    }



    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * colorLerpSpeed;
        if (timer > 1)
        {
            timer = 1;
        }
        if (isDay)
            textMeshProUGUI.color = Color.Lerp(dayColor, nightColor, timer);
        else if (!isDay)
            textMeshProUGUI.color = Color.Lerp(nightColor, dayColor, timer);


    }
}
