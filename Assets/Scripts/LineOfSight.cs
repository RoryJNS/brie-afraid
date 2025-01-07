using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public Enemy enemy;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            enemy.StartChase();
        }
    }
}