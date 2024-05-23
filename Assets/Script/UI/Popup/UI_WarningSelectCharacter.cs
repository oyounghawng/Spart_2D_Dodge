using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_WarningSelectCharacter : UI_Popup
{
    enum Buttons
    {
        CloseButton,
    }

    private void Start()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(Close);
    }
    void Close(PointerEventData evt)
    {
        Managers.UI.ClosePopupUI();
    }

}
