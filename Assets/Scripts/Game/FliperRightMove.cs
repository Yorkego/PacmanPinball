using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FliperMove))]
public class FliperRightMove : MonoBehaviour
{    
    private void Update()
    {
        if (Input.GetKeyDown(ConstantClass.RIGHT))
        {
            GetComponent<FliperMove>().Move();
        }
    }
}
