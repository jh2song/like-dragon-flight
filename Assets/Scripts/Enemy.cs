using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyBullet;
    public GameObject EnemyBullets;
    
    private float _bulletInteval = 2f;
    
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
    
    public void EnableInvincibility(float duration)
    {
        StartCoroutine(InvincibilityCoroutine(duration));
    }

    private IEnumerator InvincibilityCoroutine(float duration)
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.enabled = false; // 무적 시작
            yield return new WaitForSeconds(duration); // 지정된 시간 동안 기다림
            collider.enabled = true; // 무적 해제
        }
    }
}
