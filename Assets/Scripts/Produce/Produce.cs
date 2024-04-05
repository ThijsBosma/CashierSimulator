using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Produce : MonoBehaviour, IBarCode
{
    private bool _isScanned;
    private Transform _OriginalTransform;

    private void Start()
    {
        _OriginalTransform = transform;
    }

    private void Update()
    {
        if (_isScanned)
        {
            Destroy(gameObject);
        }
    }

    public void IsScannable()
    {
        _isScanned = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.position = _OriginalTransform.position;
        }
    }
}
