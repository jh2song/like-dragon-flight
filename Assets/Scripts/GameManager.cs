using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    private Canvas _canvas;
    
    public static int Level { get; set; } = 1;
    public static int Hp { get; set; } = 3;


    private TextMeshProUGUI _levelTmp;
    private TextMeshProUGUI _hpTmp;
    
    private void Start()
    {
        _canvas = GameObject.FindObjectOfType<Canvas>();
        
        _levelTmp = GameObject.Find("LevelTxt").GetComponent<TextMeshProUGUI>();
        _levelTmp.text = $"Level {Level}";
        
        GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().Spawn();

        _hpTmp = GameObject.Find("HpTxt").GetComponent<TextMeshProUGUI>();
        _hpTmp.text = $"HP : {Hp}";
    }

    private void Update()
    {
        if (Hp <= 0)
        {
            Transform hudTransform = _canvas.transform.Find("HUD");
            Transform gameOverUITransform = _canvas.transform.Find("GameOverUI");

            if (hudTransform != null)
            {
                hudTransform.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("HUD 오브젝트를 찾을 수 없습니다.");
            }

            if (gameOverUITransform != null)
            {
                gameOverUITransform.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("GameOverUI 오브젝트를 찾을 수 없습니다.");
            }

            Time.timeScale = 0f;
        }
    }
}
