using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed =1f;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Vector3 cameraPosition = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(transform.position.x, cameraPosition.y,cameraPosition.z);
    }
}
