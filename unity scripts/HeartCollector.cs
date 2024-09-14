using UnityEngine;

public class HeartCollector : MonoBehaviour
{
    public int health = 100; // Starting health
    public int maxHealth = 500; // Maximum health

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            CollectHeart();
            Destroy(other.gameObject);
        }
    }

    void CollectHeart()
    {
        if (health < maxHealth)
        {
            health += 5;
            if (health > maxHealth)
            {
                health = maxHealth; // Ensure health does not exceed maxHealth
            }
            Debug.Log("Collected a heart! Health: " + health);
        }
        else
        {
            Debug.Log("Health is already at maximum!");
        }
    }
}
