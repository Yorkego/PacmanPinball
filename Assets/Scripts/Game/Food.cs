using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private int _ballAnimationHash = Animator.StringToHash(ConstantClass.BALL_ANIMATION);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            ScoreManager.Instance.ChangeScore(ConstantClass.FOOD_SCORE);
            if (collision.gameObject.GetComponent<Animator>() != null)
            {
                collision.gameObject.GetComponent<Animator>().SetTrigger(_ballAnimationHash);
            }
            gameObject.SetActive(false);
        }
    }    
}
