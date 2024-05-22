using UnityEngine;
using UnityEngine.EventSystems;

public class UI_LogoScene : UI_Scene
{
    private GameObject SelectGameObject;
    enum GameObjects
    {
        Title
    }
    private void Start()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));

        GetObject((int)GameObjects.Title).BindEvent(GameStart);
    }

    void GameStart(PointerEventData evt)
    {
        Managers.Scene.LoadScene(Define.SceneType.LobbyScene);
    }
}