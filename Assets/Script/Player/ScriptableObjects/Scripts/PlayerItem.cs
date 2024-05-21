using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Progress;

public class PlayerItem : Item
{
    public int score;
    public int power;
    public int boom;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            switch(item.type) 
            {
                case ItemType.Coin:
                    score += 1000;
                    break;
                case ItemType Power:
                    power++;
                   break;
                case "Boom":
                    break;

            }
        }
    }
}