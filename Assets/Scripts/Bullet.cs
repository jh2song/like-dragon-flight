using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5f;

    private GameObject _enemyPool;
    
    private void Start()
    {
        _enemyPool = GameObject.Find("EnemyPool");

        if (_enemyPool == null)
        {
            Debug.Log("Bullet 클래스에서 EnemyPool 오브젝트를 찾을 수 없음");
        }
    }

    private void Update()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;
        
        if (transform.position.y > 7.0f)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("EnemyClone"))
        {
            Destroy(other.gameObject);
            StartCoroutine(CheckEnemiesAndLevelUp());
        }
    }

    private IEnumerator CheckEnemiesAndLevelUp()
    {
        yield return new WaitForEndOfFrame(); // 현재 프레임이 끝나기를 기다립니다.

        if (_enemyPool.transform.childCount == 0)
        {
            GameManager.Level++;

            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().Spawn();

            TextMeshProUGUI levelTmp = GameObject.Find("LevelTxt").GetComponent<TextMeshProUGUI>();
            levelTmp.text = $"Level {GameManager.Level}";
        }
    }

}
