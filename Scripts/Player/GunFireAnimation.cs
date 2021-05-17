using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireAnimation : MonoBehaviour
{
    Animator anim;
    bool fire;
    bool exhaustion;
    float shotgunFireTimer;
    public bool startFireAnim;
    public float shotgunFirerate;
    public int bullets;
    //string lastDirection;
    //string newDirection;
    void Start()
    {
        startFireAnim = false;
        shotgunFireTimer = 0;
        //lastDirection = "";
        //newDirection = "";
        exhaustion = false;
        fire = false;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //Debug.Log(this.transform.rotation.eulerAngles.y);

        if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !this.anim.IsInTransition(0) && fire)
        {
            fire = false;
            anim.SetBool("fire", false);
        }
    
        if (this.transform.parent.transform.parent.name.Contains("Player"))
        {
            if (Input.GetMouseButtonDown(0) && bullets > 0)
            {
                if (!fire && !exhaustion && !transform.parent.transform.parent.GetComponent<PlayerMeleeAttack>().meleeHit)
                {
                    bullets -= 1;
                    GetComponent<Shoot>().shoot = true;
                    exhaustion = true;
                    fire = true;
                    anim.SetBool("fire", true);
                }
            }
        }
        else
        {
            if (startFireAnim)
            {
                if (!fire && !exhaustion)
                {
                    exhaustion = true;
                    fire = true;
                    
                    anim.SetBool("fire", true);
                    startFireAnim = false;
                }
            }
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
        if (this.transform.rotation.eulerAngles.z >= 16 && this.transform.rotation.eulerAngles.z < 43 && this.transform.rotation.eulerAngles.y == 0)
        {
            if (!this.anim.IsInTransition(0))
            {
                anim.SetBool("rightTop", true);
                anim.SetBool("rightDown", false);
                anim.SetBool("leftTop", false);
                anim.SetBool("leftDown", false);
                anim.SetBool("downLeft", false);
                anim.SetBool("downRight", false);
                //lastDirection = "rightTop";
            }
        }
        else if (this.transform.rotation.eulerAngles.z <= 339.4f && this.transform.rotation.eulerAngles.z > 295 && this.transform.rotation.eulerAngles.y <= 1)
        {
            if (!this.anim.IsInTransition(0))
            {
                anim.SetBool("rightTop", false);
                anim.SetBool("rightDown", true);
                anim.SetBool("leftTop", false);
                anim.SetBool("leftDown", false);
                anim.SetBool("downLeft", false);
                anim.SetBool("downRight", false);
                //lastDirection = "rightDown";
            }
        }
        else if (this.transform.rotation.eulerAngles.z >= 14f && this.transform.rotation.eulerAngles.z < 33 && this.transform.rotation.eulerAngles.y >= 10)
        {
            if (!this.anim.IsInTransition(0))
            {
                anim.SetBool("rightTop", false);
                anim.SetBool("rightDown", false);
                anim.SetBool("leftTop", true);
                anim.SetBool("leftDown", false);
                anim.SetBool("downLeft", false);
                anim.SetBool("downRight", false);
                //lastDirection = "leftTop";
            }
        }
        else if (this.transform.rotation.eulerAngles.z <= 340.6f && this.transform.rotation.eulerAngles.z > 288 && this.transform.rotation.eulerAngles.y >= 10)
        {
            if (!this.anim.IsInTransition(0))
            {
                anim.SetBool("rightTop", false);
                anim.SetBool("rightDown", false);
                anim.SetBool("leftTop", false);
                anim.SetBool("leftDown", true);
                anim.SetBool("downLeft", false);
                anim.SetBool("downRight", false);
                //lastDirection = "leftDown";
            }
        }
        else if (this.transform.rotation.eulerAngles.z <= 350f && this.transform.rotation.eulerAngles.z >= 335)
        {
            if (!this.anim.IsInTransition(0))
            {
                anim.SetBool("rightTop", false);
                anim.SetBool("rightDown", false);
                anim.SetBool("leftTop", false);
                anim.SetBool("leftDown", false);
                anim.SetBool("downLeft", true);
                anim.SetBool("downRight", false);
                //lastDirection = "downLeft";
            }
        }
        else if (this.transform.rotation.eulerAngles.z <= 66f && this.transform.rotation.eulerAngles.z > 20)
        {
            if (!this.anim.IsInTransition(0))
            {
                anim.SetBool("rightTop", false);
                anim.SetBool("rightDown", false);
                anim.SetBool("leftTop", false);
                anim.SetBool("leftDown", false);
                anim.SetBool("downLeft", false);
                anim.SetBool("downRight", true);
                //lastDirection = "downRight";
            }
        }
        else
        {
            if (!this.anim.IsInTransition(0))
            {
                anim.SetBool("rightTop", false);
                anim.SetBool("rightDown", false);
                anim.SetBool("leftTop", false);
                anim.SetBool("leftDown", false);
                anim.SetBool("downLeft", false);
                anim.SetBool("downRight", false);
                /*if (anim.GetBool("R"))
                {
                    lastDirection = "right";
                }
                else if (anim.GetBool("L"))
                {
                    lastDirection = "left";
                }
                else if (anim.GetBool("U"))
                {
                    lastDirection = "up";
                }
                else if (anim.GetBool("D"))
                {
                    lastDirection = "down";
                }*/
            }
        }

        /*if (newDirection == lastDirection)
        {
            //Debug.Log("Same Direction");
        }
        else
        {
            //Debug.Log("Direction chnaged from: " + lastDirection);
            newDirection = lastDirection;
            fire = false;
            anim.SetBool("fire", false);
        }*/
    }
}
