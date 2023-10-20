using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIItemMerge : ButtonBase
{

    #region SNG PTRN

    public static UIItemMerge instance;

    public static UIItemMerge Instance
    {
        get
        {
            return instance;
        }
    }

    public void SingletonPT()
    {
        instance = this;
    }

    #endregion

    public GameObject MergeBTN_base;
    public GameObject MergeBTN;
    public GameObject MergeBTN_passive;

    private void Awake()
    {
        SingletonPT();
        MergeBTNControl();
    }

    private void Merge(int level)
    {
        Dictionary<int, Queue<Car>> tempCarDC = EventManager.CarsManager.Invoke().CarsOnTheGame;

        for (int j = 3 - 1; j >= 0; j--)
        {
            tempCarDC[level].Dequeue().ReturnTheBase();
        }

        EventManager.CarsManager.Invoke().CarsOnTheGame = tempCarDC;
        EventManager.CarsManager.Invoke().MainCarList[level + 1].Dequeue().OnCalled();
    }

    private int ReturnLevel()
    {
        Dictionary<int, Queue<Car>> tempCarDC = EventManager.CarsManager.Invoke().CarsOnTheGame;

        for (int level = 0; level < 3; level++)
        {
            if (tempCarDC[level].Count >= 3)
            {
                return level;
            }
        }
        return 0;
    }

    private bool RoadControl(int level)
    {

        if (EventManager.RoadManager.Invoke().roads[level].gameObject.activeInHierarchy == true)
        {
            return true;
        }
        return false;

    }

    private bool CanMerge()
    {

        Dictionary<int, Queue<Car>> tempCars = EventManager.CarsManager.Invoke().CarsOnTheGame;

        for (int level = 0; level < tempCars.Count; level++)
        {
            if (tempCars[level].Count >= 3)
            {
                return RoadControl(level + 1);
            }
        }
        return false;
    }

    public bool CharNumControl(Dictionary<int, Queue<Car>> carsMainList)
    {

        if (carsMainList.Count == 0)
        {
            return false;
        }

        for (int i = 0; i < 3; i++)
        {
            if (carsMainList[i].Count >= 3)
            {

                MergeBTN.SetActive(true);

                return true;
            }
        }

        return false;

    }

    public override void OnClickButton()
    {
        if (AmountControl() && CanMerge())
        {
            base.OnClickButton();
            Merge(ReturnLevel());
            MergeBTNControl();
        }
    }
    public void MergeBTNControl()
    {
        if (CharNumControl(EventManager.CarsManager.Invoke().CarsOnTheGame) /*&& EventManager.AmountManager.Invoke().AmountCheck(upgradeCost)*/)
        {

            MergeBTN_base.SetActive(true);
            MergeBTN.SetActive(true);
            MergeBTN_passive.SetActive(false);
        }
        else if (CharNumControl(EventManager.CarsManager.Invoke().CarsOnTheGame) /*&& !EventManager.AmountManager.Invoke().AmountCheck(upgradeCost)*/)
        {
            MergeBTN_base.SetActive(true);
            MergeBTN.SetActive(false);
            MergeBTN_passive.SetActive(true);
        }
        else
        {
            MergeBTN_base.SetActive(false);
        }
    }


}