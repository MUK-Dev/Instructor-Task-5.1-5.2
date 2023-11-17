using UnityEngine;

public class Barrel : MonoBehaviour
{
    private int score = 100;

    public int GetScore()
    {
        int returningScore = score;
        score = 0;
        return returningScore;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
