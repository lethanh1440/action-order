using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOrderTest_Cube2 : MonoBehaviour
{
    private void Awake()
    {
        var ac = GameObject.FindObjectOfType<AcionOrderRunner>();
        ac.onTest.action += OnClick;
    }
    [ActionOrder(2)]
    void OnClick(string a)
    {
        Debug.Log("name " + name + " => " + a);
    }
}
