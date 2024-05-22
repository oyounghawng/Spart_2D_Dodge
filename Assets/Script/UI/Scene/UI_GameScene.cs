using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UI_GameScene : UI_Scene
{
    public int boom;
    enum GameObjects
    {
        Boom,
        boomEffect
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
    }

    void Pause(PointerEventData evt)
    {
        Time.timeScale = 0f;
        Managers.UI.ShowPopupUI<UI_Pause>();
    }
    public GameObject boomEffect;
    void Boom(PointerEventData evt)
    {
        //Boom ·ÎÁ÷ÀÛ¼º!
        Debug.Log("ºÕ!");
        if (Input.GetButton("Boom"))
        {
            return;
        }
        if(boom == 0)
        {
            return;
        }
        boom -= 1;

        boomEffect.SetActive(true);

        Invoke("offBoomEffect", 4f);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++) 
        {
            Enemy enemyScript = enemies[1].GetComponent<Enemy>();
            enemyScript.OnHit(1000);
        }
        GameObject[] enemyBullet = GameObject.FindGameObjectsWithTag("EnemyBullet");
        for(int i = 0; i <enemyBullet.Length; i++)
        {
            Destroy(enemyBullet[i]);
        }

        
    }
}