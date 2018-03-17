using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager
{
    private event Action OnScoreChange;

    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ScoreManager();
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    private int _scoreMultiply = 1;    
    
    public int Score { get; private set; }

    private ScoreManager()
    {
    }

    public void ChangeScore(int nPoints)
    {
        Score += (nPoints * _scoreMultiply);
        if (Score < 0)
        {
            ClearScore();
        }
        if (OnScoreChange != null)
            OnScoreChange.Invoke();
    }

    public void SetScoreMulOne()
    {
        _scoreMultiply = 1;
    }

    public void SetScoreMulTwo()
    {
        _scoreMultiply = 2;
    }

    public void ClearScore()
    {
        Score = 0;
    }

    public void AddScoreChangeListeners(Action action)
    {
        OnScoreChange += action;
    }

    public void RemoveAllListeners()
    {
        OnScoreChange = null;
    }
}
