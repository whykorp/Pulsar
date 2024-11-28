using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotManager : MonoBehaviour
{
    public class DOT
{
    public string name;          // Nom ou identifiant unique du DOT
    public float damagePerTurn;  // Dégâts par tour
    public int remainingTurns;   // Nombre de tours restants

    public DOT(string dotName, float damage, int turns)
    {
        name = dotName;
        damagePerTurn = damage;
        remainingTurns = turns;
    }
    
}
}
