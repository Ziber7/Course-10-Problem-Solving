using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowMouse2 : MonoBehaviour
{
    public float moveSpeed = 10;

    public Text scoreText;
    public int score;

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        scoreText.text = score.ToString();
    }

    void Start()
    {
        score = 0;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "box")
        {
            Destroy(target.gameObject);
            score += 1;
        }
    }
}
