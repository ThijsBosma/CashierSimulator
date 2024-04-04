using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject _CustomerPrefab;
    [SerializeField] private Transform _Exit;
    private PlayerData _playerData = new PlayerData();

    private float _AmountOfCustomersToSpawn;
    public float _CustomersSpawned;
    private Coroutine _customerSpawnCoroutine;

    private void Start()
    {
        _AmountOfCustomersToSpawn = Random.Range(1, 1);
    }

    private void Update()
    {
        if (_customerSpawnCoroutine == null)
        {
            _customerSpawnCoroutine = StartCoroutine(SpawnCustomers());
        }

        Debug.Log(_playerData._PlayerMoney);
    }

    private IEnumerator SpawnCustomers()
    {
        if(_CustomersSpawned < _AmountOfCustomersToSpawn)
        {
            Instantiate(_CustomerPrefab, _Exit.position, Quaternion.identity);
            _CustomersSpawned += 1;
            yield return new WaitForSeconds(90);
            _customerSpawnCoroutine = null;
        }
    }

    private void SavePlayerDataToJSON()
    {
        string amountOfMoney = JsonUtility.ToJson(_playerData);
        string filePath = Application.persistentDataPath + "/CurrentMoney.json";

        Debug.Log(filePath);

        System.IO.File.WriteAllText(filePath, amountOfMoney);
        Debug.Log("Money file saved");
    }

}
