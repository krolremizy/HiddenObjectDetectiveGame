using UnityEngine;

[CreateAssetMenu(fileName = "KillerConfig", menuName = "KillerConfig")]
public class KillerConfig : ScriptableObject
{
    public bool isKiler = false;
    public TextAsset inkDialogue;
    public string NpcName;
    public Sprite NpcAvatar;
    public Sprite NpcAvatarSmall;

    [TextArea(3, 10)]
    public string Explanation;
}