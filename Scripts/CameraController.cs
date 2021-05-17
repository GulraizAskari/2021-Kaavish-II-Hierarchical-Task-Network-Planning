using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Vector3 maxPos;
    Vector3 playerPos;
    float ScreenWidth;
    float ScreenHeight;
    public float CameraSpeed;
    Vector2 mPos1;
    Vector3 movePos;
    Vector3 diff;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        maxPos.y = 2.5f;
        maxPos.x = 2.5f;
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
        //CameraSpeed = 3f;
        mPos1 = default;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player");
            playerPos = player.transform.position;
        }
        if (InsideScreen())
        {
            //if (mousePosChanged())
            {
                movePos.y = (Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                movePos.x = (Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
                movePos.z = transform.position.z;

                diff.y = Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - playerPos.y) * 0.75f;
                diff.x = Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - playerPos.x) * 0.75f;
                diff.z = 0;

                if (Mathf.Abs(transform.position.x - playerPos.x) <= maxPos.x)
                {
                    if (movePos.x > playerPos.x)
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePos.x - diff.x, transform.position.y, transform.position.z), CameraSpeed * Time.deltaTime);
                    else
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePos.x + diff.x, transform.position.y, transform.position.z), CameraSpeed * Time.deltaTime);
                }
                else
                {
                    //if (transform.position.x > playerPos.x)
                      //  transform.position = new Vector3(playerPos.x + maxPos.x, transform.position.y, transform.position.z);
                   // else if (transform.position.x < playerPos.x)
                       // transform.position = new Vector3(playerPos.x - maxPos.x, transform.position.y, transform.position.z);
                }
                if (Mathf.Abs(transform.position.y - playerPos.y) <= maxPos.y)
                {
                    if (movePos.y > playerPos.y)
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, movePos.y - diff.y, transform.position.z), CameraSpeed * Time.deltaTime);
                    else
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, movePos.y + diff.y, transform.position.z), CameraSpeed * Time.deltaTime);
                }
                else
                {
                    if (transform.position.y > playerPos.y)
                        transform.position = new Vector3(transform.position.x, playerPos.y + maxPos.y, transform.position.z);
                    else if (transform.position.y < playerPos.y)
                        transform.position = new Vector3(transform.position.x, playerPos.y - maxPos.y, transform.position.z);
                }


            }
            /*else
            {
                if (player.GetComponent<PlayerMovement>().getPlayerDisplaced())
                    GetComponent<Rigidbody2D>().velocity = player.GetComponent<PlayerMovement>().myRigidbody.velocity;
                else
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }*/

        }
        else
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    private bool InsideScreen()
    {
        if (Input.mousePosition.y < ScreenHeight && Input.mousePosition.y >= 0)
            if (Input.mousePosition.x < ScreenWidth && Input.mousePosition.x >= 0)
                return true;
        return false;
    }
    private bool mousePosChanged()
    {

        Vector2 mPos2 = default;
        mPos2.x = Input.mousePosition.x;
        mPos2.y = Input.mousePosition.y;


        if (mPos1.Equals(mPos2))
        {
            return false;
        }
        else
        {
            mPos1 = mPos2;
            return true;
        }

    }
}
