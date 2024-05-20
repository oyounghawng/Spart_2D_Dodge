using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.SceneType.LobbyScene;
        StartCoroutine(CoWaitLoad());
    }
    IEnumerator CoWaitLoad()
    {
        while (Managers.Data.Loaded() == false)
            yield return null;

    }
    public override void Clear()
    {
    }
}