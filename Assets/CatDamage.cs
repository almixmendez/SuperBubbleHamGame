using UnityEngine;

public class CatDamage : MonoBehaviour
{
    public int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || (collision.gameObject.CompareTag("Player2")))
        {
            HamsterHealth hamsterHealth = collision.gameObject.GetComponent<HamsterHealth>();

            if (hamsterHealth != null)
            {
                hamsterHealth.TakeDamage(damageAmount);
                Debug.Log("Auch!");
            }
        }
    }
}
