using System.Collections.Generic;
using UnityEngine;

public class CarsManager : MonoBehaviour
{

    #region EventManager

    private void OnEnable()
    {
        EventManager.CarsManager += GetThis;
    }

    private void OnDisable()
    {
        EventManager.CarsManager -= GetThis;
    }
    private CarsManager GetThis()
    {
        return this;
    }
    #endregion

    [SerializeField] private List<Car> car_Prefabs;

    public Dictionary<int, Queue<Car>> MainCarList = new();
    public Dictionary<int, Queue<Car>> CarsOnTheGame = new();

    private void Awake()
    {
        for (int i = 0; i < car_Prefabs.Count; i++)
        {
            MainCarList.Add(i, EventManager.ObjectFactory.Invoke().CreateTheWantObject(car_Prefabs[i].gameObject, 15));
            CarsOnTheGame.Add(i, new Queue<Car>());
        }
    }

    public void ToMainList(Car car, int _level)
    {
        MainCarList[_level - 1].Enqueue(car);
    }

    public void ToGameList(Car car, int _level)
    {
        CarsOnTheGame[_level - 1].Enqueue(car);
    }

    //public List<Car> ReturnCars(int _level)
    //{
    //    List<Car> list = new();

    //    for (int i = 0; i < 3; i++)
    //    {
    //        list.Add(MainCarList[_level - 1].Dequeue());
    //    }

    //    return list;
    //}

}