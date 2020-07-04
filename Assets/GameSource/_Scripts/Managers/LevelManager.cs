using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.Events;

public class LevelManager : Singleton<LevelManager>
{
    public override void Awake()
    {
        base.Awake();
    }
    public bool isSceneReloading;
    public List<Level> levels;
    public bool testMode;
    [EnableIf("testMode")]
    public int currentLevelIndex;
    [ReadOnly]
    public int levelIndex;
    [HideInInspector]
    public Level currentLevel;

    public int minRandomStartIndex;

    private GameObject levelObj;

    [HideInInspector]
    public UnityEvent levelLoad = new UnityEvent();
    
    
    void Start()
    {
        LoadStart();
    }
    public void LoadStart()
    {
        if (!isSceneReloading)
        {
            if (levelObj)
            {
                Destroy(levelObj);
            }
            LoadLevel();
            GameManager.Instance.gameState = GameState.Start;
        }
        else
        {
            LoadLevel();
            GameManager.Instance.gameState = GameState.Start;
        }
    }


    public void LoadNewLevel()
    {
        if (!isSceneReloading)
        {
            if (levelObj)
            {
                Destroy(levelObj);
            }
            LoadLevel();
            GameManager.Instance.gameState = GameState.Start;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void LoadLevel()
    {
        if (!testMode)
        {
            currentLevelIndex = SaveManager.GetSaveDataInt("LevelIndex");
            levelIndex = SaveManager.GetSaveDataInt("LevelIndex") + 1;
            if (currentLevelIndex > levels.Count - 1)
            {
                if (SaveManager.GetSaveDataInt("RandomLevelIndex") == -1)
                {
                    currentLevelIndex = Random.Range(minRandomStartIndex, levels.Count);
                    SaveManager.Save("RandomLevelIndex", currentLevelIndex);
                }
                else
                {
                    currentLevelIndex = SaveManager.GetSaveDataInt("RandomLevelIndex");
                }
            }
        }
        currentLevel = levels[currentLevelIndex];
        levelObj = currentLevel.Init();
        levelLoad.Invoke();
    }
}
