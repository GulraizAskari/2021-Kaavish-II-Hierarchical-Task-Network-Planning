using System.Collections.Generic;
using UnityEngine;

public class BeSoldier : HTNaction
{

    void Start()
    {
        m_is_primitive = false;
        // m_preconditions.Add(new KeyValuePair<string, object>("PlayerAlive", true));
        // m_effects.Add(new KeyValuePair<string, object>("PlayerAlive", false));
    }

    public override void ResetAction() { }

    public override bool IsDone()
    {
        // if player is not alive return true
        // else false
        return true;
    }

    public override void ExecuteAction() { }

    public override Stack<HTNaction> DecomposeAction(AgentWorldState world_state)
    {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        actions = GetComponent<HTNdomain>().BeSoldier(world_state);
        return actions;
    }
}