using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField]
    GameObject m_player;
    [SerializeField]
    int m_detection_range;

    void Start()
    {
        m_detection_range = 10;
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up);

        // // If it hits something...
        // if (hit.collider != null)
        // {
        //     // Calculate the distance from the surface and the "error" relative
        //     // to the floating height.
        //     float distance = Mathf.Abs (hit.point.y - transform.position.y);
        //     float heightError = floatHeight - distance;

        //     // The force is proportional to the height error, but we remove a part of it
        //     // according to the object's speed.
        //     float force = liftForce * heightError - rb2D.velocity.y * damping;

        //     // Apply the force to the rigidbody.
        //     rb2D.AddForce (Vector3.up * force);
        // }
        DistanceSensor();
    }

    public bool DistanceSensor()
    {
        if (Vector2.Distance(this.gameObject.transform.position, m_player.transform.position) > m_detection_range)
        {
            // print("Not in Range");
            return false;
        }
        // print("In Range");
        return true;
    }

    public float PlayerEnemyDistance()
    {
        return Vector2.Distance(transform.position, m_player.transform.position);
    }
}