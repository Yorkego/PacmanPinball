using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private float _xMin;
    [SerializeField] private float _xMax;
    [SerializeField] private float _speed;
    [SerializeField] private Fire _fire;

    private Transform _tf;
    private Vector2 _movePoint;
    
    private void Start()
    {
        _tf = GetComponent<Transform>();
        _movePoint = new Vector2(_xMin, _tf.position.y);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {        
        _tf.position = Vector2.MoveTowards(_tf.position, _movePoint, _speed * Time.fixedDeltaTime);           
        if (_tf.position.x <= _xMin)
        {
            _movePoint = new Vector2(_xMax, _tf.position.y);
        }
        if (_tf.position.x >= _xMax)
        {
            _movePoint = new Vector2(_xMin, _tf.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_fire.IsFireBall())
        {
            gameObject.SetActive(false);
        }
        else
        {
            ScoreManager.Instance.ChangeScore(ConstantClass.GHOST_SCORE);
        }
    }
}
