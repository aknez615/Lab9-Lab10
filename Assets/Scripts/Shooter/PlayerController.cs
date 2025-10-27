using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public BulletPool bulletPool;
    public Transform firePoint;

    private void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveInput * moveSpeed * Time.deltaTime);
    }

    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = bulletPool.GetBullet();

            if (bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    rb.linearVelocity = Vector2.zero;
                    rb.AddForce(firePoint.up * 500);
                }
            }
        }
    }
}
