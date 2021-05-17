using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun_bullet : MonoBehaviour
{

    GameObject Crosshair;
    Rigidbody2D myRb;
    public float bulletSpeed;
    float fireSpread;
    float destroyTime;
    float aliveFor;
    int spreadRateInverse;
    
    // Start is called before the first frame update
    void Start()
    {
        spreadRateInverse = 32;
        aliveFor = 0;
        destroyTime = 0.4f;
        if (this.gameObject.name.Contains("enemy"))
            Crosshair = GameObject.Find("Player");
        else
            Crosshair = GameObject.Find("Crosshair");
        bulletSpeed = bulletSpeed * 100;

        myRb = GetComponent<Rigidbody2D>();
        Vector2 originalPos = this.gameObject.transform.position;
        if (this.gameObject.name.Contains("1"))
        {
            this.gameObject.name = "1";
        }
        if (this.gameObject.name.Contains("2"))
        {
            this.gameObject.name = "-3";
        }
        else if (this.gameObject.name.Contains("0"))
        {
            this.gameObject.name = "-1";
        }
        else if (this.gameObject.name.Contains("3"))
        {
            this.gameObject.name = "3";
        }
        else if (this.gameObject.name.Contains("4"))
        {
            this.gameObject.name = "0";
        }
        Direction();
        myRb.velocity = new Vector2(this.gameObject.transform.position.x - originalPos.x, this.gameObject.transform.position.y - originalPos.y) * bulletSpeed * Time.deltaTime;
        //Debug.Log(fireSpread);
    }

    void Direction()
    {
        if (Mathf.Abs(this.gameObject.transform.position.x - Crosshair.transform.position.x) > (Mathf.Abs(this.gameObject.transform.position.y - Crosshair.transform.position.y)))
        {
            if (this.gameObject.transform.position.x < Crosshair.transform.position.x)
            {
                fireSpread = 1 / Mathf.Abs(Crosshair.transform.position.x - this.transform.position.x) * spreadRateInverse;//8f;
                this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector3(Crosshair.transform.position.x, Crosshair.transform.position.y - (int.Parse(this.gameObject.name) / fireSpread), Crosshair.transform.position.z), 1 * Time.deltaTime);
            }
            else if (this.gameObject.transform.position.x > Crosshair.transform.position.x)
            {
                fireSpread = 1 / Mathf.Abs(Crosshair.transform.position.x - this.transform.position.x) * spreadRateInverse;//8f;
                this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector3(Crosshair.transform.position.x, Crosshair.transform.position.y + (int.Parse(this.gameObject.name) / fireSpread), Crosshair.transform.position.z), 1 * Time.deltaTime);
            }
        }
        else
        {
            if (this.gameObject.transform.position.y < Crosshair.transform.position.y)
            {
                fireSpread = 1 / Mathf.Abs(Crosshair.transform.position.y - this.transform.position.y) * spreadRateInverse;//8f;
                this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector3(Crosshair.transform.position.x + (int.Parse(this.gameObject.name) / fireSpread), Crosshair.transform.position.y, Crosshair.transform.position.z), 1 * Time.deltaTime);
            }
            else
            {
                fireSpread = 1 / Mathf.Abs(Crosshair.transform.position.y - this.transform.position.y) * spreadRateInverse;//8f;
                this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector3(Crosshair.transform.position.x - (int.Parse(this.gameObject.name) / fireSpread), Crosshair.transform.position.y, Crosshair.transform.position.z), 1 * Time.deltaTime);
            }
        }
    }

    void Update()
    {
        aliveFor += Time.deltaTime;
        if (aliveFor >= destroyTime)
        {
            Destroy(this.gameObject);
        }
    }
}
