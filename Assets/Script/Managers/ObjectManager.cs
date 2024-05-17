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
        Managers.Instantiate(go);
    }
}
