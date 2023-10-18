using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class CarsManager : MonoBehaviour
{

    public Dictionary<int, List<Car>> currentRunnerBases = new();

    [SerializeField] private List<Car> runners_1;
    [SerializeField] private List<Car> runners_2;
    [SerializeField] private List<Car> runners_3;
    [SerializeField] private List<Car> runners_4;

    private void Awake()
    {
        currentRunnerBases.Add(0, runners_1);
        currentRunnerBases.Add(1, runners_2);
        currentRunnerBases.Add(2, runners_3);
        currentRunnerBases.Add(3, runners_4);
    }

   
    #region EventManager

    private void OnEnable()
    {
        EventManager.CarsManager += GetThis;
    }

    private void OnDisable()
    {
        EventManager.CarsManager -= GetThis;
    }

    #endregion

    private CarsManager GetThis()
    {
        return this;
    }

    //public void AddRunner(CarsManager runner)
    //{

    //    currentRunnerBases[runner._level - 1].Add(runner);

    //}

}