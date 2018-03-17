using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimerDuobleScore : MonoBehaviour
{
    [SerializeField] private float _reloadSeconds;
    [SerializeField] private DoubleScore _doubleScore;

    private Text _timerText;
    private float _timer;

    private void Start()
    {
        _timerText = GetComponent<Text>();
        _timer = _reloadSeconds;
    }

    private void Update()
    {
        if (!_doubleScore.CanCastDoubleScore)
        {                       
            _timerText.enabled = true;
            _timer -= Time.deltaTime;
            _timerText.text = _timer.ToString(ConstantClass.ONE_ZERO_FORMAT);
            if (_timer <= 0)
            {
                _doubleScore.CanCastDoubleScore = true;                
                _doubleScore.gameObject.GetComponent<Text>().color = Color.red;
                _timerText.enabled = false;
                _timer = _reloadSeconds;
            }           
        }        
    }      
}
