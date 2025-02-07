using System.Collections;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public static IEnumerator AffectMoveSpeed(float amount, float duration)
    {
        PlayerStats.playerMoveSpeed += amount;
        yield return new WaitForSeconds(duration);
        PlayerStats.playerMoveSpeed -= amount;
    }
}
