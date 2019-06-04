using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    private Transform target;
    public Animator animator;

    public AudioClip[] idleSounds;
    public AudioClip dieSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        animator = this.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("playIdleSound", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {

        if (target.position.x > transform.position.x) animator.SetBool("right", true);
        if (target.position.x < transform.position.x) animator.SetBool("right", false);

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);


    }

    private void playIdleSound()
    {
        int rand = Random.Range(0, idleSounds.Length);
        audioSource.clip = idleSounds[rand];
        audioSource.Play();
    }

    public void die()
    {
        audioSource.clip = dieSound;
        audioSource.Play();

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Animator>().enabled = false;

        Invoke("destroyObject", 2);
    }

    private void destroyObject()
    {
        Destroy(this.gameObject);
    }


}
