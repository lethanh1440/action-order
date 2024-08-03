**Change the order of actions with attribute `[ActionOrder(your order)]`**

mono listener 1
```c#
private void Awake()
{
  var ac = GameObject.FindObjectOfType<AcionOrderRunner>();
  ac.onTest.action += OnClick;
}     
[ActionOrder(2)]
void OnClick(string a)
{
    Debug.Log("11111" + a);
}
````
mono listener 2
```c#
private void Awake()
{
  var ac = GameObject.FindObjectOfType<AcionOrderRunner>();
  ac.onTest.action += OnClick;
}     
[ActionOrder(1)]
void OnClick(string a)
{
    Debug.Log("22222" + a);
}
```
Example event manager `AcionOrderRunner` class like:
```c#
public class AcionOrderRunner : MonoBehaviour
{
    public ActionOrder<string> onTest = new ActionOrder<string>();

    private void Start()
    {
        onTest.Sort();//(call after all registed). So call in Start() because listener action registed in Awake()
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            onTest.action.Invoke("mouse clicked");
        }
    }
}
```
**Output when mouse click:**
>`2222 mouse clicked`

>`1111 mouse clicked`



