using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static bool music = true;

    Toggle musicToggle;
    // Start is called before the first frame update
    void Start()
    {
        musicToggle = GetComponent<Toggle>();

    }
    void Update()
    {
        music = musicToggle.isOn;
    }
}
