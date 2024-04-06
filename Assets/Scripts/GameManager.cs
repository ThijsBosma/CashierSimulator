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

    private float _MoneyToGive = 25;

    private void Start()
    {
        _AmountOfCustomersToSpawn = Random.Range(1, 3);
        SpawnFirstCustomer();
        _playerData._PlayerMoney = _MoneyToGive;
    }

    private void Update()
    {
        Debug.Log(_playerData._PlayerMoney);

        if(_CustomersSpawned > _AmountOfCustomersToSpawn)
        {
            LoadEndOfDayScene("DayFinishedScreen");
        }

    }

    private void LoadEndOfDayScene(string sceneName)
    {
        SavePlayerDataToJSON();
        SceneManager.LoadScene(sceneName);
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
