using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float Speed { get; set; } = 3f;

    private void Update()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
        
        if (transform.position.y < -7.0f)
            Destroy(this.gameObject);
    }
    
}
