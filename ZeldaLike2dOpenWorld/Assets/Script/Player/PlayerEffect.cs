using System.Collections;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public PlayerMovement playerMovement;
    
    public void AddSpeed(int speedGiven, float speedDuration){
        PlayerStats.playerMoveSpeed += speedGiven;
        StartCoroutine(RemoveSpeed(speedGiven, speedDuration));
    }

    private IEnumerator RemoveSpeed(int speedGiven, float speedDuration){
        yield return new WaitForSeconds(speedDuration);
        PlayerStats.playerMoveSpeed -= speedGiven;
    }
}
