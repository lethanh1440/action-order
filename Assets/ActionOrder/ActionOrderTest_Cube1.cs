using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOrderTest_Cube1 : MonoBehaviour
{
    private void Awake()
    {
        var ac = GameObject.FindObjectOfType<AcionOrderRunner>();
        ac.onTest.action += OnClick;
    }
    [ActionOrder(3)]
    void OnClick(string a)
    {
        Debug.Log("name " + name + " => " + a);
    }
}
