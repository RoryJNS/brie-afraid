using UnityEngine;

public class Door : MonoBehaviour
{
    SpriteRenderer sprite;
    public GameManager gameManager;
    public string colour;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if ((colour == "red" && gameManager.CheckRed())
                || (colour == "green" && gameManager.CheckGreen())
                   || (colour == "blue" && gameManager.CheckBlue()))
            {
                gameManager.totalUnlocked++;
                sprite.color = new Color(0.75f, 0.75f, 0.75f);
                gameManager.sfxSource.clip = gameManager.insertKey;
                gameManager.sfxSource.Play();

                if (gameManager.totalUnlocked == 3)
                {
                    gameManager.UnlockEndRoom();
                }
            }
        }
    }
}