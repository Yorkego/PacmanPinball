using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private GameObject _heart1;
    [SerializeField] private GameObject _heart2;
    [SerializeField] private GameObject _heart3;
    [SerializeField] private GameManager _gameManager;

    private int _lifeCount = 3;
    private GameObject[] _hearts;   

    private void Start()
    {
        _hearts = new GameObject[] { _heart1, _heart2, _heart3 };        
    }

    public void ChangeLifeCount()
    {
        if (_lifeCount > 0)
        {
            _lifeCount--;
        }
        if (_lifeCount <= 0)
        {
            _gameManager.EndGame();
        }
        for (int i = 0; i < 3; i++)
        {
            if (_hearts[i].activeInHierarchy)
            {
                _hearts[i].SetActive(false);
                break;
            }
        }
    }
}
