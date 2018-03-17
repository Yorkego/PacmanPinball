using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBallMaker : MonoBehaviour
{
    [SerializeField] private Transform _ballSwap;
    [SerializeField] private LifeManager _lifeManager;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() != null)
        {
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.transform.position = _ballSwap.position;
            _lifeManager.ChangeLifeCount();
        }
    }    
}
