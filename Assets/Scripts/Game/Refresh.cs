using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refresh : MonoBehaviour
{
    private GameObject[] _arrObjects;
    private int _childCount;
   
    private void Start()
    {
        _childCount = gameObject.transform.childCount;
        _arrObjects = new GameObject[_childCount];
        for (int i = 0; i < _childCount; i++)
        {
            _arrObjects[i] = gameObject.transform.GetChild(i).gameObject;            
        }
    }

    public void RefreshObjects()
    {
        for (int i = 0; i < _childCount; i++)
        {
            _arrObjects[i].SetActive(true);
        }
    }
}
