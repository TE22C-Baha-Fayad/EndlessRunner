using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BackgroundImageController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject[] backgroundImages;
    [SerializeField] float xdifferenceConstant = 17.5f;

    public delegate void DayTimeState(bool isDay);
    public static event DayTimeState OnDayTimeStateChanged;
    [SerializeField] Transform dayStartReference;
    [SerializeField] Transform nightStartReference;
    bool isDayStartFactor = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        float positionExtender = 11.5f;

        if (playerTransform.localPosition.x +positionExtender > dayStartReference.position.x && playerTransform.localPosition.x < dayStartReference.position.x + 1f && isDayStartFactor)
        {
            //day state entered
            OnDayTimeStateChanged?.Invoke(false);
            isDayStartFactor = false;
        }
        if (playerTransform.localPosition.x+positionExtender > nightStartReference.position.x && playerTransform.position.x < nightStartReference.position.x + 1 && !isDayStartFactor)
        {
            //night state entered
            OnDayTimeStateChanged?.Invoke(true);

            isDayStartFactor =true;
        }



        if (playerTransform.localPosition.x > backgroundImages[0].transform.position.x + xdifferenceConstant)
        {

            backgroundImages[0].transform.position += new Vector3(2 * xdifferenceConstant, 0, 0);
        }
        if (playerTransform.localPosition.x > backgroundImages[1].transform.position.x + xdifferenceConstant)
        {

            backgroundImages[1].transform.position += new Vector3(2 * xdifferenceConstant, 0, 0);
        }
    }
}
