using UnityEngine;

public class DiamondCollector : MonoBehaviour
{
    public int DiamondsRequired = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            DiamondsRequired--;

            if (DiamondsRequired <= 0)
            {
                // All diamonds collected logic here
                Debug.Log("All required diamonds collected!");
            }
        }
    }
}

