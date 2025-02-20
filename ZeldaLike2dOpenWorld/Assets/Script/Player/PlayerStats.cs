using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    static public float playerMaxHealth = 200;
    static public float playerCurrentHealth;

    public static float playerMoveSpeed = 4f;

    public static int playerLvl=1;
    public static float playerXp=0;
    public static float playerXpGivedCoef=1;

    public static int playerCoins=0;

    public static float playerBaseAttack=1;
    public static float playerBaseDefense=1;
    public static float playerBaseAccuracy=1;

    public static float playerCurrentAttack;
    public static float playerAttackCoeficien=1;
    public static float playerCurrentDefense;
    public static float playerDefenseCoeficien=1;
    public static float playerCurrentAccuracy;

}
