using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DoubleScore : MonoBehaviour
{    
    [SerializeField] private Text _infoFood;
    [SerializeField] private Text _infoGhost;
    [SerializeField] private Text _infoBumper;
    [SerializeField] private float _activeSeconds;
        
    private bool _canCast;
    private Text _spellText;

    public bool CanCastDoubleScore {
        get
        {
            return _canCast;
        }
        set
        {
            _canCast = value;
        }
    }

    private void Start()
    {       
        _canCast = true;
        _spellText = GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && _canCast)
        {
            _canCast = false;            
            StartCoroutine(ActiveDoubleScore());
            _spellText.color = Color.grey;            
        }
    }

    private IEnumerator ActiveDoubleScore()
    {
        ScoreManager.Instance.SetScoreMulTwo();        
        _infoGhost.text = ConstantClass.GHOST_DOUBLE_SCORE;
        _infoGhost.color = Color.red;
        _infoFood.text = ConstantClass.FOOD_DOUBLE_SCORE;
        _infoFood.color = Color.red;
        _infoBumper.text = ConstantClass.BUMPER_DOUBLE_SCORE;
        _infoBumper.color = Color.red;
        yield return new WaitForSeconds(_activeSeconds);
        ScoreManager.Instance.SetScoreMulOne();
        _infoGhost.text = ConstantClass.GHOST_INFO_SCORE;
        _infoGhost.color = Color.white;
        _infoFood.text = ConstantClass.FOOD_INFO_SCORE;
        _infoFood.color = Color.white;
        _infoBumper.text = ConstantClass.BUMPER_INFO_SCORE;
        _infoBumper.color = Color.white;
    }    
}
