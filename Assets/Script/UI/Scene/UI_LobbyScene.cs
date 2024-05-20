using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UI_LobbyScene : UI_Scene
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
    }

    void GameStart(PointerEventData evt)
    {
        Managers.Scene.LoadScene(Define.SceneType.GameScene);
    }
}
