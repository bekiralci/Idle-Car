using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
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

    public Dictionary<int, List<Car>> CarsOnTheGame = new();

    [SerializeField] private List<Car> Cars_Level_1;
    [SerializeField] private List<Car> Cars_Level_2;
    [SerializeField] private List<Car> Cars_Level_3;
    [SerializeField] private List<Car> Cars_Level_4;

    private void Awake()
    {
        CarsOnTheGame.Add(0, Cars_Level_1);
        CarsOnTheGame.Add(1, Cars_Level_2);
        CarsOnTheGame.Add(2, Cars_Level_3);
        CarsOnTheGame.Add(3, Cars_Level_4);
    }

    public void ToList(int _level)
    {
        CarsOnTheGame.Add(_level, CarsOnTheGame[_level - 1]);
    }

}