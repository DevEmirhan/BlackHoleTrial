using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public override void Awake()
    {
        base.Awake();
    }

    public Text levelText, nextLevelText, coinText;
    [BoxGroup("Panels")]
    public GameObject startPanel,shopPanel,losePanel,winPanel,gameplayPanel;
    public Toggle vibrateToggle;
    public Slider slider1;
    public Slider slider2;

    private void Start()
    {
        LevelManager.Instance.levelLoad.AddListener(SetStart);
        levelText.text = (PlayerPrefs.GetInt("levelIndex")+1).ToString();
        nextLevelText.text = (PlayerPrefs.GetInt("levelIndex")+2).ToString();
        coinText.text = PlayerPrefs.GetInt("coinCount").ToString();
       
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
    public void UseColor (int colorNumber)
    {
        PlayerPrefs.SetInt("PlayerColor", colorNumber);
        FindObjectOfType<PlayerController>().RefreshColor();
    }

}
