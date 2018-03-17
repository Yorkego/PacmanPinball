using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private float _activeSeconds;    

    private bool _isBallFire;
    private bool _canCast;
    private SpriteRenderer _sprite;

    public bool CanCastFire {
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
        _isBallFire = false;
        _canCast = true;
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) & _canCast)
        {
            _canCast = false;
            StartCoroutine(ActiveFire());           
            _sprite.sortingOrder = -1;
        }
    }   

    public bool IsFireBall()
    {
        return _isBallFire;
    }

    private IEnumerator ActiveFire()
    {
        _ball.GetComponent<SpriteRenderer>().color = Color.red;
        _ball.transform.GetChild(0).gameObject.SetActive(true);
        _isBallFire = true;
        yield return new WaitForSeconds(_activeSeconds);
        _ball.GetComponent<SpriteRenderer>().color = Color.white;
        _ball.transform.GetChild(0).gameObject.SetActive(false);
        _isBallFire = false;        
    }    
}
