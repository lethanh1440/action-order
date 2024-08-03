using System;
using System.Collections.Generic;
using System.Linq;
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class ActionOrder : System.Attribute
{
    public int index;
    public ActionOrder(int index)
    {
        this.index = index;
    }
}
public class ActionOrder<T>
{
    public System.Action<T> action;
    public void Sort()
    {
        var list = action.GetInvocationList().ToList();
        Dictionary<int, List<Delegate>> map = new Dictionary<int, List<Delegate>>();
        var max = 0;
        foreach (var item in list)
        {
            var cast = item as System.Action<T>;
            var _index = 0;
            var attribute = Attribute.GetCustomAttribute(item.Method, typeof(ActionOrder));
            if (attribute != null) _index = (attribute as ActionOrder).index;
            if (!map.ContainsKey(_index)) map[_index] = new List<Delegate>();
            map[_index].Add(item);
            if (_index > max) max = _index;
            action -= cast;
        }
        for (int i = 0; i <= max; i++)
        {
            if (!map.ContainsKey(i)) continue;
            foreach (Action<T> item in map[i])
            {
                action += item;
            }
        }
    }
}