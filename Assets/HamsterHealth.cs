using UnityEngine;

public class HamsterHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        Debug.Log("Hamster Health: " + currentHealth);
    }

    private void Die()
    {
        Debug.Log("Hamster ha muerto!");
        Destroy(gameObject);
    }
}
