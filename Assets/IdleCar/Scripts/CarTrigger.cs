using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Car car))
        {
            print("trigger");
            UpdateAmount(car._level);
        }
    }

    private void UpdateAmount(int level)
    {
        print(ReturnAmount(level));
        EventManager.AmountManager.Invoke().AddAmount(ReturnAmount(level));
    }


    private int ReturnAmount(int level)
    {
        float incomeFactor = EventManager.UiItemIncome.Invoke().incomeFactor;
        return level switch
        {
            1 => (int)(1 * incomeFactor),
            2 => (int)(4 * incomeFactor),
            3 => (int)(15 * incomeFactor),
            4 => (int)(50 * incomeFactor),
            _ => 0,
        };
    }

}
