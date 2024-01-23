using DG.Tweening;
using Ink.Runtime;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int currentRoom = 0;
    public Button verdictButton;
    public List<Room> rooms;
    public TextAsset globalsInkFile;

    public Dictionary<string, Ink.Runtime.Object> variables;

    protected override void Awake()
    {
        base.Awake();
        Story globalVariablesStory = new Story(globalsInkFile.text);

        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach(string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
        }
    }

    void Start()
    {
        ShowCurrentRoom();
        verdictButton.gameObject.SetActive(false);
        verdictButton.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneEnum.ChooseKiller));
    }

    public void RefreshDialogues()
    {
        foreach(Room room in rooms) {

            room.roomEssentials.roomDialogue.Init(room.roomConfig);
            room.roomEssentials.roomDialogue.Refresh();
        }
    }

    public void NextRoom()
    {
        currentRoom = (currentRoom + 1) % rooms.Count;
        ShowCurrentRoom();
    }

    public void PreviousRoom()
    {
        currentRoom = (currentRoom - 1 + rooms.Count) % rooms.Count;
        ShowCurrentRoom();
    }

    void ShowCurrentRoom()
    {
        foreach (Room item in rooms)
        {
            item.gameObject.SetActive(false);
        }

        rooms[currentRoom % rooms.Count].gameObject.SetActive(true);
    }

    public void EndGameCheck()
    {
        if (rooms.All(item => item.allCluesFound))
        {
            verdictButton.gameObject.SetActive(true);
            verdictButton.transform.localScale = Vector3.zero;
            verdictButton.transform.DOScale(Vector3.one, 0.9f)
                .SetEase(Ease.OutBounce);
        }
    }
}