using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CustomerManager : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] private Transform[] _PointsOfInterest;
    [SerializeField] private Transform _CashRegister;

    [Header("Components")]
    [SerializeField] private NavMeshAgent _Agent;

    [Header("CustomerVariables")]
    [SerializeField] private float _TimeBetweenVisits;
    private float _distanceCompare = 1f;
    public bool _canSpawnProduce;

    private Coroutine _coroutine;

    private int _randomizedIndex;
    private int _PointsOfInterestVisited;

    void Start()
    {
        _randomizedIndex = Random.Range(0, _PointsOfInterest.Length);
    }

    void Update()
    {
        if(_coroutine == null)
        {
            _coroutine = StartCoroutine(SetPosition());
        }
    }

    private IEnumerator SetPosition()
    {
        if(_PointsOfInterestVisited < _randomizedIndex)
        {
            _Agent.SetDestination(_PointsOfInterest[_PointsOfInterestVisited].position);

            _PointsOfInterestVisited += 1;

            yield return new WaitForSeconds(_TimeBetweenVisits);

            _coroutine = null;
        }

        if(_PointsOfInterestVisited >= _randomizedIndex)
        {
            _Agent.SetDestination(_CashRegister.position);

            if(Vector3.Distance(transform.position, _CashRegister.position) <= _distanceCompare)
            {
                _canSpawnProduce = true;
            }
        }
    }

    private void OnValidate()
    {
        _Agent = GetComponent<NavMeshAgent>();
    }

}
