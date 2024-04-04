using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ScannedItemsText;
    private CustomerProduceSpawner _ProduceSpawner;

    public float _scannedItems;
    public bool _FinishedHelping;

    private bool _hasHit;
    private RaycastHit hit;

    private void Start()
    {
        _ProduceSpawner = FindObjectOfType<CustomerProduceSpawner>();
    }

    void Update()
    {
        IsValueFilled();

        _hasHit = Physics.Raycast(transform.position, transform.up + new Vector3(0, 10, 0), out hit);

        if(_hasHit)
        {
            if (hit.collider.GetComponent<IBarCode>() != null)
            {
                hit.collider.GetComponent<IBarCode>().IsScannable();

                _scannedItems += 1;

                _ScannedItemsText.text =  "Scanned: " + _scannedItems.ToString();

                if(_scannedItems >= _ProduceSpawner._randomizedIndex)
                {
                    _FinishedHelping = true;
                    _ProduceSpawner = null;
                }
            }
        }
    }

    private void IsValueFilled()
    {
        if(_ProduceSpawner == null)
        {
            _ProduceSpawner = FindObjectOfType<CustomerProduceSpawner>();
        }
        else
        {
            return;
        }
    }

}
