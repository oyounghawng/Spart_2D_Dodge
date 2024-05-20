using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterSet : UI_Base
{
    enum GameObjects
    {
        SelectFrame,
    }
    enum Images
    {
        
    }

    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        GetObject((int)GameObjects.SelectFrame).SetActive(false);
    }
    public void ActivePanel()
    {
        GetObject((int)GameObjects.SelectFrame).SetActive(true);
    }
    public void DeActivePanel()
    {
        GetObject((int)GameObjects.SelectFrame).SetActive(false);
    }
}
