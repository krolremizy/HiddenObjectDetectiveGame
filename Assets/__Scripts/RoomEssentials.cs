using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomEssentials : MonoBehaviour
{
    public DialogueManager roomDialogue;
    public Image exclamationMark;
    public Button NpcButton;
    public Button leftArrow;
    public Button rightArrow;
    public Transform TipTextContainer;
    public TMP_Text TipText;

    RoomConfig roomConfig;
    public void Init(Room roomReference)
    {
        roomConfig = roomReference.roomConfig;
        SetUpNPC();
        SetUpDialogue();

        if (!roomConfig.canGoRight)
        {
            rightArrow.gameObject.SetActive(false);
        }

        if (!roomConfig.canGoLeft)
        {
            leftArrow.gameObject.SetActive(false);
        }

        leftArrow.onClick.AddListener(GameManager.Instance.PreviousRoom);
        rightArrow.onClick.AddListener(GameManager.Instance.NextRoom);
    }

    private void SetUpDialogue()
    {
        roomDialogue.Init(roomConfig);
        roomDialogue.gameObject.SetActive(false);
        NpcButton.onClick.AddListener(() => roomDialogue.gameObject.SetActive(true));
    }

    private void SetUpNPC()
    {
        if (roomConfig.killerConfig == null || roomConfig.killerConfig.NpcAvatar == null)
        {
            NpcButton.gameObject.SetActive(false);
            return;
        }

        if (roomConfig.killerConfig.NpcAvatarSmall != null)
        {
            NpcButton.GetComponent<Image>().sprite = roomConfig.killerConfig.NpcAvatarSmall;
        }
        else if (roomConfig.killerConfig.NpcAvatar != null)
        {
            NpcButton.GetComponent<Image>().sprite = roomConfig.killerConfig.NpcAvatar;
        }
    }
}
