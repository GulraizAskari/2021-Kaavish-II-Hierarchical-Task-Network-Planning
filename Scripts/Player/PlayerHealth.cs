using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public float currentHealth;
    public HealthBarUI healthBar;
    public float healthIncrease;
    bool firstBoundary;
    public GameObject deadBody;
    public bool immortal;
    public bool meleeDmgTaken;
    bool dead;
    bool secondBoundary;
    bool knockback;
    float timer;
    public int _x;
    public int _y;
    float _time;
    float _dis;
    float decel;
    private void Start() {
        timer = 0;
        dead = false;
        firstBoundary = true;
        secondBoundary = true;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update() {
        if (immortal)
            if (currentHealth <= 0) //hack while testing
            {
                currentHealth = maxHealth;
            }

        if (currentHealth >= 66.7f)
        {
            //healthIncBoundary = 3;
            //Debug.Log("Increasing health");
            if (firstBoundary)
                currentHealth += healthIncrease;
        }
        else if (currentHealth >= 33.3f && currentHealth < 66.7f)
        {
            firstBoundary = false;
            //secondBoundary = true;
            if (secondBoundary)
                currentHealth += healthIncrease;
        }
        else if (currentHealth >= 0 && currentHealth < 33.3f)
        {
            secondBoundary = false;
            currentHealth += healthIncrease;
        }
        
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !dead)
        {
            GameObject body = Instantiate(deadBody, new Vector3 (transform.GetChild(0).gameObject.transform.position.x, transform.GetChild(0).gameObject.transform.position.y - 0.08f, -0.1f), Quaternion.identity);
            //Time.timeScale = 0.002f;
            body.name = "Dead Player";
            GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            GameObject.Find("p_legs").GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            
            dead = true;
            GameObject.Find("p_upperBody").SetActive(false);
            GameObject.Find("p_legs").SetActive(false);
        }
        if (knockback)
        {
            timer += Time.deltaTime;
            if (timer >= _time)
            {
                timer = 0;
                knockback = false;
                meleeDmgTaken = false;
                GetComponent<PlayerAnimationController>().stopAnimation = false;
            }
            else
            {
                if (!transform.parent.gameObject.GetComponent<EnemyObstacleCollision>().obstacleCollision) 
                    transform.parent.gameObject.transform.position = new Vector3(transform.parent.gameObject.transform.position.x + _x * _dis, transform.parent.gameObject.transform.position.y + _y * _dis, transform.parent.gameObject.transform.position.z);
                _dis = _dis / decel;
            }
        }
    }

    public void TakeDmg(int dmg)
    {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
    }

    public void TakeMeleeDmg(int dmg)
    {
        if (!meleeDmgTaken)
        {
            currentHealth -= dmg;
            meleeDmgTaken = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "e_bullet")
        {
            TakeDmg(5);
        }
    }

    public void Knockback(float dis, int x, int y, float time, float deceleration)
    {
        if (!knockback)
        {
            knockback = true;
            _x = x;
            _y = y;
            _time = time; 
            _dis = dis;
            decel = deceleration;
        }
    }
}
