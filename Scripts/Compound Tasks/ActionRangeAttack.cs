using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ActionRangeAttack : HTNaction
{
    [SerializeField] Vector3 m_dest;
    [SerializeField] Vector3 m_agent_pos;
    int m_bullets = 0;
    //[SerializeField] AgentController amt_agent;

    // constructor
    void Start()
    {
        // m_preconditions.Add(new KeyValuePair<string, object>("HaveAmmo", true));        //need to reload
        // m_preconditions.Add(new KeyValuePair<string, object>("Player found", true));
        // m_effects.Add(new KeyValuePair<string, object>("HaveAmmo", false));
        // m_effects.Add(new KeyValuePair<string, object>("Damaged Player", true));        // one of the goals
        // m_bullets = GetComponent<BeSoldier>().m_bullets;
        // m_type = m_type_list.primitive;
        m_is_primitive = false;
    }

    //first check this
    public void SetState() {}

    // public void SetDestination(Vector3 dest) {
    //     m_dest = dest;
    // }

    //if isDone, do reset
    public override void ResetAction() { }

    //third do this
    public override bool IsDone() {
        if (m_bullets == 0) // add the condition if player not in range
            return true;
        return false; //keep running executeaction till returned true
    }

    //second do this
    public override void ExecuteAction() {
        //shoot
        // print("------------------------shot a bullet");
    }
    public override Stack<HTNaction> DecomposeAction(AgentWorldState world_state) {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        actions = GetComponent<HTNdomain>().RangeAttack(world_state);
        return actions;
    }
}