using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "Level",menuName = "Create Level")]
public class Level : ScriptableObject
{
    [ShowAssetPreview]
    public GameObject levelPrefab;

    public GameObject Init() // Initialize level
    {
        if (levelPrefab)
        {
            GameObject createdLevel = Instantiate(levelPrefab);
            return createdLevel;
        }
        return null;
    }
}
