using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Background : MonoBehaviour
{
    [SerializeField]
    private GameObject _background1;
    [SerializeField]
    private GameObject _background2;
    [SerializeField]
    private float _mapDropSpeed = 5f;

    private Vector3 _basePos;
    private Vector3 _upPos;

    private int _switchingTarget = 1;
    
    // Start is called before the first frame update
    private void Start()
    {
        if (_background1 == null || _background2 == null)
        {
            Debug.Log("Background1 혹은 Background2가 스크립트에 할당이 안되어있음");
        }

        _basePos = _background1.transform.position;
        _upPos = _background2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _background1.transform.position = _background1.transform.position +
                                          Vector3.down * (_mapDropSpeed * Time.deltaTime);
        _background2.transform.position = _background2.transform.position +
                                          Vector3.down * (_mapDropSpeed * Time.deltaTime);

        if (_background1.transform.position.y <= _basePos.y && _switchingTarget == 2)
        {
            _background2.transform.position = _upPos;
            _switchingTarget = 1;
        }
        else if (_background2.transform.position.y <= _basePos.y && _switchingTarget == 1)
        {
            _background1.transform.position = _upPos;
            _switchingTarget = 2;
        }
    }
}
