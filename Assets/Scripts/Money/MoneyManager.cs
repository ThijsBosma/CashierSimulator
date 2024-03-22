using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private PlayerData _playerData = new PlayerData();

    void Start()
    {
        _playerData._PlayerMoney = Random.Range(25, 1000);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ConvertToJSON();
        }
    }

    private void ConvertToJSON()
    {
        string amountOfMoney = JsonUtility.ToJson(_playerData);
        string filePath = Application.persistentDataPath + "/CurrentMoney.json";

        Debug.Log(filePath);

        System.IO.File.WriteAllText(filePath, amountOfMoney);
        Debug.Log("Money file saved");
    }
}
