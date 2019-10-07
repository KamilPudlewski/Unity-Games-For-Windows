using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    public float speed = 30;
    private Rigidbody2D rigidBody;

    public Sprite explodedSpaceShipImage;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Player")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.shipExplosion);
            collision.GetComponent<SpriteRenderer>().sprite = explodedSpaceShipImage;
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
}
