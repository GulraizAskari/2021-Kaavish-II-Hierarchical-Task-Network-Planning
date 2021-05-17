using System.Collections.Generic;
using UnityEngine;

public class AgentWorldState : MonoBehaviour
{
    [SerializeField] Ranges m_agent_range;
    Vector3 m_move_location;
    int m_ammo;
    bool m_melee;
    int m_ammo_capacity;
    /*
    [SerializeField] int m_agent_health;
    [SerializeField] bool m_have_melee_weapon;
    */
    public List<KeyValuePair<string, object>> m_current_world_state = new List<KeyValuePair<string, object>>();
    Sensor m_sensor;
    public enum Ranges
    {
        melee_range,
        shoot_range,
        view_range,
        out_of_range
    }
    //Player player;
    //List<string> ws_range_list = new List<string> ();

    void Awake()
    {
        m_sensor = GetComponent<Sensor>();
        m_ammo_capacity = 30;
        m_ammo = m_ammo_capacity * 4;
        // add types of range in ws_range_list - melee_range, shoot_range, view_range, out_of_range etc.
        // world states

        /*
        m_agent_health = 10;
        m_ammo_capacity = 0;
        m_have_melee_weapon = false;
        */
        m_current_world_state.Add(new KeyValuePair<string, object>("PlayerFound", false));
        m_current_world_state.Add(new KeyValuePair<string, object>("HaveAmmo", false));
        m_agent_range = Ranges.out_of_range;
    }

    private void Update()
    {
        SetRange();
    }

    public void SetWorldState(List<KeyValuePair<string, object>> new_world_state)
    {
        // need this to feed into the planner
        // exporting all world state info
        //List<object> _worldState = new List<object>();
        // _worldState.Add(m_agent_range);
        // _worldState.Add(m_agent_health);
        // _worldState.Add(m_ammo_capacity);
        // _worldState.Add(m_have_melee_weapon);
        m_current_world_state = new_world_state;
        //return _worldState;
    }

    void SetRange()
    {
        if (m_sensor.DistanceSensor())
        {                // if detecting player using distanceSensor
            if (m_sensor.PlayerEnemyDistance() >= 7 && m_sensor.PlayerEnemyDistance() < 10)
            {    // defining player enemy view range
                //print("View Range");
                m_agent_range = Ranges.view_range;
                return;
            }
            else if (m_sensor.PlayerEnemyDistance() >= 1 && m_sensor.PlayerEnemyDistance() < 7)
            {
                m_agent_range = Ranges.shoot_range;
                //print("Shoot Range");
            }
            else
            {
                m_agent_range = Ranges.melee_range;
                //print("Melee Range");
            }
        }
        else
        {
            // out of range
            //print("Out of range");
            m_agent_range = Ranges.out_of_range;
            return;
        }
    }
    // returns state of range of agent
    public Ranges GetAgentRange()
    {
        return m_agent_range;
    }

    public void SetMoveLocation(Vector3 loc)
    {
        m_move_location = loc;
    }

    public Vector3 GetMoveLocation()
    {
        return m_move_location;
    }

    public bool HasAmmo()
    {
        if (m_ammo != 0)
            return true;
        else
            return false;
    }

    public bool HasMeleeWeapon()
    {
        return m_melee;
    }

    public void SetMeleeWeapon(bool melee)
    {
        m_melee = melee;
    }
    // returns ammo amount
    // public int getAmmo()
    // {
    //     return m_ammo_capacity;
    // }

    // // adds ammo
    // public void setAmmo(int ammo)
    // {
    //     m_ammo_capacity += ammo;
    // }

    // // returns 1 or 0 depending on agent having a melee weapon or not, respectively
    // public bool getMelee()
    // {
    //     return m_have_melee_weapon;
    // }

    // // sets melee weapon
    // public void setMelee(bool melee)
    // {
    //     m_have_melee_weapon = melee;
    // }

    // // returns agent health
    // public int getAgentHealth()
    // {
    //     return m_agent_health;
    // }
}