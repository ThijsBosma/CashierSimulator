using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltMove : MonoBehaviour
{
    [SerializeField] private Transform _StartPoint;
    [SerializeField] private Transform _EndPoint;

    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.Lerp(_StartPoint.position, _EndPoint.position, 2);
    }
}
