using TMPro;
using UnityEngine;

public class UiItemIncome : ButtonBase
{

    #region EventManager

    UiItemIncome GetThis() { return this; }

    private void OnEnable() { EventManager.UiItemIncome += GetThis; }
    private void OnDisable() { EventManager.UiItemIncome -= GetThis; }


    #endregion

    [SerializeField] private TextMeshProUGUI Text_IncomeFactor;

    [SerializeField] public float incomeFactor;

    private void IncomeFactorUpdate()
    {
        incomeFactor += .1f;
        Text_IncomeFactor.text = "x" + incomeFactor.ToString("0.#");
    }

    public override void OnClickButton()
    {
        if (AmountControl())
        {
            base.OnClickButton();
            IncomeFactorUpdate();
        }
    }

}