using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField]
    Vector2 m_speeds;

    void Start() {
        m_speeds = new Vector2(5.0f, 5.0f);
    }

    // Update is called once per frame
    void Update() {
        PlayerMovement();
    }

    void PlayerMovement() {
        if (Input.GetKey(KeyCode.D)) {
            transform.position += new Vector3(1 * m_speeds.x * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A)) {
            transform.position -= new Vector3(1 * m_speeds.x * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.W)) {
            transform.position += new Vector3(0, 1 * m_speeds.y * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.S)) {
            transform.position -= new Vector3(0, 1 * m_speeds.y * Time.deltaTime, 0);
        }
    }
}