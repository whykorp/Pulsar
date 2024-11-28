using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/Quest")]

public class Quests : ScriptableObject
{
    public int id;
    public new string name;
    public string description;
    public string location;
    public bool isPrincipal;
    public bool isFollowed;
    public bool isDone;

}
