using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]
public class CustomerManager : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] private Transform[] _PointsOfInterest;
    
    [SerializeField] private Transform _CashRegister;
    [SerializeField] private Transform _Exit;

    [Header("Components")]
    [SerializeField] private NavMeshAgent _Agent;
    private Scanner _scannerComponent;
    private GameManager _gameManager;

    [Header("CustomerVariables")]
    [SerializeField] private TextMeshProUGUI _TimerText;
    [SerializeField] private float _TimeBetweenVisits;

    public bool _canSpawnProduce;
    private float _distanceCompare = 1f;

    private Coroutine _positionCoroutine;

    private float _randomizedIndex;
    private int _PointsOfInterestVisited;


    void Start()
    {
        _randomizedIndex = Random.Range(1, _PointsOfInterest.Length);
        _scannerComponent = FindObjectOfType<Scanner>();
        _gameManager = FindObjectOfType<GameManager>();
        _positionCoroutine = null;
    }

    void Update()
    {
        if(_positionCoroutine == null)
        {
            _positionCoroutine = StartCoroutine(SetPosition());
        }
    }

    private IEnumerator SetPosition()
    {
        if(_PointsOfInterestVisited <= _randomizedIndex)
        {
            _Agent.SetDestination(_PointsOfInterest[_PointsOfInterestVisited].position);

            if (Vector3.Distance(transform.position, _PointsOfInterest[_PointsOfInterestVisited].position) <= _distanceCompare)
            {
                _PointsOfInterestVisited += 1;

                yield return new WaitForSeconds(_TimeBetweenVisits);

                _positionCoroutine = null;
            }
        }
        else
        {
            _Agent.SetDestination(_CashRegister.position);

            if (Vector3.Distance(transform.position, _CashRegister.position) <= _distanceCompare)
            {
                //HelpTimer();
                _canSpawnProduce = true;
            }
        }

        if (_scannerComponent._FinishedHelping)
        {
            _Agent.SetDestination(_Exit.position);
            _canSpawnProduce = false;

            if (Vector3.Distance(transform.position, _Exit.position) < 1)
            {
                Instantiate(_gameManager._CustomerPrefab, _Exit.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    private void OnValidate()
    {
        _Agent = GetComponent<NavMeshAgent>();
    }

    private void OnDestroy()
    {
        _scannerComponent._FinishedHelping = false;
        _scannerComponent._scannedItems = 0;
        _gameManager._CustomersSpawned += 1;
    }

}
