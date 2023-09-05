using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameOn.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;
    [SerializeField] TextMeshProUGUI textMeshPro;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        textMeshPro.text = "x " + coins;
    }
}
