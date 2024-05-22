using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private int boomcnt;
    public int BoomCnt
    {
        get { return boomcnt; }
        set { boomcnt += value; 
            //UI ó������ ����
        }
    }
    private int score;
    public int Score
    {
        get { return score; }
        set { score += value; 
            //UI ó������ ����
        }
    }
    protected override void Init()
    {
        base.Init();
        SceneType = Define.SceneType.GameScene;
        StartCoroutine(CoWaitLoad());
    }
    IEnumerator CoWaitLoad()
    {
        while (Managers.Data.Loaded() == false)
            yield return null;

        Managers.Object.SpawnPlayer();
        Managers.UI.ShowSceneUI<UI_GameScene>();
        boomcnt = 1;
    }
    public override void Clear()
    {
    }
}
