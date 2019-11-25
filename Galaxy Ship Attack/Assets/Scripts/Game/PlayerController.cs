using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public float minY, maxY;

    public Sprite[] spaceshipSprites;
    public RuntimeAnimatorController[] spaceshipController;

    [SerializeField]
    private GameObject playerBullet;

    [SerializeField]
    private Transform attackPoint;

    public float reloadTimer = 0.5f;
    private float currentReloadTimer = 0f;
    private bool canMove = true;
    private bool canAttack = true;

    private Animator anim;
    private AudioSource attackAudio;
    private AudioSource explosionAudio;

    public Score score;

    void Awake()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        attackAudio = audioSources[0];
        explosionAudio = audioSources[1];
        anim = GetComponent<Animator>();
        LoadSpaceshipModel();
    }

    void Start()
    {

    }

    void Update()
    {
        MovePlayer();
        Attack();
    }

    private void LoadSpaceshipModel()
    {
        SpriteRenderer spaceship = GetComponent<SpriteRenderer>();
        Animator animator = GetComponent<Animator>();

        switch (PlayerPrefs.GetInt("SelectedSpaceship"))
        {
            case 0:
                spaceship.sprite = spaceshipSprites[0];
                animator.runtimeAnimatorController = spaceshipController[0];
                break;
            case 1:
                spaceship.sprite = spaceshipSprites[1];
                animator.runtimeAnimatorController = spaceshipController[1];
                break;
            case 2:
                spaceship.sprite = spaceshipSprites[2];
                animator.runtimeAnimatorController = spaceshipController[2];
                break;
            case 3:
                spaceship.sprite = spaceshipSprites[3];
                animator.runtimeAnimatorController = spaceshipController[3];
                break;
            case 4:
                spaceship.sprite = spaceshipSprites[4];
                animator.runtimeAnimatorController = spaceshipController[4];
                break;
            default:
                spaceship.sprite = spaceshipSprites[0];
                animator.runtimeAnimatorController = spaceshipController[0];
                break;
        }
    }

    private void MovePlayer()
    {
        if (canMove)
        {
            if (Input.GetAxisRaw("Vertical") > 0f)
            {
                Vector3 temp = transform.position;
                temp.y += speed * Time.deltaTime;

                if (temp.y > maxY)
                {
                    temp.y = maxY;
                }

                transform.position = temp;
            }
            else if (Input.GetAxisRaw("Vertical") < 0f)
            {
                Vector3 temp = transform.position;
                temp.y -= speed * Time.deltaTime;

                if (temp.y < minY)
                {
                    temp.y = minY;
                }

                transform.position = temp;
            }
        }
    }

    private void Attack()
    {
        if (currentReloadTimer > 0)
        {
            currentReloadTimer -= Time.deltaTime;
        }
        if (currentReloadTimer <= 0)
        {
            canAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canAttack)
            {
                canAttack = false;
                currentReloadTimer = reloadTimer;

                Instantiate(playerBullet, attackPoint.position, Quaternion.identity);
                attackAudio.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" || collision.tag == "Enemy")
        {
            score.StopCountScore();
            Invoke("DestroyGameOject", 0.5f);
            canMove = false;
            canAttack = false;
            explosionAudio.Play();
            anim.Play("Destroy");
            PlayerPrefs.SetInt("Score", score.ReturnScore());
            Invoke("OpenResultMenu", 0.5f);
            //gameObject.SetActive(false);
        }
    }

    private void DestroyGameOject()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OpenResultMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
