using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    private GameObject bullet;
    private bool isOnBullet;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnBullet)
            {
                Time.timeScale = 1f;
                transform.SetParent(null);
                isOnBullet = false;
            }
            else
            {
                bullet = GetClosestBullet();
                if (bullet != null)
                {
                    Time.timeScale = 0.01f;
                    LeanTween.move(gameObject, bullet.transform.position, 0.01f);
                    transform.SetParent(bullet.transform);
                    isOnBullet = true;
                }
            }
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
}