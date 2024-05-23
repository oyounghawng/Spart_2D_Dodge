using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLimit"))
        {
            Managers.Resource.Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            CharacterStatsHandler statsHandler = collision.GetComponent<CharacterStatsHandler>();
            int curHealth = statsHandler.CurrentStat.maxHealth;
            (Managers.UI.SceneUI as UI_GameScene).UIHeartUpdate(curHealth, false);
            statsHandler.CurrentStat.maxHealth--;
            Managers.Resource.Destroy(this.gameObject);
            if (statsHandler.CurrentStat.maxHealth <= 0)
            {
                Managers.UI.ShowPopupUI<UI_GameOver>();
            }

        }
    }
}
