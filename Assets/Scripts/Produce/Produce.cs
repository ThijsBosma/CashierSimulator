using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Produce : MonoBehaviour, IBarCode
{
    [SerializeField] private ScriptableObject _ItemData;
    private bool _isScanned;

    public void IsScannable()
    {
        _isScanned = true;
        Debug.Log(_isScanned);
    }
}
