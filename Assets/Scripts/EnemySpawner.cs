using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    private Random random = new Random();
    
    private float[] _spwanX = {
        -2f, -1f, 0f, 1f, 2f
    };

    private float _spawnY = 4f;

    public void Spawn()
    {
        int level = GameManager.Level;
        float[] spawnPosX = _spwanX.OrderBy(x => random.Next()).Take(level).ToArray();

        foreach (int x in spawnPosX)
        {
            Vector3 position = new Vector3(x, _spawnY, 0);
            Instantiate(Enemy, position, Quaternion.identity);
        }
    }
}
