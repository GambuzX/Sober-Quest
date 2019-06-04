using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableBottle : MonoBehaviour
{
    public float movespeed = 1.5f;
    private int movedir = 0;

    public AudioClip shatterSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x + movespeed * movedir * Time.deltaTime, this.transform.position.y, this.transform.position.z);
    }

    public void setMoveDirection(int movedir)
    {
        this.movedir = movedir;
        GetComponent<Animator>().SetBool("right", movedir > 0 ? true : false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            audioSource.clip = shatterSound;
            audioSource.Play();

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Animator>().enabled = false;

            collision.GetComponent<Enemy>().die();

            Invoke("destroyObject", 2);
        }
    }

    private void destroyObject()
    {
        Destroy(this.gameObject);
    }
}
