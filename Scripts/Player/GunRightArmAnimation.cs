using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRightArmAnimation : MonoBehaviour
{
    Animator anim;
    bool fire;
    bool exhaustion;
    float shotgunFireTimer;
    public float shotgunFirerate;
    public bool enemyFiring;
    public bool shootSound;
    public float reloadSoundTimer;
    float reloadSoundTime;
    void Start()
    {
        reloadSoundTimer = 0.1f;
        reloadSoundTime = 0;
        shootSound = false;
        enemyFiring = false;
        shotgunFireTimer = 0;
        exhaustion = false;
        fire = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.gameObject.transform.parent.name == "p_upperBody")
        {
            if (Input.GetMouseButtonDown(0) && !fire && !exhaustion && transform.parent.GetChild(2).GetComponent<GunFireAnimation>().bullets > 0)
            {
                if (FindObjectOfType<AudioManager>() != null)
                    FindObjectOfType<AudioManager>().Play("shoot");
                shootSound = true;
                anim.SetBool("fire", true);
                exhaustion = true;
            }
            if (shootSound)
            {
                reloadSoundTime += Time.deltaTime;
            }

            if (reloadSoundTime >= reloadSoundTimer)
            {
                
                shootSound = false;
                reloadSoundTime = 0;
                if (FindObjectOfType<AudioManager>() != null)
                    FindObjectOfType<AudioManager>().Play("reload");
            }
        }
        else if (this.gameObject.transform.parent.name == "e_upperBody")
        {
            if (enemyFiring && !fire && !exhaustion)
            {
                if (FindObjectOfType<AudioManager>() != null)
                    FindObjectOfType<AudioManager>().Play("shoot");
                anim.SetBool("fire", true);
                exhaustion = true;
                enemyFiring = false;
            }
        }
        if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !this.anim.IsInTransition(0))
        {
            fire = false;
            anim.SetBool("fire", false);
        }

        if (exhaustion)
        {
            shotgunFireTimer += Time.deltaTime;
            if (shotgunFireTimer >= shotgunFirerate)
            {
                exhaustion = false;
                shotgunFireTimer = 0;
            }
        }
    }
}
