using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "InFightEnemyData", menuName = "My Game/InFightEnemyData")]
public class InFightEnemyData : ScriptableObject
{
   public string enemyName;
   public string enemyDescription;
   public float baseHp;
   public float baseDef;
   public float baseAttack;
   public int[] techniques;
   public float baseSpeed;
   public int mind;
   public float xpGivedAtDead;
   public Sprite enemySprite;

}
