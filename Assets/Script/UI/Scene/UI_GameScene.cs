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
        Boom,
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

        GetButton((int)Buttons.PauseButton).gameObject.BindEvent(Pause);
        GetObject((int)GameObjects.Boom).BindEvent(Boom);
    }

    void Pause(PointerEventData evt)
    {
        Time.timeScale = 0f;
        Managers.UI.ShowPopupUI<UI_Pause>();
    }
    void Boom(PointerEventData evt)
    {
        //Boom ·ÎÁ÷ÀÛ¼º!
        Debug.Log("ºÕ!");
    }
}