using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UI_Pause : UI_Popup
{
    enum GameObjects
    {
    }
    enum Buttons
    {
        ContinueButton,
        QuitButton
    }
    enum Texts
    {
    }
    enum Images
    {
    }

    private void Start()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<RawImage>(typeof(Images));

        GetButton((int)Buttons.ContinueButton).gameObject.BindEvent(continueGame);
        GetButton((int)Buttons.QuitButton).gameObject.BindEvent(returnLobby);
    }
    void continueGame(PointerEventData evt)
    {
        Time.timeScale = 1f;
        Managers.UI.ClosePopupUI();
    }
    void returnLobby(PointerEventData evt)
    {
        Managers.Scene.LoadScene(Define.SceneType.LobbyScene);
    }
}
