using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 30;
    private Rigidbody2D rigidBody;

    public Sprite explodedAlienImage;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Alien")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
            IncreaseTextUIScore();

            collision.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;
            Destroy(gameObject);

            Object.Destroy(collision.gameObject, 0.5f);
        }

        if (collision.tag == "Shield")
        {
            Destroy(gameObject);
            Object.Destroy(collision.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void IncreaseTextUIScore()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();

        int score = int.Parse(textUIComp.text);
        score += 10;

        textUIComp.text = score.ToString();
    }
}
