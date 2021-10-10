using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObjects2 : MonoBehaviour
{
    public GameObject obj;

    void Start()
    {
        InvokeRepeating("SpawnObj", 2 , 1);
    }

    Vector2 GetSpawnPoint()
    {
        float x = Random.Range(-6f, 6f);
        float y = Random.Range(-4f, 4f);

        return new Vector2(x, y);
    }
    void SpawnObj()
    {
        Instantiate(obj, GetSpawnPoint(), Quaternion.identity);
    }

}
