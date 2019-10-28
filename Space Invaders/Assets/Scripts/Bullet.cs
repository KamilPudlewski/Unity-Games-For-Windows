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
            Score.Instance.IncreaseScore(10);

            collision.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;
            Destroy(gameObject);

            Object.Destroy(collision.gameObject, 0.18f);
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
}
