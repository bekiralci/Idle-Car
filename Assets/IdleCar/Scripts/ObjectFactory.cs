using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour
{

    #region EventManager

    private ObjectFactory GetThis()
    {
        return this;
    }

    private void OnEnable()
    {
        EventManager.ObjectFactory += GetThis;
    }

    private void OnDisable()
    {
        EventManager.ObjectFactory -= GetThis;
    }

    #endregion

    public Queue<Car> CreateTheWantObject(GameObject obj, int _requestedNumber)
    {

        Queue<Car> cars = new();

        for (int i = 0; i < _requestedNumber; i++)
        {

            GameObject newObj = Instantiate(obj);
            newObj.SetActive(false);

            cars.Enqueue(newObj.GetComponent<Car>());

        }

        return cars;
    }

}
