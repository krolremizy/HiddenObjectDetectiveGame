using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool allCluesFound = false;
    public RoomConfig roomConfig;
    public RoomEssentials roomEssentials;

    List<Item> items;
    List<Item> clues;
    bool cluesSpawned= false;
    private void Start()
    {
        roomEssentials.Init(this);
        SetUpItems();
        SetUpClue();
    }

    private void SetUpItems()
    {
        items = GetComponentsInChildren<Item>().Where(item => !item.isClue).ToList();
        items.ForEach(item =>
        {
            var text = Instantiate(roomEssentials.TipText, roomEssentials.TipTextContainer);
            text.text = item.ItemName;

            item.Init(this, text);
            item.OnPickUp += () => Item_OnPickUp(item);
        }
        );


    }

    private void Item_OnPickUp(Item item)
    {
        if (item.isClue)
            return;

        RectTransform itemRectTransform = item.GetComponent<RectTransform>();
        RectTransform textTransform = item.tipText.GetComponent<RectTransform>();

        Vector3 centerPosition = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        DOTween.Sequence()
            .Append(itemRectTransform.DOMove(centerPosition, 0.6f))
            .AppendInterval(0.35f)
            .Append(itemRectTransform.DOMove(textTransform.position, 0.6f))
            .Join(itemRectTransform.DOScale(Vector3.zero, 0.6f))
            .OnComplete(() => {
                SpawnClue();
                item.gameObject.SetActive(false);
                item.ChangeTextStyle();
            });
    }




    private void SetUpClue()
    {
        roomEssentials.exclamationMark.gameObject.SetActive(false);
        clues = GetComponentsInChildren<Item>().Where(item => item.isClue).ToList();

        if(clues.Count == 0)
        {
            allCluesFound = true;
            return;
        }

        clues.ForEach(item =>
        {
            item.Init(this);
            item.OnPickUp += () => Clue_OnPickUp(item);
            item.gameObject.SetActive(false);
        }
        );      
    }


    private void Clue_OnPickUp(Item clue)
    {
        if (!clue.isClue)
            return;

        RectTransform itemRectTransform = clue.GetComponent<RectTransform>();
        RectTransform npcTransform = roomEssentials.NpcButton.GetComponent<RectTransform>();

        Vector3 centerPosition = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        DOTween.Sequence()
            .Append(itemRectTransform.DOMove(centerPosition, 0.6f))
            .AppendInterval(0.35f)
            .Append(itemRectTransform.DOMove(npcTransform.position, 0.6f))
            .Join(itemRectTransform.DOScale(Vector3.zero, 0.6f))
            .OnComplete(() => {
                clue.gameObject.SetActive(false);
            });


        foreach (var item in clues)
        {
            if (!item.wasFound)
            {
                return;
            }
        }

        allCluesFound = true;
        GameManager.Instance.EndGameCheck();
        roomEssentials.exclamationMark.gameObject.SetActive(false);
    }

    void SpawnClue()
    {
        if (cluesSpawned) return;

        foreach (var item in items)
        {
            if (!item.wasFound)
            {
                return;
            }
        }

        if(clues.Count > 0)
        {
            SceneLoader.Instance.fadeScreen.FadeAction(() =>
            {
                roomEssentials.exclamationMark.gameObject.SetActive(true);
                clues.ForEach(item => item.gameObject.SetActive(true));
            });
        }

        cluesSpawned = true;
    }


}
