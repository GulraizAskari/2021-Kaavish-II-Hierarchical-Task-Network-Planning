using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    float horizontal;
    public float rayDistanceX;

    public float rayDistanceY;

    float vertical;
    [SerializeField]
    float movSpeedHorizontal;
    [SerializeField]
    float movSpeedVertical;
    bool active;
    public int canMoveX;
    public int canMoveY;
    bool _y1;
    public Sprite right;
    public Sprite left;
    public Sprite up;
    public Sprite down;
    public Sprite gun;
    bool _y2;
    Transform transformX;
    Transform transformY;
    string playerDirection;
    string lastMoveDirection;
    bool playerMoving;
    Vector2 lastMove;
    GameObject p_UpperBody;
    GameObject p_legs;
    public float diagonalSpeed;
    GameObject Camera;
    bool playerDisplaced;
    Vector2 lastPosition;
    bool nextLoop;
    public Transform XU;
    public Transform XD;
    public Transform YL;
    public Transform YR;

    public float deltaX;

    public Rigidbody2D getRigidbody()
    {
        return myRigidbody;
    }

    public float getHorizontal()
    {
        return horizontal;
    }

    public void setHorizontal(float _horizontal)
    {
        horizontal = _horizontal;
    }

    public float getVertical()
    {
        return vertical;
    }

    public void setVertical(float _vertical)
    {
        vertical = _vertical;
    }

    public float getMovSpeedHorizontal()
    {
        return movSpeedHorizontal;
    }

    public float getMovSpeedVertical()
    {
        return movSpeedVertical;
    }
    public bool getActive()
    {
        return active;
    }

    public void setActive(bool _active)
    {
        active = _active;
    }

    public string getPlayerDirection()
    {
        return playerDirection;
    }

    public string getLastMoveDirection()
    {
        return lastMoveDirection;
    }

    public bool getPlayerMoving()
    {
        return playerMoving;
    }

    public void setPlayerMoving(bool _moving)
    {
        playerMoving = _moving;
    }

    public float getDiagonalSpeed()
    {
        return diagonalSpeed;
    }

    public bool getPlayerDisplaced()
    {
        return playerDisplaced;
    }
    void Start()
    {
        //Physics2D.queriesStartInColliders = true;
        p_UpperBody = GameObject.Find("p_upperBody");
        p_legs = GameObject.Find("p_legs");
        nextLoop = false;
        //Debug.Log(this.gameObject.transform.position);
        horizontal = vertical = 0;
        canMoveX = canMoveY = 1;
        playerDisplaced = true;
        transformX = XD;
        transformY = YR;
        active = true;
        if (GameObject.Find("UI") != null)
            GameObject.Find("UI").GetComponent<PlayerInventory>().SetImage(gun, "active1");
        lastMove.x = 1f;
        playerDirection = lastMoveDirection = "R";

        myRigidbody = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
        Camera = GameObject.Find("Main Camera");
    }


    void Update()
    {
        if (GetComponent<PlayerMeleeAttack>().meleeHit)
        {
            horizontal = vertical = 0;
            active = false;
        }
        else
            active = true;

        RayCast();
        playerDisplaced = false;
        if (nextLoop)
            lastPosition = this.gameObject.transform.position;
        ///        Debug.Log("nextLoop" + nextLoop);
        if (nextLoop == false)
        {
            nextLoop = true;
        }
        else
            nextLoop = false;
        playerMoving = false;

        if (active)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            //Debug.Log(horizontal);
        }
        if (vertical > 0)
        {
            if (GameObject.Find("UI") != null)
                GameObject.Find("UI").GetComponent<PlayerInventory>().SetImage(up, "picture");
        
            playerDirection = "U";
            playerMoving = true;
            lastMove = new Vector2(0f, vertical);

        }
        if (vertical < 0)
        {
            if (GameObject.Find("UI") != null)
                GameObject.Find("UI").GetComponent<PlayerInventory>().SetImage(down, "picture");
            playerDirection = "D";
            playerMoving = true;
            lastMove = new Vector2(0f, vertical);
        }
        if (horizontal > 0)
        {
            if (GameObject.Find("UI") != null)
                GameObject.Find("UI").GetComponent<PlayerInventory>().SetImage(right, "picture");
            playerDirection = "R";
            playerMoving = true;
            lastMove = new Vector2(horizontal, 0f);
        }
        if (horizontal < 0)
        {
            if (GameObject.Find("UI") != null)
                GameObject.Find("UI").GetComponent<PlayerInventory>().SetImage(left, "picture");
            playerDirection = "L";
            playerMoving = true;
            lastMove = new Vector2(horizontal, 0f);
        }

        lastMoveDirection = playerDirection;



        if (active)
        {

            if (Mathf.Abs(horizontal) == 1 && Mathf.Abs(vertical) == 1)
            {

                float _x = (Mathf.Round(horizontal * Time.deltaTime * 100 * diagonalSpeed) / 100);
                float _y = (Mathf.Round(vertical * Time.deltaTime * 100 * diagonalSpeed) / 100);

                transform.position = new Vector3(transform.position.x + _x * canMoveX, transform.position.y + _y * canMoveY, transform.position.z);
            }
            else
            {

                float _x = (Mathf.Round(horizontal * Time.deltaTime * 100 * movSpeedHorizontal) / 100);
                float _y = (Mathf.Round(vertical * Time.deltaTime * 100 * movSpeedVertical) / 100);

                transform.position = new Vector3(transform.position.x + _x * canMoveX, transform.position.y + _y * canMoveY, transform.position.z);

            }
            if (Mathf.Abs(vertical) == 1 || Mathf.Abs(horizontal) == 1)
            {
                if (FindObjectOfType<AudioManager>() != null)
                    FindObjectOfType<AudioManager>().Play("walking");
            }
        }

        if (active)
        {
            if (!playerMoving)
            {
                if (FindObjectOfType<AudioManager>() != null)
                    FindObjectOfType<AudioManager>().Stop("walking");
            }
        }
        if (Vector2.Distance(lastPosition, this.gameObject.transform.position) > 0.001f)
            playerDisplaced = true;
    }
    void RayCast()
    {
        Vector3 rayDirectionX = transform.up;
        
        if (!GetComponent<PlayerMeleeAttack>().meleeHit)
        {  
            if (lastMoveDirection == "R" || horizontal > 0)
            {
                transformX = XD;
            }
            else if (lastMoveDirection == "L" || horizontal < 0)
            {
                transformX = XU;
            }
        }
        else
        {
            if (GetComponent<PlayerMeleeAttack>().directionX == 1)
            {
                transformX = XD; 
            }
            else
            {
                transformX = XU;
            }
        }
        RaycastHit2D hitInfoX = Physics2D.Raycast(transformX.position, rayDirectionX, rayDistanceX);
    
        if (hitInfoX.collider != null && hitInfoX.collider.name != "p_upperBody" && hitInfoX.collider.name != "Player" && hitInfoX.collider.tag != "enemy")
        {
            Debug.Log("COLLIDER NAME: " + hitInfoX.collider.name);
            Debug.DrawLine(transformX.position, transformX.position + rayDirectionX * rayDistanceX, Color.red);
            canMoveX = 0;
        }
        else
        {
            canMoveX = 1;
            Debug.DrawLine(transformX.position, transformX.position + rayDirectionX * rayDistanceX, Color.green);
        }


        Vector3 rayDirectionY = -transform.right;
        
        if (!GetComponent<PlayerMeleeAttack>().meleeHit)
        {  
            if (lastMoveDirection == "U" || vertical > 0)
            {
                transformY = YL;
            }
            else if (lastMoveDirection == "D" || vertical < 0)
            {
                transformY = YR;
            }
        }
        else
        {
            if (GetComponent<PlayerMeleeAttack>().directionY == 1)
            {
                transformY = YL;
            }
            else
            {
                transformY = YR;
            }
        }
        
        RaycastHit2D hitInfoY = Physics2D.Raycast(transformY.position, rayDirectionY, rayDistanceY);
        RaycastHit2D hitInfoYOpposite = Physics2D.Raycast(new Vector2(transformY.position.x - rayDistanceY, transformY.position.y), -rayDirectionY, rayDistanceY);
       
        if (hitInfoY.collider != null && hitInfoY.collider.name != "p_upperBody" && hitInfoY.collider.name != "Player" && hitInfoY.collider.tag != "enemy")
        {
            Debug.DrawLine(transformY.position, hitInfoY.point, Color.red);
            _y1 = false;
        }
        else
        {
            _y1 = true;
            Debug.DrawLine(transformY.position, transformY.position + rayDirectionY * rayDistanceY, Color.green);
        }
        
        if (hitInfoYOpposite.collider != null && hitInfoYOpposite.collider.name != "p_upperBody" && hitInfoYOpposite.collider.name != "Player" && hitInfoY.collider.tag != "enemy")
        {
            Debug.DrawLine(new Vector2(transformY.position.x - rayDistanceY, transformY.position.y), hitInfoYOpposite.point, Color.blue);
            _y2 = false;
        }
        else
        {
            _y2 = true;
            Debug.DrawLine(new Vector2(transformY.position.x - rayDistanceY, transformY.position.y), new Vector3(transformY.position.x - rayDistanceY, transformY.position.y) - rayDirectionY * rayDistanceY, Color.green);
        }
        if (_y1 && _y2)
        {
            canMoveY = 1;
        }
        else
        {
            canMoveY = 0;
        }
        //Debug.Log("Y IS : " + canMoveY);
    }
    /*
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(this.gameObject.transform.position, new Vector3(0.25f, 0.25f, 0));
        }*/
}
