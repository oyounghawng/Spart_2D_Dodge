using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{

    GameObject player;

    public GameObject Player
    {
        get
        {
            return player;
        }
        private set
        {
            player = value;
        }
    }
    public ObjectManager()
    {
        Init();
    }
    public void Init()
    {
        
    }

    public void SpawnPlayer()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Player");
        Player = go;
        go.transform.position = new Vector2(0, -6.5f);
        Managers.Resource.Instantiate(go);
        Managers.Resource.Instantiate("BackGround");
        Managers.Resource.Instantiate("Collider");
        Managers.Resource.Instantiate("EnemySpawner");
    }
}
