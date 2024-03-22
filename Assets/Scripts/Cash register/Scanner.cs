using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    private bool _hasHit;
    private RaycastHit hit;

    void Update()
    {
        _hasHit = Physics.Raycast(transform.position, transform.up, out hit);

        if(_hasHit)
        {
            if (hit.collider.GetComponent<IBarCode>() != null)
            {
                hit.collider.GetComponent<IBarCode>().IsScannable();
            }
        }
    }
}
