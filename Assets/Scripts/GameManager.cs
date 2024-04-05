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

    private void Start()
    {
        _AmountOfCustomersToSpawn = 2;
        SpawnFirstCustomer();
    }

    private void Update()
    {
        Debug.Log(_playerData._PlayerMoney);

        if(_CustomersSpawned >= _AmountOfCustomersToSpawn)
        {
            Invoke("LoadEndOfDayScene", 2);
        }

    }

    private void LoadEndOfDayScene()
    {
        SavePlayerDataToJSON();
        SceneManager.LoadScene("DayFinishedScreen");
    }

    private void SpawnFirstCustomer()
    {
        _CustomersSpawned = 1;
        Instantiate(_CustomerPrefab, _Exit.position, Quaternion.identity);
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
