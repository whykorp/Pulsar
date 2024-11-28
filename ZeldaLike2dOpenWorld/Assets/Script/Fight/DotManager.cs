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
public void ApplyDOT(string dotName, float damage, int turns)
{
    // Vérifie si un DOT avec le même nom existe déjà
    DOT existingDOT = FightManager.activeDOTs.Find(dot => dot.name == dotName);

    if (existingDOT != null)
    {
        // Si le DOT existe, mets à jour ses dégâts et sa durée
        existingDOT.damagePerTurn = damage;
        existingDOT.remainingTurns = turns;
        Debug.Log($"DOT {dotName} mis à jour : {damage} dégâts par tour pendant {turns} tours.");
    }
    else
    {
        // Si le DOT n'existe pas, ajoute-le à la liste
        FightManager.activeDOTs.Add(new DOT(dotName, damage, turns));
        Debug.Log($"DOT {dotName} appliqué : {damage} dégâts par tour pendant {turns} tours.");
    }
}

}
