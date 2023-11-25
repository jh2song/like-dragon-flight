using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(0f, -4f, 0f);
    }

    // Update is called once per frame
    private void Update()
    {   
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(Mathf.Clamp(worldPos.x, -2.7f, 2.7f), 
            transform.position.y, 
            transform.position.z);
    }
}