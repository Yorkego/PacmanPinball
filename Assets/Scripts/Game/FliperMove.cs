using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FliperMove : MonoBehaviour
{
    [SerializeField] private float _torqueSpeed;

    private Rigidbody2D _rb;    

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        _rb.AddTorque(_torqueSpeed);
    }
}
