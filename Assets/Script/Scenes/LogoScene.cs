using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.SceneType.LogoScene;
        StartCoroutine(CoWaitLoad());
    }
    IEnumerator CoWaitLoad()
    {
        while (Managers.Data.Loaded() == false)
            yield return null;

        Managers.UI.ShowSceneUI<UI_LogoScene>();

    }
    public override void Clear()
    {
    }
}
