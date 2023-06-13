using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 releaseForce;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    private GameObject bullet;
    private GameObject arrow;
    private GameObject[] bullets;
    [SerializeField] private GameObject victoryText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movement = new Vector2(horizontalInput, verticalInput);

        if (Input.GetKey(KeyCode.Space))
        {
            if (bullet == null)
            {
                bullet = GetClosestBullet();
                if (bullet != null)
                {
                    rb.velocity = Vector2.zero;
                    LeanTween.move(gameObject, bullet.transform.position, 0.05f);
                    Time.timeScale = 0.1f;
                    transform.SetParent(bullet.transform);
                }
                else
                {
                    rb.velocity = (movement * speed);
                }
            }
        }
        else
        {
            rb.velocity = (movement * speed);
            Time.timeScale = 1f;
            bullet = null;
            transform.SetParent(null);
        }
    }

    private GameObject GetClosestBullet()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Bullet"))
            {
                return collider.gameObject;
            }
        }

        return null;
    }

    private void ChangeBulletsSpeed(GameObject[] bullets, float speed)
    {
        foreach (var bullet in bullets)
        {
            bullet.GetComponent<BulletController>().SetSpeed(speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
       victoryText.SetActive(true); 
    }
}