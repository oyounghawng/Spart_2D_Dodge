using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UI_LobbyScene : UI_Scene
{
    private GameObject SelectGameObject;
    enum GameObjects
    {
        CharacterSet1,
        CharacterSet2,
        CharacterSet3,
        CharacterSet4,
    }
    enum Texts
    {
    }
    enum Images
    {
    }
    enum Buttons
    {
        StartButton
    }
    private void Start()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.StartButton).gameObject.BindEvent(GameStart);

        GetObject((int)GameObjects.CharacterSet1).BindEvent(SelectCharacterPanel);
        GetObject((int)GameObjects.CharacterSet2).BindEvent(SelectCharacterPanel);
        GetObject((int)GameObjects.CharacterSet3).BindEvent(SelectCharacterPanel);
        GetObject((int)GameObjects.CharacterSet4).BindEvent(SelectCharacterPanel);
    }


    void SelectCharacterPanel(PointerEventData evt)
    {
        if (SelectGameObject == null)
        {
            SelectGameObject = evt.pointerClick;
            SelectGameObject.GetComponent<UI_CharacterSet>().ActivePanel();
        }
        else
        {
            SelectGameObject.GetComponent<UI_CharacterSet>().DeActivePanel();
            SelectGameObject = evt.pointerClick;
            SelectGameObject.GetComponent<UI_CharacterSet>().ActivePanel();
        }
    }
    void GameStart(PointerEventData evt)
    {
        if(SelectGameObject == null)
        {
            Managers.UI.ShowPopupUI<UI_WarningSelectCharacter>();
            return;
        }
        Managers.Scene.LoadScene(Define.SceneType.GameScene);
    }
}