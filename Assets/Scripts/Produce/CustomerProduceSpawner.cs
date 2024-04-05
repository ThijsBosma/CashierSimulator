using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerProduceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _Produce;
    [SerializeField] private Transform _ProduceSpawnPoint;
    [SerializeField] private float _TimeBetweenSpawns;

    private Vector3 _offset;

    private CustomerManager _customerManager;

    private Coroutine _coroutine;
    public float _randomizedIndex;
    private int _produceSpawned;

    private void Awake()
    {
        _randomizedIndex = Random.Range(1, _Produce.Length);
        _customerManager = GetComponent<CustomerManager>();
    }

    private void Update()
    {
        if(_coroutine == null)
        {
            _coroutine = StartCoroutine(SpawnProduce());
        }
    }

    private IEnumerator SpawnProduce()
    {
        if (_produceSpawned < _randomizedIndex)
        {
            if (_customerManager._canSpawnProduce)
            {
                Instantiate(_Produce[_produceSpawned], _ProduceSpawnPoint.position + _offset, Quaternion.identity);
                _produceSpawned += 1;
                _offset.x -= 0.5f;
                yield return new WaitForSeconds(_TimeBetweenSpawns);

                _coroutine = null;
            }
        }
    }

    
}
