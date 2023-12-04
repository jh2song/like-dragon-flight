using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    
    public GameObject Bullet;
    private GameObject BulletsContainer;
    
    [SerializeField]
    private float _bulletInteval = 0.1f;

    [SerializeField]
    private int _level = 1;

    private TextMeshProUGUI _levelTmp;
    
    // Start is called before the first frame update
    private void Start()
    {
        BulletsContainer = GameObject.Find("Bullets") ?? new GameObject("Bullets");
        InvokeRepeating("GenerateBullet", 0f, _bulletInteval);

        _levelTmp = GameObject.Find("LevelTxt").GetComponent<TextMeshProUGUI>();
        _levelTmp.text = $"Level {_level}";
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void GenerateBullet()
    {
        GameObject newBullet = Instantiate(Bullet, Vector3.zero, Quaternion.Euler(0f, 0f, 90f), BulletsContainer.transform);
        newBullet.transform.position = Player.transform.position + Vector3.up;
    }
}
