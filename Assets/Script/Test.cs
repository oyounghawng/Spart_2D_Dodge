using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject go;

    private void Start()
    {
        GameObject testGO = Managers.Resource.Instantiate("Player");

        Managers.Resource.Instantiate(go); // ����
        Managers.Resource.Destroy(go);
    }
}
