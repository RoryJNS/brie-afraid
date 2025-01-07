using UnityEngine;

public class Key : MonoBehaviour
{
    public GameManager gameManager;
    public string colour;
    public AudioSource sfxSource;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Key collected");

            if (colour == "red")
                gameManager.SetRed();
            else if (colour == "green")
                gameManager.SetGreen();
            else if (colour == "blue")
                gameManager.SetBlue();

            Destroy(gameObject);
        }
    }
}