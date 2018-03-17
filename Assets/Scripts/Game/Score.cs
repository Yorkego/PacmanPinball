using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        ScoreManager.Instance.AddScoreChangeListeners(UpdateScore);
        _text = GetComponent<Text>();
    }

    private void OnDestroy()
    {
        ScoreManager.Instance.RemoveAllListeners();
    }

    private void UpdateScore()
    {
        _text.text =  ScoreManager.Instance.Score.ToString(ConstantClass.FIVES_ZERO_FORMAT);
    }    
}
