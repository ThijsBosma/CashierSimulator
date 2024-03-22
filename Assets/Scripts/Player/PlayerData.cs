using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData
{
    public float _PlayerMoney;
    public float _Hunger = 100;
    public float _Thirst = 100;
    public float _Heat = 100;


    public void NecessitiesCheck()
    {
        if(_Hunger <= 0)
        {

        }

        if(_Thirst <= 0)
        {

        }

        if(_Heat <= 0)
        {

        }
    }

}
