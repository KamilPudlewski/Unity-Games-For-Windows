using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float deactiveTimer = 3f;

    [HideInInspector]
    public bool isEnemyBullet = false;

    void Start()
    {
        if (isEnemyBullet)
        {
            speed *= -1f;
        }

        Invoke("DeactiveGameObject", deactiveTimer);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    private void DeactiveGameObject()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" || collision.tag == "Enemy")
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
