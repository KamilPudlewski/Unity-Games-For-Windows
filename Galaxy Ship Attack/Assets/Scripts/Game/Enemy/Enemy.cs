using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 50f;

    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;

    public float boundX = -11f;

    public Transform attackPoint;
    public GameObject bulletPrefab;

    private SettingsManager settingsManager;

    private Animator anim;
    private AudioSource explosionSound;
    private SpriteRenderer spriteRenderer;


    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
        settingsManager = ScriptableObject.CreateInstance("SettingsManager") as SettingsManager;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Initialization();
    }

    void Start()
    {
        if (canRotate)
        {
            if (Random.Range(0, 2) > 0)
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
            else
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
            }
        }

        if (canShoot)
        {
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }

    void Update()
    {
        Move();
        RotateEnemy();
    }

    private void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.x < boundX)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    private void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }
    }

    private void StartShooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().isEnemyBullet = true;
        bullet.GetComponent<AudioSource>().Play();

        if (canShoot)
        {
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }

    private void DestroyGameOject()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            canMove = false;

            if (canShoot)
            {
                canShoot = false;
                CancelInvoke("StartShooting");
            }
            GameObject.Find("Spaceship").GetComponent<PlayerController>().score.AddDestructionPoints(DestructionPoints());

            Invoke("DestroyGameOject", 0.5f);
            explosionSound.Play();
            anim.Play("Destroy");
        }
    }

    private void Initialization()
    {
        if (spriteRenderer.name == "Asteroid 1(Clone)")
        {
            speed = settingsManager.settings.asteroid1Speed;
        }
        else if (spriteRenderer.name == "Asteroid 2(Clone)")
        {
            speed = settingsManager.settings.asteroid2Speed;
        }
        else if (spriteRenderer.name == "Asteroid 3(Clone)")
        {
            speed = settingsManager.settings.asteroid3Speed;
        }
        else if (spriteRenderer.name == "Enemy(Clone)")
        {
            speed = settingsManager.settings.ospaceshipSpeed;
        }
        else if (spriteRenderer.name == "Tesla(Clone)")
        {
            speed = settingsManager.settings.teslaSpeed;
        }
        else
        {
            Debug.Log("Unknown sprite name: " + spriteRenderer.name);
        }
    }

    private int DestructionPoints()
    {
        if (spriteRenderer.name == "Asteroid 1(Clone)")
        {
            return settingsManager.settings.asteroid1Points;
        }
        else if (spriteRenderer.name == "Asteroid 2(Clone)")
        {
            return settingsManager.settings.asteroid2Points;
        }
        else if (spriteRenderer.name == "Asteroid 3(Clone)")
        {
            return settingsManager.settings.asteroid3Points;
        }
        else if (spriteRenderer.name == "Enemy(Clone)")
        {
            return settingsManager.settings.ospaceshipPoints;
        }
        else if (spriteRenderer.name == "Tesla(Clone)")
        {
            return settingsManager.settings.teslaPoints;
        }
        else
        {
            Debug.Log("Unknown sprite name: " + spriteRenderer.name);
            return 0;
        }
    }
}
