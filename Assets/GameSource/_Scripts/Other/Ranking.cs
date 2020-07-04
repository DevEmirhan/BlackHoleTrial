using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Ranking : MonoBehaviour
{
    public Text myText;
    public string myName;
    public int myIndex;
    public void MoveMyPos(Vector3 position)
    {
        DOTween.Complete(this);
        transform.DOMove(position, 0.2f).SetEase(Ease.Linear);
    }
}
