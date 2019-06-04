using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    private int playerHP = 3;

    private Image life1, life2, life3;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = 3;
        life1 = GameObject.Find("Health1").GetComponent<Image>();
        life2 = GameObject.Find("Health2").GetComponent<Image>();
        life3 = GameObject.Find("Health3").GetComponent<Image>();
        updateLifes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseHP()
    {
        this.playerHP--;
        if (this.playerHP < 0) this.playerHP = 0;
        updateLifes();
    }

    public void increaseHP()
    {
        this.playerHP++;
        if (this.playerHP > 3) this.playerHP = 3;
        updateLifes();
    }


    public bool playerDead()
    {
        return playerHP <= 0;
    }

    public void updateLifes()
    {
        life1.enabled = false;
        life2.enabled = false;
        life3.enabled = false;
        if (playerHP > 0) life1.enabled = true;
        if (playerHP > 1) life2.enabled = true;
        if (playerHP > 2) life3.enabled = true;            
    }
}
