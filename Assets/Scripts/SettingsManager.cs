using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static bool music = true;
    [SerializeField] Sprite[] sprites;
    public static Sprite chosenSprite;
    Toggle musicToggle;
    // Start is called before the first frame update

    public void OnCharacterChanged(int index)
    {
      chosenSprite = sprites[index];
    }
    void Start()
    {
        musicToggle = GetComponent<Toggle>();
        
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null ) 
        spriteRenderer.sprite = chosenSprite;

    }
    void Update()
    {
        if(musicToggle != null) 
        music = musicToggle.isOn;
    }
}
