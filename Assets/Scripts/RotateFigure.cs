using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateFigure : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 50f;
    // Start is called before the first frame update
    [SerializeField] Texture[] sprites;
    public void OnCharacterChanged(int index)
    {

        GetComponent<RawImage>().texture = sprites[index];     
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotateSpeed*Time.deltaTime,Space.Self);
    }
}
