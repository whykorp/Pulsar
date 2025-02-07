using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveGame : MonoBehaviour
{
    /*
    public PlayerStats playerStats;
    public Transform playerTransform;
    public List<InventoryItem> playerInventory;

    private string saveFilePath;

    void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "savegame.json");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SavePlayerData();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            LoadPlayerData();
        }
    }

    public void SavePlayerData()
    {
        AllData data = new AllData(playerStats, playerTransform, playerInventory);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game Saved");
    }

    public void LoadPlayerData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            AllData data = JsonUtility.FromJson<AllData>(json);

            PlayerStats.playerMaxHealth = data.playerMaxHealth;
            PlayerStats.playerCurrentHealth = data.playerCurrentHealth;
            PlayerStats.playerMoveSpeed = data.playerMoveSpeed;
            PlayerStats.playerLvl = data.playerLvl;
            PlayerStats.playerXp = data.playerXp;
            PlayerStats.playerXpGivedCoef = data.playerXpGivedCoef;
            PlayerStats.playerBaseAttack = data.playerBaseAttack;
            PlayerStats.playerBaseDefense = data.playerBaseDefense;
            PlayerStats.playerBaseAccuracy = data.playerBaseAccuracy;
            PlayerStats.playerCurrentAttack = data.playerCurrentAttack;
            PlayerStats.playerAttackCoeficien = data.playerAttackCoeficien;
            PlayerStats.playerCurrentDefense = data.playerCurrentDefense;
            PlayerStats.playerDefenseCoeficien = data.playerDefenseCoeficien;
            PlayerStats.playerCurrentAccuracy = data.playerCurrentAccuracy;
            playerTransform.position = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
            playerInventory = data.playerInventory;

            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.LogWarning("Save file not found");
        }
    }
    */
}

/*
[System.Serializable]
public class AllData
{
    public float playerMaxHealth;
    public float playerCurrentHealth;
    public float playerMoveSpeed;
    public int playerLvl;
    public float playerXp;
    public float playerXpGivedCoef;
    public float playerBaseAttack;
    public float playerBaseDefense;
    public float playerBaseAccuracy;
    public float playerCurrentAttack;
    public float playerAttackCoeficien;
    public float playerCurrentDefense;
    public float playerDefenseCoeficien;
    public float playerCurrentAccuracy;
    public float[] playerPosition;
    public List<InventoryItem> playerInventory;

    public AllData(PlayerStats playerStats, Transform playerTransform, List<InventoryItem> inventory)
    {
        playerMaxHealth = PlayerStats.playerMaxHealth;
        playerCurrentHealth = PlayerStats.playerCurrentHealth;
        playerMoveSpeed = PlayerStats.playerMoveSpeed;
        playerLvl = PlayerStats.playerLvl;
        playerXp = PlayerStats.playerXp;
        playerXpGivedCoef = PlayerStats.playerXpGivedCoef;
        playerBaseAttack = PlayerStats.playerBaseAttack;
        playerBaseDefense = PlayerStats.playerBaseDefense;
        playerBaseAccuracy = PlayerStats.playerBaseAccuracy;
        playerCurrentAttack = PlayerStats.playerCurrentAttack;
        playerAttackCoeficien = PlayerStats.playerAttackCoeficien;
        playerCurrentDefense = PlayerStats.playerCurrentDefense;
        playerDefenseCoeficien = PlayerStats.playerDefenseCoeficien;
        playerCurrentAccuracy = PlayerStats.playerCurrentAccuracy;
        playerPosition = new float[3] { playerTransform.position.x, playerTransform.position.y, playerTransform.position.z };
        playerInventory = inventory;
    }
}

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int quantity;

    public InventoryItem(string name, int qty)
    {
        itemName = name;
        quantity = qty;
    }
}
*/