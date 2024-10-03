using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class backgroundSoundController : MonoBehaviour
{
    // Start is called before the first frame update
    
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }
    private void Update()
    {
        GameObject childObject = transform.GetChild(0).gameObject;
        if (SettingsManager.music)
        {
          childObject.SetActive(true);
        }
        else
        {
            childObject.SetActive(false);
        }
    }


}
