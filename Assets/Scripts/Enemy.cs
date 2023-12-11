using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyBullet;
    public GameObject EnemyBullets;
    
    private float _bulletInteval = 0.5f;
    
    private void Start()
    {
        EnemyBullets = GameObject.Find("EnemyBullets") ?? new GameObject("EnemyBullets");    
        
        InvokeRepeating("GenerateBullet", 0f, _bulletInteval);
    
        transform.rotation = Quaternion.Euler(0f, 0f, 270f);
    }

    private void Update()
    {
    }
    
    private void GenerateBullet()
    {
        GameObject newBullet = Instantiate(EnemyBullet, Vector3.zero, Quaternion.Euler(0f, 0f, 270f), EnemyBullets.transform);
        newBullet.transform.position = gameObject.transform.position + Vector3.down;
    }
}
