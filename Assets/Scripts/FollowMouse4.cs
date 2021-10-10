using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowMouse4 : MonoBehaviour
{
    public GameObject obj;

    public float moveSpeed = 10;

    public Text scoreText;
    public int score;

    public AudioSource audio;
    public AudioClip CollectSound;

    void Start()
    {
        score = 0;
        InvokeRepeating("SpawnObj", 2 , 1);
        audio = GetComponent<AudioSource>();
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
            audio.PlayOneShot(CollectSound, 0.7F);
            Destroy(target.gameObject);
            score += 1;
        }

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
    }
}
