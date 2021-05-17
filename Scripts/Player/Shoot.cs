using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform RL_Outlet;
    public Transform U_Outlet;
    public Transform D_Outlet;
    public GameObject Bullet;
    Transform pos;
    Animator anim;
    GameObject Crosshair;
    public bool fired;
    float shotgunFireTimer;
    public float shotgunFirerate;
    GameObject Gun;
    public bool exhaustion;
    float anotherRoundTimer;
    float rotation;
    public bool enemyFiring;
    float shootDelay;
    float shootDelayTimer;
    string g_name;
    int bulletNum;
    public bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        shoot = false;
        bulletNum = 0;
        g_name = this.gameObject.transform.parent.gameObject.name;
        shootDelayTimer = 0;
        shootDelay = 0.1f;
        exhaustion = false;
        shotgunFireTimer = 0;
        enemyFiring = false;
        anotherRoundTimer = 0;
        anim = GetComponent<Animator>();
        Gun = this.gameObject;
        fired = false;
        Crosshair = GameObject.Find("Crosshair");
    }

    // Update is called once per frame
    void Update()
    {
        if (g_name == "p_upperBody")
        {
            if (shoot)
            {
                Debug.Log("BULLET CREATED!!!!: ");
                CreateBullet(Crosshair.transform.position);
                shoot = false;
                fired = true;
            }
        }
        if (anim.GetBool("R") || anim.GetBool("L"))
        {
            pos = RL_Outlet;
        }
        else if (anim.GetBool("U"))
        {
            pos = U_Outlet;
        }
        else if (anim.GetBool("D"))
        {
            pos = D_Outlet;
        }

        
        if (g_name == "e_upperBody")
        {
            if (enemyFiring && !fired)
            {
                if (shootDelayTimer >= shootDelay)
                {
                    CreateBullet(GetComponent<EnemyAnimationController>().Player.transform.position);
                    fired = true;
                    enemyFiring = false;
                    shootDelayTimer = 0;
                    Debug.Log("SHOT");
                    this.gameObject.transform.parent.gameObject.transform.parent.GetComponent<Brave>().Bullets -= 1;
                }
                else
                {
                    shootDelayTimer += Time.deltaTime;
                }
            }
        }

        //Debug.Log("Fired    "+ fired);
        if (fired && !exhaustion)
        {
            Debug.Log("FIRING SECOND SHOT");
            anotherRoundTimer += Time.deltaTime;
            if (anotherRoundTimer >= 0.05f)
            {
                if (g_name == "p_upperBody")
                    CreateBullet(Crosshair.transform.position);
                if (g_name == "e_upperBody")
                {
                    CreateBullet(GetComponent<EnemyAnimationController>().Player.transform.position);
                    exhaustion = true;
                }
                fired = false;
                anotherRoundTimer = 0;
            }

        }

        if (g_name == "e_upperBody")
        {
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
    void CreateBullet(Vector3 Pos)
    {
        bulletNum += 1;
        //Debug.Log("BULLET CREATED!!!!~~~~~~~~~~~~~~~~~~~~~~~~~~~~ : " + bulletNum);
            
        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
                rotation = Angle(Gun.transform.position, Pos) + 7.5f;
            else
                rotation = Angle(Gun.transform.position, Pos) - 15f;
            GameObject bullet = Instantiate(Bullet, pos.position, Quaternion.identity);
            if (g_name == "e_upperBody")
                bullet.name = i.ToString() + " enemy";
            else if (g_name == "p_upperBody")
                bullet.name = i.ToString();
            bullet.transform.eulerAngles = new Vector3(bullet.transform.rotation.x, bullet.transform.rotation.y, rotation);
            //Debug.Log(bullet.transform.eulerAngles);
        }
        for (int i = 2; i < 4; i++)
        {
            int deg;
            if (i == 2)
                deg = 20;
            else
                deg = -20;
            rotation = Angle(Gun.transform.position, Pos) + deg;
            GameObject bullet = Instantiate(Bullet, pos.position, Quaternion.identity);
            if (g_name == "e_upperBody")
                bullet.name = i.ToString() + " enemy";
            else if (g_name == "p_upperBody")
                bullet.name = i.ToString();
            bullet.transform.eulerAngles = new Vector3(bullet.transform.rotation.x, bullet.transform.rotation.y, rotation);
            //Debug.Log(Angle(Gun.transform.position, Pos));
        }
        if (g_name == "e_upperBody")
        {
            if (GameObject.Find("p_upperBody") != null)
                rotation = Angle(transform.parent.transform.position, GameObject.Find("p_upperBody").transform.position);
        }
        else if (g_name == "p_upperBody")
            rotation = Angle(transform.parent.transform.position, Crosshair.transform.position);
        
        GameObject _bullet = Instantiate(Bullet, pos.position, Quaternion.identity);
        if (g_name == "e_upperBody")
            _bullet.name = "4 enemy";
        else if (g_name == "p_upperBody")
            _bullet.name = "4";
        _bullet.transform.eulerAngles = new Vector3(_bullet.transform.rotation.x, _bullet.transform.rotation.y, rotation);
            
    }
    private float Angle(Vector2 p_Pos, Vector2 m_Pos)
    {
        float horizontal = m_Pos.x - p_Pos.x;
        float vertical = m_Pos.y - p_Pos.y;
        float angle = Mathf.Atan2(vertical, horizontal);
        return angle * Mathf.Rad2Deg;
    }
}
