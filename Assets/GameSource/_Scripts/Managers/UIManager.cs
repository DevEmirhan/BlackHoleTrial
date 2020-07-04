using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public override void Awake()
    {
        base.Awake();
    }

    [BoxGroup("Panels")]
    public GameObject startPanel,shopPanel,losePanel,winPanel,gameplayPanel;

    private void Start()
    {
        LevelManager.Instance.levelLoad.AddListener(SetStart);
    }

    public void SetStart()
    {
        shopPanel.SetActive(false);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        gameplayPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        gameplayPanel.SetActive(true);
        GameManager.Instance.gameState = GameState.Play;
    }
    public void OpenCloseShop(bool isEnabled)
    {
        if (isEnabled)
        {
            startPanel.SetActive(false);
            shopPanel.SetActive(true);
        }
        else
        {
            startPanel.SetActive(true);
            shopPanel.SetActive(false);
        }
    }
    public void ShowWinPanel()
    {
        gameplayPanel.SetActive(false);
        winPanel.SetActive(true);
    }
    public void ShowLosePanel()
    {
        gameplayPanel.SetActive(false);
        losePanel.SetActive(true);
    }
    public void RestartGame()
    {
        LevelManager.Instance.LoadNewLevel();
    }
    public void PauseGame()
    {

    }
    public void NextLevel()
    {
        LevelManager.Instance.LoadNewLevel();
    }
}
