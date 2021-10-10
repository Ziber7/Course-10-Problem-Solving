using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject box;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpawnBox();
    }

    void Update()
    {
        //SpawnBox();
    }

    private void SpawnBox()
    {
        bool boxIsSpawned = false;
        while (!boxIsSpawned)
        {
            Vector3 boxPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0f);
            if ((boxPosition - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                StartCoroutine(wait());
                Instantiate(box, boxPosition, Quaternion.identity);
                boxIsSpawned = true;
            }
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }
}
