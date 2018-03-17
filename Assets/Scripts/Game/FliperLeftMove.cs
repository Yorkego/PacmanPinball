using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FliperMove))]
public class FliperLeftMove : MonoBehaviour
{
   private void Update()
    {
        if (Input.GetKeyDown(ConstantClass.LEFT))
        {
            GetComponent<FliperMove>().Move();
        }
    }
}
