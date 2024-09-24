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

    float imageWidth;
    void Start()
    {
        imageWidth = backgroundImages[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x ;
        print("image width"+imageWidth);
    }

    // Update is called once per frame
    void Update()
    {
        print(imageWidth);
        
        
        float image0BackgroundX = backgroundImages[1].transform.position.x - imageWidth/2;
        print(image0BackgroundX);
        if (playerTransform.localPosition.x > image0BackgroundX)
        { 
            print("Entered Night State");
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
