using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPickup : MonoBehaviour
{

    public int spawnRate = 30;

    private LifeManager lifeManager;

    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        this.lifeManager = GameObject.FindObjectOfType<LifeManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            lifeManager.increaseHP();
            spriteRenderer.enabled = false;
            collider.enabled = false;
            Invoke("resetPickup", spawnRate);
        }
    }

    private void resetPickup()
    {
        spriteRenderer.enabled = true;
        collider.enabled = true;
    }
}
