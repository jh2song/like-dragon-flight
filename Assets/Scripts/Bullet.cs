using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5f;
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;
        
        if (transform.position.y > 7.0f)
            Destroy(this.gameObject);
    }
}