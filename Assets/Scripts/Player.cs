using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _bulletInteval = 0.1f;
    
    public GameObject Bullet;
    private GameObject BulletsContainer;
    
    private void Start()
    {
        transform.position = new Vector3(0f, -4f, 0f);
        
        BulletsContainer = GameObject.Find("Bullets") ?? new GameObject("Bullets");
        InvokeRepeating("GenerateBullet", 0f, _bulletInteval);
    }

    private void Update()
    {   
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(Mathf.Clamp(worldPos.x, -2.7f, 2.7f), 
            transform.position.y, 
            transform.position.z);
    }
    
    private void GenerateBullet()
    {
        GameObject newBullet = Instantiate(Bullet, Vector3.zero, Quaternion.Euler(0f, 0f, 90f), BulletsContainer.transform);
        newBullet.transform.position = transform.position + Vector3.up;
    }
}
