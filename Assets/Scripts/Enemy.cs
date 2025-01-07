using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    bool chasing;
    AIDestinationSetter destinationSetter;
    Patrol patrol;
    public GameManager gameManager;
    public AudioSource music;
    public AudioClip chaseMusic, ambience;

    void Start()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        patrol = GetComponent<Patrol>();
        StartPatrol();
    }

    void Update()
    {
        if (chasing && Vector3.Distance(transform.position, destinationSetter.target.position) > 8)
        {
            StartPatrol();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameManager.sfxSource.clip = gameManager.deathSqueak;
            gameManager.sfxSource.Play();
            gameManager.GameOver();
        }
    }

    public void StartChase()
    {
        patrol.enabled = false;
        destinationSetter.enabled = true;
        chasing = true;
        music.Stop();
        music.clip = chaseMusic;
        music.Play();
    }

    void StartPatrol()
    {
        music.clip = ambience;
        music.Play();
        destinationSetter.enabled = false;
        patrol.enabled = true;
        chasing = false;
    }
}