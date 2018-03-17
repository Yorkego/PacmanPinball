using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private Refresh _refreshGhost;
    [SerializeField] private Refresh _refreshFood;
    [SerializeField] private float _force;
    [SerializeField] private int _bumperCode;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody != null)
        {
            Vector2 dir = collision.contacts[0].point - new Vector2(collision.transform.position.x, collision.transform.position.y);
            collision.rigidbody.AddForce(-dir * _force);            
        }
        if (_bumperCode == 1)
        {
            _refreshGhost.RefreshObjects();
            _refreshFood.RefreshObjects();
        }
        if (_bumperCode == 2)
        {
            ScoreManager.Instance.ChangeScore(ConstantClass.BUMPER_SCORE);
        }       
    }
}
