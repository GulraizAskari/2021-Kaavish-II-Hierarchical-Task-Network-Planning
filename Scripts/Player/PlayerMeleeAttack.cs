using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public bool meleeHit;
    Animator anim;
    public float stepDisplacmentX;
    float tempDisplacmentX;
    public float stepDisplacmentY;
    float tempDisplacmentY;
    public float decelValue;
    public int directionX;
    public int directionY;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public float posAdjust;
    Transform attackPos;
    Vector2 mousePosition;
    int deltaX;
    int deltaY;
    public int calcAngle;   
    public float knockbackDistance;
    public float knockbackTime;
    public float knockbackDeceleration;
    public bool dmgRegistered;
 
    // Start is called before the first frame update
    void Start()
    {
        dmgRegistered = false;
        //tempDisplacmentX = stepDisplacmentX;
        //tempDisplacmentY = stepDisplacmentY;
        deltaX = deltaY = 0;
        anim = transform.GetChild(5).gameObject.GetComponent<Animator>();
        attackPos = transform.GetChild(4).transform;
        meleeHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        attackPos = transform.GetChild(4).transform;
        //Debug.Log("displacement : " + tempDisplacmentX);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (calcAngle >= -22.5f && calcAngle <= 22.5f)
        {
            deltaX = 1;
            deltaY = 0;
        }
        else if (calcAngle > 22.5f && calcAngle <= 67.5f)
        {
            deltaX = 1;
            deltaY = 1;
        }
        else if (calcAngle > 67.5f && calcAngle <= 134.5f)
        {
            deltaX = 0;
            deltaY = 1;
        }
        else if (calcAngle > 134.5f && calcAngle <= 157.5f)
        {
            deltaX = -1;
            deltaY = 1;
        }
        else if (calcAngle > 157.5f && calcAngle <= 180f)
        {
            deltaX = -1;
            deltaY = 0;
        }
        else if (calcAngle > -180f && calcAngle <= -157.5f)
        {
            deltaX = -1;
            deltaY = 0;
        }
        else if (calcAngle > -157.5f && calcAngle <= -130f)
        {
            deltaX = -1;
            deltaY = -1;
        }
        else if (calcAngle > -130f && calcAngle <= -50f)
        {
            deltaX = 0;
            deltaY = -1;
        }
        else if (calcAngle > -50f && calcAngle < -22.55f)
        {
            deltaX = 1;
            deltaY = -1;
        }
            
        if (meleeHit)
        {

            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.14f && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.43f && (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerMelee_LB_Right") || anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerMelee_LB_Left") || anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerMelee_LB_Top") || anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerMelee_LB_Down")))
            {
                dmgRegistered = false;
            }
            else
            {
                dmgRegistered = true;
            }
            if (!dmgRegistered)
            {
                //dmgRegistered = true;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(new Vector3(attackPos.position.x + deltaX * posAdjust, attackPos.position.y + deltaY * posAdjust, attackPos.position.z), attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].transform.parent.gameObject.GetComponent<EnemyHealth>().TakeMeleeDmg(2);
                    enemiesToDamage[i].transform.parent.gameObject.GetComponent<EnemyHealth>().Knockback(knockbackDistance, deltaX, deltaY, knockbackTime, knockbackDeceleration);
                }
            }
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x + (tempDisplacmentX/stepDisplacmentX) * directionX * GetComponent<PlayerMovement>().canMoveX, this.gameObject.transform.position.y + (tempDisplacmentY/stepDisplacmentY) * directionY * GetComponent<PlayerMovement>().canMoveY);
            //if (tempDisplacment - decelValue > 0)
            tempDisplacmentX = tempDisplacmentX/decelValue;
            tempDisplacmentY = tempDisplacmentY/decelValue;
        }
        if (meleeHit && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0) && (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerMelee_LB_Right") || anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerMelee_LB_Left") || anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerMelee_LB_Top") || anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerMelee_LB_Down")))
        {
            meleeHit = false;
            if (directionY == -1)
                transform.GetChild(5).gameObject.GetComponent<SortingSprites>().SetOffset(transform.GetChild(5).gameObject.GetComponent<SortingSprites>().GetOffset() - 5);
            dmgRegistered = false;
            //tempDisplacmentX = stepDisplacmentX;
        }
        if (!meleeHit)
        {
           if (GameObject.Find("Crosshair").transform.position.x > transform.GetChild(4).gameObject.transform.position.x)
            {
                directionX = 1;
            }
            else
            {
                directionX = -1;
            }
            if (GameObject.Find("Crosshair").transform.position.y > transform.GetChild(4).gameObject.transform.position.y)
            {
                directionY = 1;
            }       
            else
            {
                directionY = -1;
            }
        }
        if (Input.GetMouseButtonDown(1) && !meleeHit)
        {
            //sortingSprite = transform.GetChild(5).gameObject.GetComponent<SpriteRenderer>().sortingOrder;
            if (directionY == -1)
                transform.GetChild(5).gameObject.GetComponent<SortingSprites>().SetOffset(transform.GetChild(5).gameObject.GetComponent<SortingSprites>().GetOffset() + 5);
            
            calcAngle = (int)Angle(transform.GetChild(4).transform.position, mousePosition);
       
            
            tempDisplacmentX = Mathf.Abs(transform.GetChild(4).gameObject.transform.position.x - GameObject.Find("Crosshair").transform.position.x);
            tempDisplacmentY = Mathf.Abs(transform.GetChild(4).gameObject.transform.position.y - GameObject.Find("Crosshair").transform.position.y);
            float totalDisp = tempDisplacmentY + tempDisplacmentX;
            tempDisplacmentX = tempDisplacmentX / totalDisp;
            tempDisplacmentY = tempDisplacmentY / totalDisp;

            meleeHit = true;
        }    
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
    private void OnDrawGizmosSelected() {
        attackPos = transform.GetChild(4).transform;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(attackPos.position.x + deltaX * posAdjust, attackPos.position.y + deltaY * posAdjust, attackPos.position.z), attackRange);
    }
}
