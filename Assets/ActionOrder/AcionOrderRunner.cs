using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcionOrderRunner : MonoBehaviour
{
    public ActionOrder<string> onTest = new ActionOrder<string>();

    private void Start()
    {
        onTest.Sort();
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            onTest.action.Invoke("mouse clicked");
        }
    }
}
