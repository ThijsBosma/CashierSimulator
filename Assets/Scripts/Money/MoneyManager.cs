using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private float _currentMoney;

    void Start()
    {
        _currentMoney = Random.Range(0, 1000);
    }

    void Update()
    {
        
    }

    private void ConvertToJSON()
    {

    }
}
