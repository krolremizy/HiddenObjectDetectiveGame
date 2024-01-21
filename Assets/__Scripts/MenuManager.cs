using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public Button startBtn;
    public Button endBtn;

    private void Awake()
    {
        startBtn.onClick.AddListener(StartGame);
        endBtn.onClick.AddListener(Quit);
    }

    void StartGame()
    {
        SceneLoader.Instance.LoadScene(SceneEnum.Gameplay);
    }

    void Quit()
    {
        Application.Quit();
    }
}
