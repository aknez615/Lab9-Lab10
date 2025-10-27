using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bullet hit: " + other.name);

        if (other.CompareTag("Target"))
        {
            Debug.Log("Target hit");

            TargetClass target = other.GetComponent<TargetClass>();

            if (target != null)
            {
                target.OnHit();
            }

            gameObject.SetActive(false);
        }
    }
}
