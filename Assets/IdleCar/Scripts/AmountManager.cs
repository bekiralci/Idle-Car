using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AmountManager : MonoBehaviour
{

    [SerializeField] private UIItemMerge mergeUIItem;

    public float _amount;

    [SerializeField] TextMeshProUGUI amountText;

    private void Start()
    {
        UpdateText();

        EventManager.ButtonManager.Invoke().ButtonStateControl();
    }

    #region Enable/Disable/Event

    private void OnEnable()
    {

        EventManager.AmountManager += GetThis;

    }

    private void OnDisable()
    {

        EventManager.AmountManager -= GetThis;

    }

    public AmountManager GetThis()
    {
        return this;
    }

    #endregion

    public void AmountUpdate(float value)
    {
        _amount += value;
    }

    private void UpdateText()
    {
        amountText.text = ReturnAmount((int)_amount).ToString();
    }

    string ReturnAmount(int _value)
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

    public bool SetAmount(float value)
    {
        if (_amount >= value)
        {
            AmountUpdate(-value);
            UpdateText();

            mergeUIItem.MergeBTNControl();

            EventManager.ButtonManager.Invoke().ButtonStateControl();

            return true;
        }
        return false;
    }

    public bool AmountCheck(float value)
    {


        if (_amount >= value)
        {

            return true;

        }

        return false;

    }

}