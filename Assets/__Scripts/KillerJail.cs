using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KillerJail : MonoBehaviour
{
    public Image avatar;
    public Button sentence;

    public void Init(KillerConfig killerConfig)
    {
        avatar.sprite = killerConfig.NpcAvatarSmall;
        sentence.GetComponentInChildren<TMP_Text>(true).text = $"Sentence {killerConfig.NpcName}";
        ChooseKillerManager manager = FindObjectOfType<ChooseKillerManager>();

        sentence.onClick.AddListener(() => SceneLoader.Instance.fadeScreen.FadeAction( () => manager.ShowEndGamePanel(killerConfig)));
    }
}
