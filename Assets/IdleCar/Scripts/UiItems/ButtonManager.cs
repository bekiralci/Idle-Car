using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Serializable]
    public struct Buttons
    {

        public ButtonBase buttonBase;

        public GameObject activeButtonImage;
        public GameObject passiveButtonImage;

    }

    [SerializeField] List<Buttons> buttons;

    #region Enable/Disable/Event


    private void OnEnable()
    {

        EventManager.ButtonManager += GetThis;

    }

    private void OnDisable()
    {

        EventManager.ButtonManager -= GetThis;

    }

    public ButtonManager GetThis()
    {
        return this;
    }

    #endregion

    public void ButtonStateControl()
    {

        AmountManager amountManager = EventManager.AmountManager.Invoke();

        for (int i = buttons.Count - 1; i >= 0; i--)
        {

            //if (amountManager.AmountCheck(buttons[i].buttonBase.upgradeCost))
            //{

            //    buttons[i].activeButtonImage.SetActive(true);
            //    buttons[i].passiveButtonImage.SetActive(false);

            //}
            //else
            //{

            //    buttons[i].activeButtonImage.SetActive(false);
            //    buttons[i].passiveButtonImage.SetActive(true);

            //}
        }
    }

}
