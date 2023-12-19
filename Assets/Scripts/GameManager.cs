using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static int Level { get; set; } = 1;
    public static int Hp { get; set; } = 3;


    private TextMeshProUGUI _levelTmp;
    private TextMeshProUGUI _hpTmp;
    
    private void Start()
    {
        _levelTmp = GameObject.Find("LevelTxt").GetComponent<TextMeshProUGUI>();
        _levelTmp.text = $"Level {Level}";
        
        GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().Spawn();

        _hpTmp = GameObject.Find("HpTxt").GetComponent<TextMeshProUGUI>();
        _hpTmp.text = $"HP : {Hp}";
    }

    private void Update()
    {
        
    }
}
