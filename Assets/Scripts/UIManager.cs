using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private PlayerData _playerData = new PlayerData();
    
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI _CurrentMoneyText;

    private float _rentCost = 25;
    private bool _isRentPayed;

    private void Start()
    {
        LoadJSONFile();
        UpdateUI();

        Rent(25);
    }

    public void Rent(float rentCost)
    {
        if(_playerData._PlayerMoney >= rentCost)
        {
            _playerData._PlayerMoney -= rentCost;
            _isRentPayed = true;
        }
        else
        {
            _isRentPayed = false;
        }
    }

    public void FoodCheck(float foodCost)
    {
        if(_playerData._PlayerMoney >= foodCost)
        {
            _playerData._PlayerMoney -= foodCost;
            UpdateUI();

            _playerData._Hunger += 50;
        }
        else
        {
            _playerData._Hunger -= 50;
        }
    }

    public void WaterCheck(float waterCost)
    {
        if(_playerData._PlayerMoney >= waterCost)
        {
            _playerData._PlayerMoney -= waterCost;
            UpdateUI();

            _playerData._Thirst += 50;
        }
        else
        {
            _playerData._Thirst -= 50;
        }
    }

    public void HeatCheck(float heatCost)
    {
        if(_playerData._PlayerMoney >= heatCost)
        {
            _playerData._PlayerMoney -= heatCost;
            UpdateUI();

            _playerData._Heat += 50;
        }
        else
        {
            _playerData._Heat -= 50;
        }
    }

    public void Continue()
    {
        _playerData.NecessitiesCheck();

        if(_isRentPayed)
        {
            ConvertToJSON();
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            SceneManager.LoadScene("HomelessEnding");
        }
    }

    private void UpdateUI()
    {
        _CurrentMoneyText.text =  "CurrentMoney: " + _playerData._PlayerMoney.ToString("F0");
    }

    private void ConvertToJSON()
    {
        string amountOfMoney = JsonUtility.ToJson(_playerData);
        string filePath = Application.persistentDataPath + "/CurrentMoney.json";

        Debug.Log(filePath);

        System.IO.File.WriteAllText(filePath, amountOfMoney);
        Debug.Log("Money file saved");
    }


    private void LoadJSONFile()
    {
        string filePath = Application.persistentDataPath + "/CurrentMoney.json";

        string moneyAmount = System.IO.File.ReadAllText(filePath);

        _playerData = JsonUtility.FromJson<PlayerData>(moneyAmount);
        Debug.Log("Loaded files");
    }
}
