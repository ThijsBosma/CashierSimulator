using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Produce : MonoBehaviour, IBarCode
{
    [SerializeField] private ScriptableObject _ItemData;
    private bool _isScanned;

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
}
