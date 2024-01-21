using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseKillerManager : MonoBehaviour
{
    public List<KillerConfig> killers;

    public GameObject EndGamePanel;
    public Button PlayGameBtn;
    public Button QuitGameBtn;

    public TMP_Text ResultText;
    public TMP_Text ExplainText;

    private void Awake()
    {
        PlayGameBtn.onClick.AddListener(PlayAgain);
        PlayGameBtn.onClick.AddListener(QuitGame);
        EndGamePanel.gameObject.SetActive(false);

        killers.Shuffle();
        int index = 0;
        foreach (var jail in GetComponentsInChildren<KillerJail>())
        {
            jail.Init(killers.ElementAt(index % killers.Count));
            index++;
        }
    }

    public void ShowEndGamePanel(KillerConfig killerConfig)
    {
        EndGamePanel.SetActive(true);
        if (killerConfig.isKiler)
        {
            ResultText.text = "You WON";
        }
        else
        {
            ResultText.text = "You LOSE";
        }

        ExplainText.text = killerConfig.Explanation;
    }

    void PlayAgain()
    {
        SceneLoader.Instance.LoadScene(SceneEnum.Gameplay);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
