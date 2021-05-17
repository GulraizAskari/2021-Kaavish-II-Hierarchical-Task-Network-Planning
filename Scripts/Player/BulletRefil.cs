using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRefil : MonoBehaviour
{
    public GameObject newTarget;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("can get buulllts");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("ca13123131232132311321s");
                if (newTarget != null)
                    newTarget.SetActive(true);
                other.gameObject.transform.GetChild(4).transform.GetChild(2).GetComponent<GunFireAnimation>().bullets = 10;
            }
        
        }
    }
}
