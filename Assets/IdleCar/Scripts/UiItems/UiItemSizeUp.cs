using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiItemSizeUp : ButtonBase
{

    [SerializeField] private List<GameObject> roadList = new();

    [SerializeField] private int _lastListIndex;

    public override void OnClickButton()
    {
        if (AmountControl())
        {
            base.OnClickButton();
            OpenNewRoad();
        }
    }

    private void OpenNewRoad()
    {

        if (_lastListIndex + 1 == roadList.Count)
        {
            return;
        }

        _lastListIndex++;
        roadList[_lastListIndex].SetActive(true);

    }

}
