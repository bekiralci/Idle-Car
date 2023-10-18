using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Car : MonoBehaviour
{

    public int _level;

    public void OnCalled()
    {
        EventManager.CarsManager.Invoke().ToList(_level);
    }

}
