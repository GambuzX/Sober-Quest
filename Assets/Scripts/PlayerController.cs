using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float Speed;
    public ThrowableBottle bottle;

    private bool right;

    private bool lockMovement = false;
    private bool lockThrow = false;
    private bool lockHP = false;

    private LifeManager lifeManager;

    private VirtualJoystick joystick;

    public AudioClip[] throwSounds;
    public AudioClip hitSound;

    private AudioSource audioSource;
    private TimeCounter timeCounter;

    void Start()
    {
        this.lifeManager = GameObject.FindObjectOfType<LifeManager>();
        joystick = GameObject.FindObjectOfType<VirtualJoystick>();
        audioSource = GetComponent<AudioSource>();
        timeCounter = GameObject.FindObjectOfType<TimeCounter>();
        timeCounter.resetTime();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(joystick.Horizontal(),joystick.Vertical(), 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        if (movement.x > 0) right = true;
        if (movement.x < 0) right = false;
        animator.SetBool("Right", right);

        if (!lockMovement) transform.position = transform.position + movement * Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            throwBottle();
        }

    }


    public void throwBottle()
    {
        if (this.lockThrow) return;

        lockThrow = true;
        lockMovement = true;
        animator.SetTrigger("throw_bottle");
        ThrowableBottle newBottle = (ThrowableBottle)GameObject.Instantiate(bottle, new Vector3(transform.position.x, transform.position.y, -5), Quaternion.identity);
        newBottle.setMoveDirection(right ? 1 : -1);
        Invoke("unlockThrow", 1);
        Invoke("unlockMovement", 0.3f);

        int rand = Random.Range(0, throwSounds.Length);
        audioSource.clip = throwSounds[rand];
        audioSource.Play();
        
    }

    private void unlockMovement()
    {
        this.lockMovement = false;
    }

    private void unlockThrow()
    {
        this.lockThrow = false;
    }

    private void unlockHP()
    {
        this.lockHP = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!lockHP && collision.transform.tag == "Enemy")
        {
            this.lockHP = true;
            Invoke("unlockHP", 3);
            lifeManager.decreaseHP();
            audioSource.clip = hitSound;
            audioSource.Play();
            if (lifeManager.playerDead())
            {
                this.endGame();
            }
        }
    }

    private void endGame()
    {
        int score = timeCounter.getTime();
        if (score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", score);
            SceneManager.LoadScene("WinScreen");
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}