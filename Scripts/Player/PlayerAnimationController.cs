using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;
    Vector2 mousePosition;
    Vector2 playerPos;
    public static bool playerIdle;
    public static string viewing = "";
    static string LB_viewing = "";
    SpriteRenderer spR;
    GameObject Player;
    public bool idleAnimations;
    Animator p_UpperBody;
    Animator p_legs;
    static string direction = "";
    string LB_direction = "";
    public bool meleeHit;
    bool instantAngle;
    int _x;
    int _y;
    public bool stopAnimation;
    // Start is called before the first frame update
    void Start()
    {
        stopAnimation = false;
        _x = _y = 0;
        instantAngle = false;
        meleeHit = false;
        idleAnimations = false;
        anim = GetComponent<Animator>();
        spR = GetComponent<SpriteRenderer>();
        playerIdle = false;
        p_UpperBody = GameObject.Find("p_upperBody").GetComponent<Animator>();
        p_legs = GameObject.Find("p_legs").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Player = GameObject.Find("Player");
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos = new Vector2(transform.position.x, transform.position.y);
        //Debug.Log(Angle(playerPos, mousePosition));
        float calcAngle = Angle(playerPos, mousePosition);
        playerIdle = !Player.GetComponent<PlayerMovement>().getPlayerMoving();
        if (this.gameObject.name.Equals("p_upperBody"))
        {

            if (GetComponent<PlayerHealth>().meleeDmgTaken)
                if (transform.parent.GetComponent<PlayerMeleeAttack>().meleeHit)
                    stopAnimation = true;

            if (!transform.parent.GetComponent<PlayerMeleeAttack>().meleeHit && !stopAnimation)
                meleeHit = GetComponent<PlayerHealth>().meleeDmgTaken;
            else
                meleeHit = false;

            if (!playerIdle)
            {
                if (calcAngle >= -22.5f && calcAngle <= 22.5f)
                {
                    if (Player.GetComponent<PlayerMovement>().getHorizontal() > 0)
                    {
                        direction = "PlayerMoving_UB_Right";
                        LB_direction = "PlayerMoving_LB_Right";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getHorizontal() < 0)
                    {
                        direction = "PlayerMoving_UB_Right_R_2";
                        LB_direction = "PlayerMoving_LB_Right_R_2";
                    }
                    if (Player.GetComponent<PlayerMovement>().getVertical() < 0)
                    {
                        direction = "PlayerMoving_UB_DownRight";
                        LB_direction = "PlayerMoving_LB_DownRight";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getVertical() > 0)
                    {
                        direction = "PlayerMoving_UB_DownRight_R";
                        LB_direction = "PlayerMoving_LB_DownRight_R";
                    }

                }
                else if (calcAngle > 22.5f && calcAngle <= 67.5f)
                {
                    if (Player.GetComponent<PlayerMovement>().getHorizontal() > 0)
                    {
                        direction = "PlayerMoving_UB_Right_R";
                        LB_direction = "PlayerMoving_LB_RightRightTop";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getHorizontal() < 0)
                    {
                        direction = "PlayerMoving_UB_Right_R";
                        LB_direction = "PlayerMoving_LB_Right_R";
                    }
                    if (Player.GetComponent<PlayerMovement>().getVertical() > 0)
                    {
                        direction = "PlayerMoving_UB_TopRight";
                        LB_direction = "PlayerMoving_LB_TopRight";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getVertical() < 0)
                    {
                        direction = "PlayerMoving_UB_TopRight_R";
                        LB_direction = "PlayerMoving_LB_TopRight_R";
                    }
                }
                else if (calcAngle > 67.5f && calcAngle <= 134.5f)
                {
                    if (Player.GetComponent<PlayerMovement>().getVertical() > 0)
                    {
                        direction = "PlayerMoving_UB_Top";
                        LB_direction = "PlayerMoving_LB_Top";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getVertical() < 0)
                    {
                        direction = "PlayerMoving_UB_Top_R";
                        LB_direction = "PlayerMoving_LB_Top_R";
                    }
                    if (calcAngle > 67.5f && calcAngle <= 90f) //top right
                    {
                        if (Player.GetComponent<PlayerMovement>().getHorizontal() > 0)
                        {
                            direction = "PlayerMoving_UB_TopTopRight";///
                            LB_direction = "PlayerMoving_LB_TopTopRight";///
                        }
                        else if (Player.GetComponent<PlayerMovement>().getHorizontal() < 0)
                        {
                            direction = "PlayerMoving_UB_TopTopRight_R";///
                            LB_direction = "PlayerMoving_LB_TopTopRight_R";///
                        }
                    }
                    else                                       //top left
                    {
                        if (Player.GetComponent<PlayerMovement>().getHorizontal() < 0)
                        {
                            direction = "PlayerMoving_UB_TopTopLeft";///
                            LB_direction = "PlayerMoving_LB_TopTopLeft";///
                        }
                        else if (Player.GetComponent<PlayerMovement>().getHorizontal() > 0)
                        {
                            direction = "PlayerMoving_UB_TopTopLeft_R";///
                            LB_direction = "PlayerMoving_LB_TopTopLeft_R";///
                        }
                    }
                }
                else if (calcAngle > 134.5f && calcAngle <= 157.5f)
                {
                    if (Player.GetComponent<PlayerMovement>().getHorizontal() < 0)
                    {
                        direction = "PlayerMoving_UB_LeftLeftTop";
                        LB_direction = "PlayerMoving_LB_LeftLeftTop";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getHorizontal() > 0)
                    {
                        direction = "PlayerMoving_UB_Left_R";
                        LB_direction = "PlayerMoving_LB_Left_R";
                    }
                    if (Player.GetComponent<PlayerMovement>().getVertical() > 0)
                    {
                        direction = "PlayerMoving_UB_TopLeft";
                        LB_direction = "PlayerMoving_LB_TopLeft";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getVertical() < 0)
                    {
                        direction = "PlayerMoving_UB_TopLeft_R";
                        LB_direction = "PlayerMoving_LB_TopLeft_R";
                    }
                }
                else if (calcAngle > 157.5f && calcAngle <= 180f)
                {
                    if (Player.GetComponent<PlayerMovement>().getHorizontal() < 0)
                    {
                        direction = "PlayerMoving_UB_Left";
                        LB_direction = "PlayerMoving_LB_Left";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getHorizontal() > 0)
                    {
                        direction = "PlayerMoving_UB_Left_R_2";
                        LB_direction = "PlayerMoving_LB_Left_R_2";
                    }
                    if (Player.GetComponent<PlayerMovement>().getVertical() < 0)
                    {
                        direction = "PlayerMoving_UB_DownLeft";
                        LB_direction = "PlayerMoving_LB_DownLeft";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getVertical() > 0)
                    {
                        direction = "PlayerMoving_UB_DownLeft_R";
                        LB_direction = "PlayerMoving_LB_DownLeft_R";
                    }
                }
                else if (calcAngle > -180f && calcAngle <= -157.5f)
                {
                    if (Player.GetComponent<PlayerMovement>().getHorizontal() < 0)
                    {
                        direction = "PlayerMoving_UB_Left";
                        LB_direction = "PlayerMoving_LB_Left";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getHorizontal() > 0)
                    {
                        direction = "PlayerMoving_UB_Left_R_2";
                        LB_direction = "PlayerMoving_LB_Left_R_2";
                    }
                    if (Player.GetComponent<PlayerMovement>().getVertical() < 0)
                    {
                        direction = "PlayerMoving_UB_DownLeft";
                        LB_direction = "PlayerMoving_LB_DownLeft";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getVertical() > 0)
                    {
                        direction = "PlayerMoving_UB_DownLeft_R";
                        LB_direction = "PlayerMoving_LB_DownLeft_R";
                    }
                }
                else if (calcAngle > -157.5f && calcAngle <= -130f)
                {
                    if (Player.GetComponent<PlayerMovement>().getHorizontal() < 0)
                    {
                        direction = "PlayerMoving_UB_Left";
                        LB_direction = "PlayerMoving_LB_Left";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getHorizontal() > 0)
                    {
                        direction = "PlayerMoving_UB_Left_R_2";
                        LB_direction = "PlayerMoving_LB_Left_R_2";
                    }
                    if (Player.GetComponent<PlayerMovement>().getVertical() < 0)
                    {
                        direction = "PlayerMoving_UB_DownLeft";
                        LB_direction = "PlayerMoving_LB_DownLeft";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getVertical() > 0)
                    {
                        direction = "PlayerMoving_UB_DownLeft_R";
                        LB_direction = "PlayerMoving_LB_DownLeft_R";
                    }
                }
                else if (calcAngle > -130f && calcAngle <= -50f)
                {
                    if (Player.GetComponent<PlayerMovement>().getVertical() < 0)
                    {
                        direction = "PlayerMoving_UB_Down";
                        LB_direction = "PlayerMoving_LB_Down";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getVertical() > 0)
                    {
                        direction = "PlayerMoving_UB_Down_R";
                        LB_direction = "PlayerMoving_LB_Down_R";
                    }
                    if (calcAngle >= -90f && calcAngle <= -50f) //down right
                    {
                        if (Player.GetComponent<PlayerMovement>().getHorizontal() > 0)
                        {
                            direction = "PlayerMoving_UB_DownDownRight";
                            LB_direction = "PlayerMoving_LB_DownDownRight";
                        }
                        else if (Player.GetComponent<PlayerMovement>().getHorizontal() < 0)
                        {
                            direction = "PlayerMoving_UB_DownDownRight_R";
                            LB_direction = "PlayerMoving_LB_DownDownRight_R";
                        }
                    }
                    else                                        //down left
                    {
                        if (Player.GetComponent<PlayerMovement>().getHorizontal() < 0)
                        {
                            direction = "PlayerMoving_UB_DownDownLeft";
                            LB_direction = "PlayerMoving_LB_DownDownLeft";
                        }
                        else if (Player.GetComponent<PlayerMovement>().getHorizontal() > 0)
                        {
                            direction = "PlayerMoving_UB_DownDownLeft_R";
                            LB_direction = "PlayerMoving_LB_DownDownLeft_R";
                        }
                    }

                }
                else if (calcAngle > -50f && calcAngle < -22.55f)
                {
                    if (Player.GetComponent<PlayerMovement>().getHorizontal() > 0)
                    {
                        direction = "PlayerMoving_UB_Right";
                        LB_direction = "PlayerMoving_LB_Right";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getHorizontal() < 0)
                    {
                        direction = "PlayerMoving_UB_Right_R_2";
                        LB_direction = "PlayerMoving_LB_Right_R_2";
                    }
                    if (Player.GetComponent<PlayerMovement>().getVertical() < 0)
                    {
                        direction = "PlayerMoving_UB_DownRight";
                        LB_direction = "PlayerMoving_LB_DownRight";
                    }
                    else if (Player.GetComponent<PlayerMovement>().getVertical() > 0)
                    {
                        direction = "PlayerMoving_UB_DownRight_R";
                        LB_direction = "PlayerMoving_LB_DownRight_R";
                    }
                }
                if (!meleeHit)
                {
                    p_UpperBody.Play(direction);
                    GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
                    instantAngle = false;
                    p_legs.Play(LB_direction);
                }
                else
                {
                    if (!transform.parent.GetComponent<PlayerMeleeAttack>().meleeHit)
                    {
                        GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
                        if (!instantAngle)
                        {
                            _x = GetComponent<PlayerHealth>()._x;
                            _y = GetComponent<PlayerHealth>()._y;   
                            instantAngle = true;
                        }

                        if (_x == 1 && _y == 0)
                            p_legs.Play("PlayerDmgTaken_LB_Left");
                        else if (_x == 1 && _y == 1)
                            p_legs.Play("PlayerDmgTaken_LB_Left");
                        else if (_x == 1 && _y == -1)
                            p_legs.Play("PlayerDmgTaken_LB_Left");
                        else if (_x == 0 && _y == -1)
                            p_legs.Play("PlayerDmgTaken_LB_Top");
                        else if (_x == -1 && _y == -1)
                            p_legs.Play("PlayerDmgTaken_LB_Right");
                        else if (_x == -1 && _y == 0)
                            p_legs.Play("PlayerDmgTaken_LB_Right");
                        else if (_x == -1 && _y == 1)
                            p_legs.Play("PlayerDmgTaken_LB_Right");
                        else if (_x == 0 && _y == 1)
                            p_legs.Play("PlayerDmgTaken_LB_Down");
                    }
                }

            }
            else
            {
                if (!transform.parent.GetComponent<PlayerMeleeAttack>().meleeHit)
                {
                    if (calcAngle >= -22.5f && calcAngle <= 22.5f)
                        viewing = "PlayerIdle_lookingRight";
                    else if (calcAngle > 22.5f && calcAngle <= 67.5f)
                        viewing = "PlayerIdle_lookingTR";
                    else if (calcAngle > 67.5f && calcAngle <= 134.5f)
                        viewing = "PlayerIdle_lookingTop";
                    else if (calcAngle > 134.5f && calcAngle <= 157.5f)
                        viewing = "PlayerIdle_lookingTL";
                    else if (calcAngle > 157.5f && calcAngle <= 180f)
                        viewing = "PlayerIdle_lookingLeft";
                    else if (calcAngle > -180f && calcAngle <= -157.5f)
                        viewing = "PlayerIdle_lookingLeft";
                    else if (calcAngle > -157.5f && calcAngle <= -130f)
                        viewing = "PlayerIdle_lookingDL";
                    else if (calcAngle > -130f && calcAngle <= -50f)
                        viewing = "PlayerIdle_lookingDown";
                    else if (calcAngle > -50f && calcAngle < -22.55f)
                        viewing = "PlayerIdle_lookingDR";
                }
                if (!transform.parent.GetComponent<PlayerMeleeAttack>().meleeHit && !meleeHit)
                {
                    p_UpperBody.Play(viewing);
                    GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
                }
                else
                {
                    //p_UpperBody.Play("PlayerMelee_UB_Right");
                    GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
                }

                if (viewing.Equals("PlayerIdle_lookingRight") ||
                            viewing.Equals("PlayerIdle_lookingDR"))
                    LB_viewing = "PlayerIdle_LB_Right";
                else if (viewing.Equals("PlayerIdle_lookingLeft") ||
                         viewing.Equals("PlayerIdle_lookingDL"))
                    LB_viewing = "PlayerIdle_LB_Left";
                else if (viewing.Equals("PlayerIdle_lookingTop"))
                    LB_viewing = "PlayerIdle_LB_Top";
                else if (viewing.Equals("PlayerIdle_lookingDown"))
                    LB_viewing = "PlayerIdle_LB_Down";
                else if (viewing.Equals("PlayerIdle_lookingTR"))
                    LB_viewing = "PlayerIdle_LB_TR";
                else if (viewing.Equals("PlayerIdle_lookingTL"))
                    LB_viewing = "PlayerIdle_LB_TL";

                if (!transform.parent.GetComponent<PlayerMeleeAttack>().meleeHit)
                {
                    if (!meleeHit)
                        p_legs.Play(LB_viewing);
                }
                else
                {
                    meleeHit = false;
                    if (viewing == "PlayerIdle_lookingRight" || viewing == "PlayerIdle_lookingTR" || viewing == "PlayerIdle_lookingDR")
                        p_legs.Play("PlayerMelee_LB_Right");
                    else if (viewing == "PlayerIdle_lookingLeft" || viewing == "PlayerIdle_lookingTL" || viewing == "PlayerIdle_lookingDL")
                        p_legs.Play("PlayerMelee_LB_Left");
                    else if (viewing == "PlayerIdle_lookingTop")
                        p_legs.Play("PlayerMelee_LB_Top");
                    else if (viewing == "PlayerIdle_lookingDown")
                        p_legs.Play("PlayerMelee_LB_Down");
                
                }
                if (!meleeHit)
                {
                    if (!transform.parent.GetComponent<PlayerMeleeAttack>().meleeHit)
                        p_legs.Play(LB_viewing);
                    instantAngle = false;
                }
                else
                {
                    if (!transform.parent.GetComponent<PlayerMeleeAttack>().meleeHit)
                    {
                        if (!instantAngle)
                        {
                            _x = GetComponent<PlayerHealth>()._x;
                            _y = GetComponent<PlayerHealth>()._y;
                                
                            instantAngle = true;
                        }
                    
                        if (_x == 1 && _y == 0)
                            p_legs.Play("PlayerDmgTaken_LB_Left");
                        else if (_x == 1 && _y == 1)
                            p_legs.Play("PlayerDmgTaken_LB_Left");
                        else if (_x == 1 && _y == -1)
                            p_legs.Play("PlayerDmgTaken_LB_Left");
                        else if (_x == 0 && _y == -1)
                            p_legs.Play("PlayerDmgTaken_LB_Top");
                        else if (_x == -1 && _y == -1)
                            p_legs.Play("PlayerDmgTaken_LB_Right");
                        else if (_x == -1 && _y == 0)
                            p_legs.Play("PlayerDmgTaken_LB_Right");
                        else if (_x == -1 && _y == 1)
                            p_legs.Play("PlayerDmgTaken_LB_Right");
                        else if (_x == 0 && _y == 1)
                            p_legs.Play("PlayerDmgTaken_LB_Down");
                    }
                }
            }
        }

        if (this.gameObject.name.Equals("Gun"))
        {
            meleeHit = transform.parent.gameObject.GetComponent<PlayerHealth>().meleeDmgTaken;
            transform.localScale = new Vector3(1f, 1f, 1);
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 0f);
            float angle = Angle(this.gameObject.transform.position, mousePosition);

            anim.SetBool("L", false);
            anim.SetBool("D", false);
            anim.SetBool("R", false);
            anim.SetBool("U", false);
            //Debug.Log("|||||||" + angle);

            if ((playerIdle && viewing.Equals("PlayerIdle_lookingTop")) || (!playerIdle && (direction == "PlayerMoving_UB_Top" || direction == "PlayerMoving_UB_Top_R" || direction == "PlayerMoving_UB_TopTopRight" || direction == "PlayerMoving_UB_TopTopLeft_R" || direction == "PlayerMoving_UB_TopTopRight_R" || direction == "PlayerMoving_UB_TopTopLeft")))
            {
                if (viewing.Equals("PlayerIdle_lookingTop") || direction == "PlayerIdle_LookingTop")
                {
                    GetComponent<SortingSprites>().SetOffset(2);
                    //spR.sortingOrder = -2;
                }
                if (angle < 64.5f)
                    angle = 64.5f;
                else if (angle > 134.5)
                    angle = 134.5f;
                anim.SetBool("U", true);
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (int)angle - 90);
            }
            else if ((playerIdle && viewing.Equals("PlayerIdle_lookingDown")) || (!playerIdle && (direction == "PlayerMoving_UB_Down" || direction == "PlayerMoving_UB_Down_R" || direction == "PlayerMoving_UB_DownDownRight" || direction == "PlayerMoving_UB_DownDownLeft_R" || direction == "PlayerMoving_UB_DownDownRight_R" || direction == "PlayerMoving_UB_DownDownLeft")))
            {
                transform.localScale = new Vector3(1f, 1.5f, 1);
                anim.SetBool("D", true);
                GetComponent<SortingSprites>().SetOffset(-3);
                //spR.sortingOrder = 3;
                if (angle > -90)
                    transform.eulerAngles = new Vector3(transform.rotation.x + (int)angle * 1.1f + 50, transform.rotation.y, (int)angle + 100);
                else if (angle < -90 && angle > -115)
                {
                    angle = (-angle - 90) - 90;
                    transform.eulerAngles = new Vector3(transform.rotation.x + (int)angle * 1.1f + 50, transform.rotation.y, -(int)angle - 90);
                }
                else if (angle < -115)
                {
                    angle = -115;
                    angle = (-angle - 90) - 90;
                    transform.eulerAngles = new Vector3(transform.rotation.x + (int)angle * 1.1f + 50, transform.rotation.y, -(int)angle - 90);

                }
            }
            else
            {
                //Debug.Log("Viewing is: " + viewing);
                //Debug.Log("Direction is: " + direction);
                if ((playerIdle && (viewing.Equals("PlayerIdle_lookingRight") || viewing.Equals("PlayerIdle_lookingTR") || viewing.Equals("PlayerIdle_lookingDR"))) || (!playerIdle && (direction == "PlayerMoving_UB_Right_R" || direction == "PlayerMoving_UB_Right" || direction == "PlayerMoving_UB_Right_R_2" || direction == "PlayerMoving_UB_TopRight" || direction == "PlayerMoving_UB_DownRight_R" || direction == "PlayerMoving_UB_TopRight_R" || direction == "PlayerMoving_UB_DownRight")))
                {
                    if ((playerIdle && viewing.Equals("PlayerIdle_lookingTR")) || (!viewing.Equals("PlayerIdle_lookingDR") && direction != "PlayerMoving_UB_DownRight" && direction != "PlayerMoving_UB_Right_R_2" && direction != "PlayerMoving_UB_DownRight_R" || (!playerIdle && (direction == "PlayerMoving_UB_Right_R" || direction == "PlayerMoving_UB_TopRight_R"))))
                        GetComponent<SortingSprites>().SetOffset(3);  //spR.sortingOrder = -2;
                    else
                        GetComponent<SortingSprites>().SetOffset(-1);  //spR.sortingOrder = 1;

                    if (direction == "PlayerMoving_UB_Right" || (playerIdle && viewing.Equals("PlayerIdle_lookingRight")))
                        GetComponent<SortingSprites>().SetOffset(-1);  //spR.sortingOrder = 1;
                    if (((viewing.Equals("PlayerIdle_lookingTR") || viewing.Equals("PlayerIdle_lookingTop")) && playerIdle) || direction == "PlayerMoving_UB_TopRight")
                        GetComponent<SortingSprites>().SetOffset(3);  //spR.sortingOrder = -2;

                    anim.SetBool("R", true);
                    if (angle.Equals(0) || (angle > 0))
                        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (int)angle - (3 + (angle / 3)));

                    else if (angle < 0)
                        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (int)angle - (3 - (angle / 3)));
                }
                else if ((playerIdle && (viewing.Equals("PlayerIdle_lookingLeft") || viewing.Equals("PlayerIdle_lookingTL") || viewing.Equals("PlayerIdle_lookingDL"))) || (!playerIdle && (direction == "PlayerMoving_UB_Left" || direction == "PlayerMoving_UB_Left_R" || direction == "PlayerMoving_UB_Left_R_2" || direction == "PlayerMoving_UB_LeftLeftTop" || direction == "PlayerMoving_UB_TopLeft" || direction == "PlayerMoving_UB_DownLeft_R" || direction == "PlayerMoving_UB_TopLeft_R" || direction == "PlayerMoving_UB_DownLeft")))
                {
                    //if (!viewing.Equals("lookingDL"))
                    angle = 180 - angle;
                    //  else
                    //   angle = 180 + angle;
                    if (viewing.Equals("PlayerIdle_lookingTL") || direction == "PlayerMoving_UB_Left_R" || direction == "PlayerMoving_UB_LeftLeftTop" || direction == "PlayerMoving_UB_TopLeft" || direction == "PlayerMoving_UB_TopLeft_R")
                        GetComponent<SortingSprites>().SetOffset(3);  //spR.sortingOrder = -2;
                    else
                        GetComponent<SortingSprites>().SetOffset(-1);  // spR.sortingOrder = 1;
                    anim.SetBool("L", true);

                    if (angle < 180 && angle > 0)
                        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y - 180, (int)angle - (3 + (angle / 3)));
                    else
                        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y - 180, (int)angle - (5 + (360 - angle) / 3));

                }
            }
            if (transform.parent.transform.parent.GetComponent<PlayerMeleeAttack>().meleeHit || meleeHit) 
            {
                GetComponent<SpriteRenderer>().color = new Color (0,0,0,0);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color (255,255,255,255);
            }
        }
        else if (this.gameObject.name.Equals("p_rightArm") || this.gameObject.name.Equals("p_leftArm"))
        {
            meleeHit = transform.parent.gameObject.GetComponent<PlayerHealth>().meleeDmgTaken;
           
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 0f);
            if (this.gameObject.name.Equals("p_rightArm"))
                GetComponent<SortingSprites>().SetOffset(-2);  // spR.sortingOrder = 2;
            else
                GetComponent<SortingSprites>().SetOffset(3);  //spR.sortingOrder = -2;


            float angle = Angle(this.gameObject.transform.position, mousePosition);
            //Debug.Log("tHSI " + angle);

            anim.SetBool("DL", false);
            anim.SetBool("L", false);
            anim.SetBool("D", false);
            anim.SetBool("R", false);
            anim.SetBool("DR", false);
            anim.SetBool("U", false);
            anim.SetBool("TR", false);
            anim.SetBool("TL", false);

            // if (playerIdle)
            {
                if ((viewing.Equals("PlayerIdle_lookingRight") && playerIdle) || ((direction == "PlayerMoving_UB_Right_R_2" || direction == "PlayerMoving_UB_Right" || direction == "PlayerMoving_UB_DownRight_R" || direction == "PlayerMoving_UB_DownRight") && !playerIdle))
                {
                    anim.SetBool("R", true);
                    transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (int)angle);
                }
                else if (viewing.Equals("PlayerIdle_lookingDR") && playerIdle)
                {
                    anim.SetBool("DR", true);
                    transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (int)angle);
                }
                else if ((viewing.Equals("PlayerIdle_lookingLeft") && playerIdle) || ((direction == "PlayerMoving_UB_Left_R_2" || direction == "PlayerMoving_UB_Left" || direction == "PlayerMoving_UB_DownLeft_R" || direction == "PlayerMoving_UB_DownLeft") && !playerIdle))
                {
                    anim.SetBool("L", true);
                    transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (int)angle + 180f);
                }
                else if (viewing.Equals("PlayerIdle_lookingDL") && playerIdle)
                {
                    anim.SetBool("DL", true);
                    transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (int)angle + 180);
                }
                else if ((viewing.Equals("PlayerIdle_lookingTop") && playerIdle) || ((direction == "PlayerMoving_UB_Top" || direction == "PlayerMoving_UB_Top_R" || direction == "PlayerMoving_UB_TopTopLeft" || direction == "PlayerMoving_UB_TopTopLeft_R" || direction == "PlayerMoving_UB_TopTopRight" || direction == "PlayerMoving_UB_TopTopRight_R") && !playerIdle))
                {
                    anim.SetBool("U", true);
                }
                else if ((viewing.Equals("PlayerIdle_lookingTL") && playerIdle) || ((direction == "PlayerMoving_UB_LeftLeftTop" || direction == "PlayerMoving_UB_Left_R" || direction == "PlayerMoving_UB_TopLeft" || direction == "PlayerMoving_UB_TopLeft_R") && !playerIdle))
                {
                    anim.SetBool("TL", true);
                    transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (int)angle - 180f);
                }
                else if ((viewing.Equals("PlayerIdle_lookingTR") && playerIdle) || ((direction == "PlayerMoving_UB_Right_R" || direction == "PlayerMoving_UB_TopRight" || direction == "PlayerMoving_UB_TopRight_R") && !playerIdle))
                {
                    anim.SetBool("TR", true);
                    transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (int)angle);
                }
                else if ((viewing.Equals("PlayerIdle_lookingDown") && playerIdle) || ((direction == "PlayerMoving_UB_Down" || direction == "PlayerMoving_UB_DownDownRight" || direction == "PlayerMoving_UB_DownDownRight_R" || direction == "PlayerMoving_UB_DownDownLeft" || direction == "PlayerMoving_UB_DownDownLeft_R" || direction == "PlayerMoving_UB_Down_R") && !playerIdle))
                {
                    anim.SetBool("D", true);
                    if (this.gameObject.name.Equals("p_leftArm"))
                        GetComponent<SortingSprites>().SetOffset(-3);  //spR.sortingOrder = 3;

                    if (this.gameObject.name.Equals("p_rightArm"))
                    {
                        if (angle > -87)
                            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (int)angle + 100);
                        else
                            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, -87 + 100);
                    }
                    else
                    {
                        if (angle > -115)
                            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, -(int)angle - 75);
                        else
                            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, -(int)angle - 70);
                    }
                }
            }
            /*
            else
            {
                if (direction == "PlayerMoving_UB_Right_R")
                {
                    anim.SetBool("TR", true);
                    transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, (int)angle);
                }
            }*/
            if (transform.parent.transform.parent.GetComponent<PlayerMeleeAttack>().meleeHit || meleeHit)
            {
                GetComponent<SpriteRenderer>().color = new Color (0,0,0,0);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color (255,255,255,255);
            }
        }
        //direction = "";
        LB_direction = "";
        //viewing = "";

    }

    private float Angle(Vector2 p_Pos, Vector2 m_Pos)
    {
        float horizontal = m_Pos.x - p_Pos.x;
        float vertical = m_Pos.y - p_Pos.y;
        float angle = Mathf.Atan2(vertical, horizontal);
        //Debug.Log("player horizontal is: " + horizontal);
        //Debug.Log("player vertical is: " + vertical);

        return angle * Mathf.Rad2Deg;
    }
}
