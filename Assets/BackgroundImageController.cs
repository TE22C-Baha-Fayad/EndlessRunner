using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundImageController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject[] backgroundImages;
    [SerializeField] float xdifferenceConstant = 17.5f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
