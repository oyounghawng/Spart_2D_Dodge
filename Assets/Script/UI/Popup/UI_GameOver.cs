using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GameOver : UI_Popup
{
    enum Buttons
    {
        ContinueButton,
        QuitButton
    }
    enum Texts
    {
        ScoreText,
        TimeText,
    }
    private void Start()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        Time.timeScale = 0f;
        GetButton((int)Buttons.ContinueButton).gameObject.BindEvent(continueGame);
        GetButton((int)Buttons.QuitButton).gameObject.BindEvent(returnLobby);
        GameScene gameScene = Managers.Scene.CurrentScene as GameScene;
        GetText((int)Texts.ScoreText).text += gameScene.Score.ToString();
        UI_GameScene ui_gameScene = Managers.UI.SceneUI as UI_GameScene;
        float time = ui_gameScene.time;
        int min = (int)time / 60;
        int sec = (int)time % 60;
        GetText((int)Texts.TimeText).text += string.Format("{0:D2}:{1:D2}", min, sec);
    }
    void continueGame(PointerEventData evt)
    {
        Time.timeScale = 1f;
        Managers.Scene.LoadScene(Define.SceneType.GameScene);
    }
    void returnLobby(PointerEventData evt)
    {
        Time.timeScale = 1f;
        Managers.Scene.LoadScene(Define.SceneType.LobbyScene);
    }
}
