using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalZoneList : MonoBehaviour
{
    public List<StringIntPair> exposedZoneList; 
    public Dictionary<string, bool> ZoneList = new Dictionary<string, bool>
    {
        {"palace",false},
        {"forest",false}
    };
}

