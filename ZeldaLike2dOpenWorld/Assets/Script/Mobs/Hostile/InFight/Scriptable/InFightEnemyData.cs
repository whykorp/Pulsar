using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InFightEnemyData", menuName = "My Game/InFightEnemyData")]
public class InFightEnemyData : ScriptableObject
{
   public string enemyName;
   public string enemyDescription;
   public int baseHp;
   public int baseDef;
   public int baseAttack;
   public string[] techniques;
   public int baseSpeed;

}
