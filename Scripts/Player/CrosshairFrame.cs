using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairFrame : MonoBehaviour
{
    Vector2 TLOffset; //top left offset
    Vector2 TROffset; //top right
    Vector2 DLOffset; //bottom left
    Vector2 DROffset; //bottom right
    float enlargingFactor;
    float shrinkingTime;
    float counter;
    float enlargingUnit;
    float shrinkingUnit;
    float shotgunFirerate;
    float shotgunFirerateTimer;
    bool shot;
    float shotgunEnlargingFactor;

    // Start is called before the first frame update
    void Start()
    {
        shotgunEnlargingFactor = 2;
        shot = false;
        shotgunFirerate = 1;
        shotgunFirerateTimer = 0;
        TLOffset = new Vector2(-0.16f, 0.16f);
        TROffset = new Vector2(0, 0.16f);
        DLOffset = new Vector2(-0.16f, 0);
        DROffset = new Vector2(0, 0);
        enlargingFactor = 0;
        counter = 0;
        shrinkingTime = 0.1f;
        enlargingUnit = 0.032f * shotgunEnlargingFactor;
        shrinkingUnit = 0.016f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name.Equals("CrosshairFrame_TL"))
        {
            //Vector3 myV = new Vector3(Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x * 10) / 10, Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y * 10) / 10, -1);
            Vector3 myV = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);

            transform.position = new Vector3(myV.x + TLOffset.x - enlargingFactor, myV.y + TLOffset.y + enlargingFactor, -1);

        }
        if (this.gameObject.name.Equals("CrosshairFrame_TR"))
        {

            //Vector3 myV = new Vector3(Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x * 10) / 10, Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y * 10) / 10, -1);
            Vector3 myV = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);

            transform.position = new Vector3(myV.x + TROffset.x + enlargingFactor, myV.y + TROffset.y + enlargingFactor, -1);
        }
        if (this.gameObject.name.Equals("CrosshairFrame_DL"))
        {

            //Vector3 myV = new Vector3(Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x * 10) / 10, Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y * 10) / 10, -1);
            Vector3 myV = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);

            transform.position = new Vector3(myV.x + DLOffset.x - enlargingFactor, myV.y + DLOffset.y - enlargingFactor, -1);
        }
        if (this.gameObject.name.Equals("CrosshairFrame_DR"))
        {
            //Vector3 myV = new Vector3(Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x * 10) / 10, Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y * 10) / 10, -1);
            Vector3 myV = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);

            transform.position = new Vector3(myV.x + DROffset.x + enlargingFactor, myV.y + DROffset.y - enlargingFactor, -1);
        }
        if (Shoot())
        {
            if (enlargingFactor < 0.16f)
                enlargingFactor += enlargingUnit;

            if (GetComponent<SpriteRenderer>().color.a > 0.6f)
            {
                Color temp = GetComponent<SpriteRenderer>().color;
                temp.a -= 0.1f;
                GetComponent<SpriteRenderer>().color = temp;
            }
        }
        counter += Time.deltaTime;

        if (counter >= shrinkingTime)
        {
            if (enlargingFactor > 0)
            {
                enlargingFactor -= shrinkingUnit;
            }
            if (GetComponent<SpriteRenderer>().color.a < 1)
            {
                Color temp = GetComponent<SpriteRenderer>().color;
                temp.a += 0.05f;
                GetComponent<SpriteRenderer>().color = temp;
            }
            counter = 0;
        }

    }

    //For later: need to make the reticle shake when player health is critical

    private bool Shoot()
    {
        if (!shot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                shot = true;
                return true;
            }
        }
        else
        {
            shotgunFirerateTimer += Time.deltaTime;
            if (shotgunFirerateTimer >= shotgunFirerate)
            {
                shot = false;
                shotgunFirerateTimer = 0;
            }
        }
        return false;
    }
}
