using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    
    public GameObject Bullet;
    private GameObject BulletsContainer;
    
    [SerializeField]
    private float _bulletInteval = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        BulletsContainer = GameObject.Find("Bullets") ?? new GameObject("Bullets");
        InvokeRepeating("GenerateBullet", 0f, _bulletInteval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GenerateBullet()
    {
        GameObject newBullet = Instantiate(Bullet, Vector3.zero, Quaternion.Euler(0f, 0f, 90f), BulletsContainer.transform);
        newBullet.transform.position = Player.transform.position + Vector3.up;
    }
}
