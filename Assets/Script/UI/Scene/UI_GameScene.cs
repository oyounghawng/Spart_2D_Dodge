using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UI_GameScene : UI_Scene
{
    private int boom;
    private bool Isboom = false;
    enum GameObjects
    {
        Boom,
        BoomEfect,
    }
    enum Texts
    {
    }
    enum Images
    {
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
        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.PauseButton).gameObject.BindEvent(Pause);
        GetObject((int)GameObjects.Boom).BindEvent(Boom);
        GetObject((int)GameObjects.BoomEfect).SetActive(false);
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
        StartCoroutine(BoomEffect());
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++) 
        {
            Enemy enemyScript = enemies[i].GetComponent<Enemy>();
            enemyScript.OnHit(1000);
        }
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
}