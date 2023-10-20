using System.Collections;

public class UiItemAddCar : ButtonBase
{
    


    private void AddNewCar()
    {
        if (EventManager.CarsManager.Invoke().MainCarList[0].Count != 0 /*&& EventManager.AmountManager.Invoke().AmountCheck(upgradeCost)*/)
        {
            Car obj = EventManager.CarsManager.Invoke().MainCarList[0].Dequeue();
            obj.OnCalled();
            UIItemMerge.instance.MergeBTNControl();
        }
    }

    public override void OnClickButton()
    {
        if (AmountControl())
        {
            base.OnClickButton();
            AddNewCar();
        }
    }

    IEnumerator SpawnTriggerControl()
    {

        while (true)
        {
            if (true)
            {

            }
        }
    }

}