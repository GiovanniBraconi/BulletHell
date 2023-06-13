using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (IsOutOfBoundaries())
        {
            Destroy(gameObject);
        }
    }

    private bool IsOutOfBoundaries()
    {
        return transform.position.y > 10f || transform.position.y < -10f || transform.position.x > 10f || transform.position.x < -10f;
    }

    public void SetDirection(Vector2 direction)
    {
        transform.up = direction;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    
}