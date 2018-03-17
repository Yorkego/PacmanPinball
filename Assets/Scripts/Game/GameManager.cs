using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _startText;
    [SerializeField] private GameObject _pausePanel;    

    private bool _isGameStarted;
    private bool _isPaused;
    private bool _isGameEnd;
   
    private void Start()
    {        
        _isGameStarted = true;
        _isPaused = false;
        _isGameEnd = false;
        Time.timeScale = 0;
        _startText.gameObject.SetActive(true);
    }

    private void Update()
    {        
        if ((Input.anyKeyDown) & _isGameStarted)
        {
            _isGameStarted = false;
            _startText.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape) & !_isGameEnd)
        {
            _isPaused = !_isPaused;
            Pause();
        }        
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        _isGameEnd = true;
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
        _pausePanel.GetComponent<Transform>().GetChild(0).gameObject.SetActive(true);
    }

    private void Pause()
    {
        if (_isPaused)
        {
            Time.timeScale = 0;
            _pausePanel.SetActive(true);
            _pausePanel.GetComponent<Transform>().GetChild(1).gameObject.SetActive(true);
        } else
        {
            Time.timeScale = 1;
            _pausePanel.SetActive(false);
            _pausePanel.GetComponent<Transform>().GetChild(1).gameObject.SetActive(false);
        }
    }    
}
