using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ActionReload : HTNaction
{
    [SerializeField] Vector3 m_dest;
    [SerializeField] Vector3 m_agent_pos;
    //[SerializeField] AgentController amt_agent;

    void Start()
    {
        // m_preconditions.Add(new KeyValuePair<string, object>("HaveAmmo", false));
        // m_effects.Add(new KeyValuePair<string, object>("HaveAmmo", true));
        // m_type = m_type_list.primitive;
        m_is_primitive = true;
    }

    public override void ResetAction() {}

    public override bool IsDone() {
        return true;
    }

    public override void ExecuteAction() {
        print("Execute function of Reload");
        // refill bullets
        // GetComponent<BeSoldier>().m_bullets = m_bullet_capacity;
        // add animation
    }
    
    public override Stack<HTNaction> DecomposeAction(AgentWorldState world_state) {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        return actions;
    }
}