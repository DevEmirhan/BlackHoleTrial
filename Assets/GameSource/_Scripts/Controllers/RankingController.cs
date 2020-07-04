using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RankingController : MonoBehaviour
{
    public int playerPosition;
    public int startPlayerIndex;
    public int currentPlayerIndex;
    public int startRank;
    public List<Transform> rankings;
    private List<Vector3> startPositions = new List<Vector3>();
    private void Start()
    {
        for (int i = 0; i < rankings.Count; i++)
        {
            startPositions.Add(rankings[i].position);
        }
        if (PlayerPrefs.HasKey("playerRank"))
        {
            playerPosition = PlayerPrefs.GetInt("playerRank");

        }
        else
        {
            playerPosition = startRank;
            PlayerPrefs.SetInt("playerRank", startRank);
        }
        SetRankingTexts();
        rankings[startPlayerIndex].SetAsLastSibling();
    }
    public void MovePlayerUp()
    {
        if(currentPlayerIndex - 1 >= 0)
        {
            rankings[startPlayerIndex].DOScale(Vector3.one * 1.1f, 0.1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                rankings[startPlayerIndex].DOScale(Vector3.one, 0.1f).SetEase(Ease.Linear);
                rankings[startPlayerIndex].GetComponent<Ranking>().MoveMyPos(rankings[currentPlayerIndex - 1].position);
                rankings[startPlayerIndex].GetComponent<Ranking>().myIndex--;
                rankings[startPlayerIndex].GetComponent<Ranking>().myText.text = rankings[startPlayerIndex].GetComponent<Ranking>().myIndex + ". " + "You";
                rankings[currentPlayerIndex - 1].GetComponent<Ranking>().MoveMyPos(startPositions[currentPlayerIndex]);
                rankings[currentPlayerIndex - 1].GetComponent<Ranking>().myIndex++;
                rankings[currentPlayerIndex - 1].GetComponent<Ranking>().myText.text = 
                rankings[currentPlayerIndex -1].GetComponent<Ranking>().myIndex + ". " + rankings[currentPlayerIndex - 1].GetComponent<Ranking>().myName;
                currentPlayerIndex--;
                playerPosition--;
                PlayerPrefs.SetInt("playerRank", playerPosition);
            });
            
        }
        else
        {
            Debug.Log("Already on Top Place");
        }
    }
    private void SetRankingTexts()
    {
        if(playerPosition < rankings.Count)
        {
            Debug.Log("on middle pad");
            for (int i = 0; i < rankings.Count; i++)
            {
                rankings[i].GetComponent<Ranking>().myIndex = i + 1;
                rankings[i].GetComponent<Ranking>().myText.text = rankings[i].GetComponent<Ranking>().myIndex + ". " + rankings[i].GetComponent<Ranking>().myName;
            }
            rankings[playerPosition-1].GetComponent<Ranking>().myIndex = playerPosition;
            rankings[playerPosition-1].GetComponent<Ranking>().myText.text = rankings[playerPosition-1].GetComponent<Ranking>().myIndex + ". " + "You";
            startPlayerIndex = playerPosition-1;
            currentPlayerIndex = playerPosition-1;
        }
        else
        {
            Debug.Log("on bottom pad");
            int currentLayoutStart = playerPosition - rankings.Count;
            for (int i = 0; i < rankings.Count; i++)
            {
                rankings[i].GetComponent<Ranking>().myIndex = (currentLayoutStart + i + 1);
                rankings[i].GetComponent<Ranking>().myText.text = rankings[i].GetComponent<Ranking>().myIndex + ". " + rankings[i].GetComponent<Ranking>().myName;
            }
            rankings[rankings.Count - 1].GetComponent<Ranking>().myIndex = playerPosition;
            rankings[rankings.Count-1].GetComponent<Ranking>().myText.text = rankings[rankings.Count - 1].GetComponent<Ranking>().myIndex + ". " + "You";
            startPlayerIndex = rankings.Count-1;
            currentPlayerIndex = rankings.Count-1;
        }
    }
}
