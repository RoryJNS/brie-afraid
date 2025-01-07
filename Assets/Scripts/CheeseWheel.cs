using System.Collections;
using UnityEngine;
using Pathfinding;

public class CheeseWheel : MonoBehaviour
{
    Animator animator;
    AIBase aiBase;
    public AudioSource audioSource;
    public AudioClip rolling, fallOver;

    void Awake()
    {
        animator = GetComponent<Animator>();
        aiBase = GetComponent<AIBase>();
        aiBase.maxSpeed += 2f; //NOT WORKING
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Walls"))
        {
            Debug.Log("Hit wall");
            animator.SetTrigger("FallOver");
            audioSource.clip = fallOver;
            audioSource.loop = false;
            audioSource.Play();
            StartCoroutine(WaitToGetUp());
        }
    }

    IEnumerator WaitToGetUp()
    {
        yield return new WaitForSeconds(2f);
        GetUp();
    }

    void GetUp()
    {
        animator.SetTrigger("GetUp");
        Invoke("KeepRollingNoise", 1.6f);
    }

    void KeepRollingNoise()
    {
        audioSource.clip = rolling;
        audioSource.loop = true;
        audioSource.Play();
    }
}