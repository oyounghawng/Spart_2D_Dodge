using UnityEngine;

public enum ItemType
{
    Boom,
    Coin,
    Power,
    Heal,
    Movement,
}
public class Item : MonoBehaviour
{
    public ItemType type;
    Rigidbody2D rigid;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * 0.5f;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameScene gameScene = Managers.Scene.CurrentScene as GameScene;
            CharacterStatsHandler statsHandler = collision.gameObject.GetComponent<CharacterStatsHandler>();
            switch (type)
            {
                case ItemType.Coin:
                    gameScene.Score = 100;
                    break;
                case ItemType.Boom:
                    gameScene.BoomCnt = 1;
                    break;
                case ItemType.Power:
                    statsHandler.AddLevelEffect();
                    break;
                case ItemType.Heal:
                    statsHandler.AddHealthEffect();
                    break;
                case ItemType.Movement:
                    statsHandler.AddMovementEffect();
                    break;
            }
            Managers.Resource.Destroy(this.gameObject);
        }
    }
}
