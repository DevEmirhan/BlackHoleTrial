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

                        //---------------------------------------------------------------------------End
                        break;
                    case GameState.Pause:
                        //---------------------------------------------------------------------------Start

                        //---------------------------------------------------------------------------End
                        break;
                    case GameState.Play:
                        //---------------------------------------------------------------------------Start

                        //---------------------------------------------------------------------------End
                        break;
                    case GameState.Win:
                        SaveManager.Save("RandomLevelIndex", -1);
                        SaveManager.Save("LevelIndex", SaveManager.GetSaveDataInt("LevelIndex") + 1);
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
        PlayerPrefs.SetInt("levelIndex", PlayerPrefs.GetInt("levelIndex") + 1);
         //Win Conditions
    }



}
