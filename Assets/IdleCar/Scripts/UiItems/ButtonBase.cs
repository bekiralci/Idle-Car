using System.Numerics;
using TMPro;
using UnityEngine;

public abstract class ButtonBase : MonoBehaviour
{
    [SerializeField] private int startCost;
    [SerializeField] private int upgradeLevel;
    [SerializeField] private float factor;

    public int upgradeCost;

    public TextMeshProUGUI Text_UpdateCost;
    public TextMeshProUGUI Text_UpdateCostPassive;

    private void Start()
    {
        UpdateText();
        CalculateNewCost();
    }

    protected void UpdateText()
    {
        Text_UpdateCost.text = ReturnAmountToText(upgradeCost);
    }

    protected void UpdateAmount(int value)
    {
        EventManager.AmountManager.Invoke().SetAmount(value);
    }

    public virtual void OnClickButton()
    {
        UpdateAmount(upgradeCost);
        CalculateNewCost();
        UpdateText();
    }

    protected int CalculateNewCost()
    {
        float newCost;

        newCost = (Mathf.Pow(upgradeLevel, factor)) * startCost;

        upgradeLevel++;

        upgradeCost = (int)newCost;

        print(newCost);

        return (int)newCost;
    }

    private string ReturnAmountToText(int _value)
    {

        if (_value >= 100000000)
        {
            return (_value / 1000000D).ToString("0.#M");
        }
        if (_value >= 1000000)
        {
            return (_value / 1000000D).ToString("0.##M");
        }
        if (_value >= 100000)
        {
            return (_value / 1000D).ToString("0.#k");
        }
        if (_value >= 1000)
        {
            return (Mathf.FloorToInt((_value / 10)) / 100f).ToString("0.##k");
        }
        if (_value == 0)
        {
            return "0";
        }

        return _value.ToString("#");

    }

    protected bool AmountControl()
    {
        if (EventManager.AmountManager.Invoke().AmountCheck((float)upgradeCost))
        {
            return true;
        }
        return false;
    }


}
