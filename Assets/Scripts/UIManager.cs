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
    [SerializeField] private ParticleSystem _GoodFeedback;

    private bool _isRentPayed;

    private void Start()
    {
        LoadJSONFile();
        UpdateUI();
    }

    public void Rent(float rentCost)
    {
        if(_playerData._PlayerMoney >= rentCost)
        {
            _playerData._PlayerMoney -= rentCost;
            _isRentPayed = true;
            _GoodFeedback.Play();
        }

        if(!_isRentPayed && _playerData._PlayerMoney <= rentCost)
        {
            _isRentPayed = false;
        }
    }

    public void Continue()
    {
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
