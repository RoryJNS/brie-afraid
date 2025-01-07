using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    bool gotRed, gotGreen, gotBlue, gameHasEnded;
    public int totalUnlocked;
    public GameObject redDoor, greenDoor, blueDoor;
    public PlayerMovement playerMovement;
    public GameObject startDialogue, endDialogue1, endDialogue2, endDialogue3, endDialogue4, endDialogue5;
    public GameObject blackScreen, yellowScreen, videoScreen;
    public VideoPlayer vidPlayer;
    public AudioSource music, sfxSource;
    public AudioClip freeBird, keyPickUp, insertKey, deathSqueak, menuClick;
    public Animator playerAnim;
    public GameObject playerCreditsImage, creditsText;
    bool credits;

    void Start()
    {
        gotRed = false;
        gotGreen = false;
        gotBlue = false;
        gameHasEnded = false;
        credits = false;
        totalUnlocked = 0;
        playerMovement.movementLocked = true;
        startDialogue.SetActive(true);
    }

    public void SetRed()
    {
        gotRed = true;
        sfxSource.clip = keyPickUp;
        sfxSource.Play();
    }

    public bool CheckRed()
    {
        return gotRed;
    }

    public void SetGreen()
    {
        gotGreen = true;
        sfxSource.clip = keyPickUp;
        sfxSource.Play();
    }

    public bool CheckGreen()
    {
        return gotGreen;
    }

    public void SetBlue()
    {
        gotBlue = true;
        sfxSource.clip = keyPickUp;
        sfxSource.Play();
    }

    public bool CheckBlue()
    {
        return gotBlue;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            UnlockEndRoom();
        }
        if (credits)
        {
            playerCreditsImage.transform.Rotate(0, 0, 70 * Time.deltaTime);
        }
    }

    public void UnlockEndRoom()
    {
        Destroy(redDoor);
        Destroy(greenDoor);
        Destroy(blueDoor);
        InitiateEndDialogue();
    }

    public void GameOver()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            playerMovement.movementLocked = true;
            Invoke("Restart", 0.5f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void InitiateEndDialogue()
    {
        playerMovement.movementLocked = true;
        playerAnim.SetFloat("Speed", 0);
        endDialogue1.SetActive(true);
        sfxSource.clip = menuClick;
    }

    public void CloseDialogBox(GameObject dialogueBox)
    {
        dialogueBox.SetActive(false);

        switch (dialogueBox.name)
        {
            case "StartDialogue":
                playerMovement.movementLocked = false;
                break;
            case "EndDialogue1":
                endDialogue2.SetActive(true);
                break;
            case "EndDialogue2":
                endDialogue3.SetActive(true);
                break;
            case "EndDialogue3":
                endDialogue4.SetActive(true);
                break;
            case "EndDialogue4":
                endDialogue5.SetActive(true);
                break;
            case "EndDialogue5":
                FadeToBlack();
                break;
            default:
                break;
        }
    }

    void FadeToBlack()
    {
        blackScreen.SetActive(true);
        Invoke("InitiateCutscene", 3f);
    }

    void InitiateCutscene()
    {
        videoScreen.SetActive(true);
        blackScreen.SetActive(false);
        vidPlayer.Play();
        Invoke("InitiateCredits", 47f); //REPLACE WITH CUTSCENE CLIP TIME + 1
    }

    void InitiateCredits()
    {
        yellowScreen.SetActive(true);
        Invoke("StartMusic", 0.5f);
    }

    void StartMusic()
    {
        videoScreen.SetActive(false);
        music.clip = freeBird;
        music.Play();
        Invoke("StartSpin", 5.5f);
    }

    void StartSpin()
    {
        playerCreditsImage.SetActive(true);
        creditsText.SetActive(true);
        credits = true;
        Invoke("BackToMenu", 47f);
    }

    void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}