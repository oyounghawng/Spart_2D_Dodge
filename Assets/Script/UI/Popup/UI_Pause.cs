using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Pause : UI_Popup
{

    enum Buttons
    {
        ContinueButton,
        QuitButton
    }
    enum Toggles
    {
        BgmToggle,
        EffectToggle
    }

    private void Start()
    {
        base.Init();
        Bind<GameObject>(typeof(Toggles));
        Bind<Button>(typeof(Buttons));

        GetObject((int)Toggles.BgmToggle).GetComponent<Toggle>().onValueChanged.AddListener(OnBgmToggleSelected);
        GetObject((int)Toggles.BgmToggle).GetComponent<Toggle>().isOn = Managers.Game.BGMOn;
        GetObject((int)Toggles.EffectToggle).GetComponent<Toggle>().onValueChanged.AddListener(OnEffectSoundToggleSelected);
        GetObject((int)Toggles.EffectToggle).GetComponent<Toggle>().isOn = Managers.Game.EffectSoundOn;


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

    void OnBgmToggleSelected(bool boolean)
    {
        Managers.Game.BGMOn = boolean;

        if (boolean)
            Managers.Sound.Play(Define.Sound.Bgm);
        else
            Managers.Sound.Stop(Define.Sound.Bgm);
    }

    void OnEffectSoundToggleSelected(bool boolean)
    {
        Managers.Game.EffectSoundOn = boolean;
    }
}