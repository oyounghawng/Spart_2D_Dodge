using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UI_GameScene : UI_Scene
{
    enum GameObjects
    {
    }
    enum Texts
    {
    }
    enum Images
    {
    }
    enum Buttons
    {
        PauseButton
    }
    private void Start()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.PauseButton).gameObject.BindEvent(Puase);
    }

    void Puase(PointerEventData evt)
    {
        Time.timeScale = 0f;
        Managers.UI.ShowPopupUI<UI_Pause>();
    }
}