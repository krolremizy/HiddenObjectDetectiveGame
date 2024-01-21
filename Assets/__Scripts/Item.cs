using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string ItemName = "none";
    public bool isClue = false;
    protected Room roomReference;
    public event Action OnPickUp;
    public bool wasFound = false;  
    
    public TMP_Text tipText;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(PickedUp);
    }
    public void Init(Room room, TMP_Text tipText = null)
    {
        roomReference = room;
        this.tipText = tipText; 
    }

    public void PickedUp()
    {
        wasFound = true;
        OnPickUp?.Invoke();

        if (isClue)
        {
            DialogueVariables.VariableChanged(ItemName, new Ink.Runtime.BoolValue(true));
            roomReference.roomEssentials.roomDialogue.ExitDialogue();
            roomReference.roomEssentials.roomDialogue.EnterDialogue();
        }
    }

    public void ChangeTextStyle()
    {
        if (tipText != null)
        {
            tipText.color = Color.red;
            tipText.fontStyle = FontStyles.Strikethrough;
        }
    }
}
