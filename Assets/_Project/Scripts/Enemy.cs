using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float fireRate;
    private float lastFireTime;

    private void Start()
    {
        lastFireTime = Time.time;
    }

    private void Update()
    {
        Move();
        FireBullet();
    }

    private void Move()
    {
        // Implement enemy movement logic here
        // You can use transform.Translate, transform.position, or Rigidbody2D
    }

    private void FireBullet()
    {
        if (Time.time-lastFireTime > fireRate)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            
            BulletController bulletScript = bullet.GetComponent<BulletController>();
            bulletScript.SetDirection(transform.up);
            bulletScript.SetSpeed(10f);
            
            lastFireTime = Time.time;
        }
    }


}
