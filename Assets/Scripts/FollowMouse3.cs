using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowMouse3 : MonoBehaviour
{
    public GameObject obj;
    public float moveSpeed = 10;

    public Text scoreText;
    public int score;

    void Start()
    {
        score = 0;
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

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        scoreText.text = score.ToString();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "box")
        {
            Destroy(target.gameObject);
            score += 1;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        SpawnObj();
    }
}
