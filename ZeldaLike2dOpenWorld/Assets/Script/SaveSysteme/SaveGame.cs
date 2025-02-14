using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveGame : MonoBehaviour
{

    public Inventory inventory;
    public GameObject player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Save");
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Load");
            Load();
        }
    }

    [System.Serializable]
    public class PlayerData
    {
        public float playerMaxHealth;
        public float playerCurrentHealth;
        public float playerMoveSpeed;
        public int playerLvl;
        public float playerXp;
        public float playerXpGivedCoef;
        public int playerCoins;
        public float playerBaseAttack;
        public float playerBaseDefense;
        public float playerBaseAccuracy;
        public float playerCurrentAttack;
        public float playerAttackCoeficien;
        public float playerCurrentDefense;
        public float playerDefenseCoeficien;
        public float playerCurrentAccuracy;

        // Add player position data
        public float playerPositionX;
        public float playerPositionY;
        public float playerPositionZ;

        // Add inventory data
        public List<int> inventoryItemIds;
        public List<int> inventoryItemCounts;

        
    }

    [System.Serializable]
    public class WorldData
    {
        // Add chest states
        public List<int> openedChests;
        public List<int> closedChests;
    }

    public void Save()
    {
        PlayerData playerData = new PlayerData
        {
            playerMaxHealth = PlayerStats.playerMaxHealth,
            playerCurrentHealth = PlayerStats.playerCurrentHealth,
            playerMoveSpeed = PlayerStats.playerMoveSpeed,
            playerLvl = PlayerStats.playerLvl,
            playerXp = PlayerStats.playerXp,
            playerXpGivedCoef = PlayerStats.playerXpGivedCoef,
            playerCoins = PlayerStats.playerCoins,
            playerBaseAttack = PlayerStats.playerBaseAttack,
            playerBaseDefense = PlayerStats.playerBaseDefense,
            playerBaseAccuracy = PlayerStats.playerBaseAccuracy,
            playerCurrentAttack = PlayerStats.playerCurrentAttack,
            playerAttackCoeficien = PlayerStats.playerAttackCoeficien,
            playerCurrentDefense = PlayerStats.playerCurrentDefense,
            playerDefenseCoeficien = PlayerStats.playerDefenseCoeficien,
            playerCurrentAccuracy = PlayerStats.playerCurrentAccuracy,

            // Save player position
            playerPositionX = player.transform.position.x,
            playerPositionY = player.transform.position.y,
            playerPositionZ = player.transform.position.z,

            // Save inventory data
            inventoryItemIds = new List<int>(),
            inventoryItemCounts = new List<int>()
        };

        foreach (var kvp in inventory.content)
        {
            playerData.inventoryItemIds.Add(kvp.Key.id);
            playerData.inventoryItemCounts.Add(kvp.Value);
        }

        WorldData worldData = new WorldData
        {
            openedChests = new List<int>(),
            closedChests = new List<int>()
        };

        foreach (var chest in FindObjectsOfType<OpenChest>())
        {
            if (chest.isOpen)
            {
                worldData.openedChests.Add(chest.GetInstanceID());
                Debug.Log(chest.GetInstanceID());
            }
            else
            {
                worldData.closedChests.Add(chest.GetInstanceID());
            }
        }

        string playerJson = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.persistentDataPath + "/playerSavefile.json", playerJson);

        string worldJson = JsonUtility.ToJson(worldData);
        File.WriteAllText(Application.persistentDataPath + "/worldSavefile.json", worldJson);
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerSavefile.json"))
        {
            string playerJson = File.ReadAllText(Application.persistentDataPath + "/playerSavefile.json");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(playerJson);

            PlayerStats.playerMaxHealth = playerData.playerMaxHealth;
            PlayerStats.playerCurrentHealth = playerData.playerCurrentHealth;
            PlayerStats.playerMoveSpeed = playerData.playerMoveSpeed;
            PlayerStats.playerLvl = playerData.playerLvl;
            PlayerStats.playerXp = playerData.playerXp;
            PlayerStats.playerXpGivedCoef = playerData.playerXpGivedCoef;
            PlayerStats.playerCoins = playerData.playerCoins;
            PlayerStats.playerBaseAttack = playerData.playerBaseAttack;
            PlayerStats.playerBaseDefense = playerData.playerBaseDefense;
            PlayerStats.playerBaseAccuracy = playerData.playerBaseAccuracy;
            PlayerStats.playerCurrentAttack = playerData.playerCurrentAttack;
            PlayerStats.playerAttackCoeficien = playerData.playerAttackCoeficien;
            PlayerStats.playerCurrentDefense = playerData.playerCurrentDefense;
            PlayerStats.playerDefenseCoeficien = playerData.playerDefenseCoeficien;
            PlayerStats.playerCurrentAccuracy = playerData.playerCurrentAccuracy;

            // Load player position
            player.transform.position = new Vector3(playerData.playerPositionX, playerData.playerPositionY, playerData.playerPositionZ);

            // Load inventory data
            inventory.content.Clear();
            for (int i = 0; i < playerData.inventoryItemIds.Count; i++)
            {
                Item item = inventory.GetItemFromID(playerData.inventoryItemIds[i]);
                inventory.content[item] = playerData.inventoryItemCounts[i];
            }
        }

        if (File.Exists(Application.persistentDataPath + "/worldSavefile.json"))
        {
            string worldJson = File.ReadAllText(Application.persistentDataPath + "/worldSavefile.json");
            WorldData worldData = JsonUtility.FromJson<WorldData>(worldJson);

            // Load chest states
            foreach (var chest in FindObjectsOfType<OpenChest>())
            {
                if (worldData.openedChests.Contains(chest.GetInstanceID()))
                {
                    chest.SetChestState(true);
                }
                if (worldData.closedChests.Contains(chest.GetInstanceID()))
                {
                    chest.SetChestState(false);
                }
            }
        }
    }
}