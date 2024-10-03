using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TrapSpawnerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] traps;
    //include red, green and yellow traps
    private void OnEnable()
    {
        DayUiController.OnDayShiftIncrement += DayUiController_OnDayCounterIncrease;
    }

    private void OnDisable()
    {
        DayUiController.OnDayShiftIncrement -= DayUiController_OnDayCounterIncrease;
    }
    GameObject lastInstance;
    GameObject instance;
    SpriteRenderer spriteRenderer;
    private void DayUiController_OnDayCounterIncrease()
    {
        int randomIndex = Random.Range(0, traps.Length);
        Vector3 positionNoise = Random.Range(4, 12) * Vector3.right;

        if(player != null)
        {
            Vector3 newPosition = player.transform.position + Vector3.right * 10 + positionNoise;
            newPosition.y = -2.48f;
            instance = Instantiate(traps[randomIndex], newPosition, Quaternion.identity);
        }
        int RandomColorIndex = Random.Range(0, 3);
        Color[] colors = new Color[3] {Color.red,Color.white,Color.green};
        spriteRenderer = instance.GetComponent<SpriteRenderer>();
        //spriteRenderer.color = Color.Lerp(spriteRenderer.color, colors[RandomColorIndex], 0.5f*Mathf.Sin(0.4f*Time.time)+0.5f);
        Destroy(lastInstance, 3);
        lastInstance = instance;
    }
    private void Update()
    {
        float sinValue1 = 0.5f * Mathf.Sin(2.4f * Time.time+5) + 0.5f;
        float sinValue2 = 0.5f * Mathf.Sin(2.1f * Time.time+15) + 0.5f;
        float sinValue3 = 0.5f * Mathf.Sin(3.2f * Time.time+20) + 0.5f;

        if(spriteRenderer != null)
        spriteRenderer.color = new Color(sinValue1, sinValue2, sinValue3, 1);
        

    }
}
