using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    
    public GameObject Bullet;
    private GameObject BulletsContainer;
    
    [SerializeField]
    private float _bulletInteval = 0.1f;
    
    public static int Level { get; set; } = 1;

    private TextMeshProUGUI _levelTmp;
    
    private void Start()
    {
        BulletsContainer = GameObject.Find("Bullets") ?? new GameObject("Bullets");
        InvokeRepeating("GenerateBullet", 0f, _bulletInteval);

        _levelTmp = GameObject.Find("LevelTxt").GetComponent<TextMeshProUGUI>();
        _levelTmp.text = $"Level {Level}";
        
        GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().Spawn();
    }

    private void Update()
    {
        
    }

    private void GenerateBullet()
    {
        GameObject newBullet = Instantiate(Bullet, Vector3.zero, Quaternion.Euler(0f, 0f, 90f), BulletsContainer.transform);
        newBullet.transform.position = Player.transform.position + Vector3.up;
    }
}
