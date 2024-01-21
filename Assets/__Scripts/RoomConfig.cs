using UnityEngine;

[CreateAssetMenu(fileName = "DefaultConfig", menuName = "RoomConfig")]
public class RoomConfig : ScriptableObject
{
    public bool canGoLeft = true;
    public bool canGoRight = true;
    public KillerConfig killerConfig;
}