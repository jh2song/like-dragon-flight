using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    private Canvas _canvas;

    private Transform _hudTransform;
    private Transform _gameOverUITransform;
    private Transform _nextStageUI;
    
    public static int Level { get; set; } = 1;
    public static int Hp { get; set; } = 3;


    private TextMeshProUGUI _levelTmp;
    private TextMeshProUGUI _hpTmp;
    
    private void Start()
    {
        Time.timeScale = 1f;
        
        _canvas = GameObject.FindObjectOfType<Canvas>();
        
        _hudTransform = _canvas.transform.Find("HUD");
        _gameOverUITransform = _canvas.transform.Find("GameOverUI");
        _nextStageUI = _canvas.transform.Find("NextStageUI");
        
        if (_hudTransform == null)
        {
            Debug.LogError("HUD 빈 오브젝트를 찾을 수 없습니다!");
        }
        if (_gameOverUITransform == null)
        {
            Debug.LogError("GameOverUI 빈 오브젝트를 찾을 수 없습니다!");
        }
        if (_nextStageUI == null)
        {
            Debug.LogError("NextStageUI 빈 오브젝트를 찾을 수 없습니다!");
        }
        
        // 처음 UI 구성요소 보일 것을 초기화
        _hudTransform.gameObject.SetActive(true);
        _gameOverUITransform.gameObject.SetActive(false);
        _nextStageUI.gameObject.SetActive(false);
        
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
            _hudTransform.gameObject.SetActive(false);
            _gameOverUITransform.gameObject.SetActive(true);
            _nextStageUI.gameObject.SetActive(false);
            
            Time.timeScale = 0f;
        }

        if (Level > 3)
        {
            _hudTransform.gameObject.SetActive(false);
            _gameOverUITransform.gameObject.SetActive(false);
            _nextStageUI.gameObject.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    public void OnRetryBtnClicked()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneName);
        Hp = 3;
        Level = 1;
    }
    
    public void OnNextStageBtnClicked()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneName);
        Hp = 3;
        Level = 1;
        
        EnemyBullet.Speed += 2f;
        Enemy.BulletInteval -= 0.2f;
    }
}
