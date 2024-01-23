using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public bool loopDialogue;

    public TMP_Text NpcName; 
    public Image NpcAvatar;
    public Button exitBtn;

    public TMP_Text DialogueText;
    public Button[] Choices;
    TMP_Text[] ChoicesText;

    private TextAsset inkFile;
    public Story currentStory;
    public Button continueBtn;

    private DialogueVariables variables;

    private void Awake()
    {
        continueBtn.gameObject.SetActive(false);
        exitBtn.onClick.AddListener(() => gameObject.SetActive(false));
        continueBtn.onClick.AddListener(ContinueStory);     
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    public void Init(RoomConfig config)
    {
        if (config.killerConfig == null)
            return;

        NpcName.text = config.killerConfig.NpcName;
        NpcAvatar.sprite = config.killerConfig.NpcAvatar;
        inkFile = config.killerConfig.inkDialogue;

        ChoicesText = new TMP_Text[Choices.Length];
        for (int i = 0; i < Choices.Length; i++)
        {
            ChoicesText[i] = Choices[i].gameObject.GetComponentInChildren<TMP_Text>();
        }

        EnterDialogue();
    }

    private void OnEnable()
    {
        foreach (var item in Choices)
        {
            item.gameObject.SetActive(false);
        }
        DisplayChoices();
    }

    public void EnterDialogue()
    {
        if (inkFile == null)
            return;
        currentStory = new Story(inkFile.text);
        variables = new DialogueVariables();
        variables.StartListening(currentStory);
        ContinueStory();
    }

    public void Refresh()
    {
        EnterDialogue();

        if (inkFile == null)
            return;

        if (currentStory == null) 
            return;

        while (currentStory.canContinue)
        {
            DialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        ExitDialogue();
        EnterDialogue();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            DialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            ExitDialogue();
        }
    }

    public void ExitDialogue()
    {
        if(currentStory == null) return;
        DialogueText.text = "";
        gameObject.SetActive(false);
        variables.StopListening(currentStory);

        if (loopDialogue)
        {
            EnterDialogue();
        }
    }

    public void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        continueBtn.gameObject.SetActive(currentChoices.Count == 0);


        if(currentChoices.Count > Choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support");
            return;
        }
        for (int i = 0;i < currentChoices.Count; i++)
        {
            Choices[i].gameObject.SetActive(true);
            ChoicesText[i].text = currentChoices[i].text;
        }

        for(int i = currentChoices.Count; i < Choices.Length; i++) 
        {
            Choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int i)
    {
        currentStory.ChooseChoiceIndex(i);
        ContinueStory() ;
    }
}
