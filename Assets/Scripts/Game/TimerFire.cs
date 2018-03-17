using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimerFire : MonoBehaviour
{
    [SerializeField] private float _reloadSeconds;
    [SerializeField] private Fire _fire;

    private Text _timerText;
    private float _timer;

    private void Start()
    {
        _timerText = GetComponent<Text>();
        _timer = _reloadSeconds;
    }

    private void Update()
    {
        if (!_fire.CanCastFire)
        {                       
            _timerText.enabled = true;
            _timer -= Time.deltaTime;
            _timerText.text = _timer.ToString(ConstantClass.ONE_ZERO_FORMAT);
            if (_timer <= 0)
            {
                _fire.CanCastFire = true;
                _fire.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                _timerText.enabled = false;
                _timer = _reloadSeconds;
            }           
        }        
    }      
}
