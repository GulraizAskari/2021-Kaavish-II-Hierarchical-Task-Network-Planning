using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Vector3 myV = new Vector3(Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x * 10) / 10, Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y * 10) / 10, -1);
        Vector3 myV = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);

        transform.position = myV;
    }
}
