using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public class Buff
    {
        public string type;  // Type du buff : "attack", "defense", etc.
        public float value;  // La valeur du buff (ex. : +15% d'attaque)
        public int duration; // Durée du buff en tours

        public Buff(string type, float value, int duration)
        {
        this.type = type;
        this.value = value;
        this.duration = duration;
        }
    }   
    

    
}
