using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

public enum GameState
{
    Start,
    Pause,
    Play,
    Win,
    Lose
}
public class GameManager : Singleton<GameManager>
{
    public override void Awake()
    {
        base.Awake();
    }

    [ReadOnly]
    [SerializeField]
    private GameState _gameState;
    public DynamicJoystick joystick;
    public int coinsPerLevel = 100;
    
    public GameState gameState
    {
        get { return _gameState; }
        set
        {
            if(_gameState != value)
            {
                _gameState = value;
                switch (_gameState)
                {
                    case GameState.Start:

                        //---------------------------------------------------------------------------Start
                        Camera.main.transform.position = new Vector3(0f, 30f, -7f);
                        UIManager.Instance.slider1.value = 0f;
                        UIManager.Instance.slider2.value = 0f;
                        UIManager.Instance.levelText.text = (PlayerPrefs.GetInt("levelIndex") + 1).ToString();
                        UIManager.Instance.nextLevelText.text = (PlayerPrefs.GetInt("levelIndex") + 2).ToString();
                        UIManager.Instance.coinText.text = PlayerPrefs.GetInt("coinCount").ToString();

                        //---------------------------------------------------------------------------End
                        break;
                    case GameState.Pause:
                        //---------------------------------------------------------------------------Start

                        //---------------------------------------------------------------------------End
                        break;
                    case GameState.Play:
                        //---------------------------------------------------------------------------Start
                        FindObjectOfType<PlayerController>().isInputGet = true;
                        //---------------------------------------------------------------------------End
                        break;
                    case GameState.Win:
                        SaveManager.Save("RandomLevelIndex", -1);
                        SaveManager.Save("LevelIndex", SaveManager.GetSaveDataInt("LevelIndex") + 1);
                        PlayerPrefs.SetInt("levelIndex", PlayerPrefs.GetInt("levelIndex") + 1);
                        PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") + coinsPerLevel);
                        UIManager.Instance.ShowWinPanel();
                        //---------------------------------------------------------------------------Start
                        
                        //---------------------------------------------------------------------------End
                        break;
                    case GameState.Lose:
                        UIManager.Instance.ShowLosePanel();
                        //---------------------------------------------------------------------------Start

                        //---------------------------------------------------------------------------End
                        break;
                }
            }
        }
    }
    public void Lose()
    {
        gameState = GameState.Lose;
        
        //Lose Conditions
    }
    public void Win()
    {
        gameState = GameState.Win;
        
        //Win Conditions
    }



}
