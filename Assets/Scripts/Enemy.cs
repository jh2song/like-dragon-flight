using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyBullet;

    private float _bulletInteval = 0.5f;
    
    private void Start()
    {
        InvokeRepeating("GenerateBullet", 0f, _bulletInteval);
    }

    private void Update()
    {
    }
    
    private void GenerateBullet()
    {
        GameObject newBullet = Instantiate(EnemyBullet, Vector3.zero, Quaternion.Euler(0f, 0f, 270f), gameObject.transform);
        newBullet.transform.position = gameObject.transform.position + Vector3.down;
    }
}
