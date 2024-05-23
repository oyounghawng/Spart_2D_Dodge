using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UI_GameScene : UI_Scene
{
    private int boom;
    private bool Isboom = false;
    public float time = 0f;
    private TextMeshProUGUI timeTxt;
    private GameScene gameScene;
    enum GameObjects
    {
        Boom,
        BoomEfect,
        LifegridPanel,
    }
    enum Texts
    {
        BoomCnt,
        ScoreTxt,
        PlayTime,
    }
    enum Buttons
    {
        PauseButton
    }
    private void Start()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Button>(typeof(Buttons));

        gameScene = Managers.Scene.CurrentScene as GameScene;
        GetButton((int)Buttons.PauseButton).gameObject.BindEvent(Pause);
        GetObject((int)GameObjects.Boom).BindEvent(Boom);
        GetObject((int)GameObjects.BoomEfect).SetActive(false);
        timeTxt = GetText((int)Texts.PlayTime);
        UIUpdate();
        SetLife();
    }
    private void Update()
    {
        time += Time.deltaTime;
        int min = (int)time / 60;
        int sec = (int)time % 60;
        timeTxt.text = string.Format("{0:D2}:{1:D2}", min, sec);
    }

    private void SetLife()
    {
        GameObject gridPanel = GetObject((int)GameObjects.LifegridPanel);
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        UI_LifeSet Life = Managers.UI.MakeSubItem<UI_LifeSet>(gridPanel.transform);

        for (int i = 0; i < 7; i++)
        {
            UI_LifeSet Life1 = Managers.UI.MakeSubItem<UI_LifeSet>(gridPanel.transform);
            Life1.gameObject.SetActive(false);
        }
    }
    void Pause(PointerEventData evt)
    {
        Time.timeScale = 0f;
        Managers.UI.ShowPopupUI<UI_Pause>();
    }
    void Boom(PointerEventData evt)
    {
        Debug.Log("ºÕ!");
        GameScene gameScene = Managers.Scene.CurrentScene as GameScene;
        boom = gameScene.BoomCnt;
        if (boom == 0 || Isboom)
        {
            return;
        }
        gameScene.BoomCnt = -1;
        GetText((int)Texts.BoomCnt).text = gameScene.BoomCnt.ToString();
        StartCoroutine(BoomEffect());
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemyScript = enemies[i].GetComponent<Enemy>();
            enemyScript.OnHit(1000);
        }
        Managers.Sound.Play(Define.Sound.Effect, "Effect/Boom", 0.3f);
        /*
        GameObject[] enemyBullet = GameObject.FindGameObjectsWithTag("EnemyBullet");
        for(int i = 0; i <enemyBullet.Length; i++)
        {
            Destroy(enemyBullet[i]);
        }
        */
    }
    private IEnumerator BoomEffect()
    {
        GameObject go = GetObject((int)GameObjects.BoomEfect);
        go.SetActive(true);
        Isboom = true;
        yield return new WaitForSeconds(2f);
        Isboom = false;
        go.SetActive(false);
    }
    public void UIUpdate()
    {
        GetText((int)Texts.BoomCnt).text = gameScene.BoomCnt.ToString();
        GetText((int)Texts.ScoreTxt).text = gameScene.Score.ToString(); ;
    }

    public void UIHeartUpdate(int idx, bool IsActive)
    {
        GameObject gridPanel = GetObject((int)GameObjects.LifegridPanel);
        gridPanel.transform.GetChild(idx - 1).gameObject.SetActive(IsActive);
    }
}