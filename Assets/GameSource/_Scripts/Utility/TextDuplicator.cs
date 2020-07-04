using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextDuplicator : MonoBehaviour
{
    public Text editedText;
    private void Start()
    {
        editedText.text = GetComponent<Text>().text;
    }
}
