using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAttack : HTNaction
{
    // Start is called before the first frame update
    void Start() {
        // m_type = m_type_list.compound;
        m_is_primitive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ResetAction(){}

    public override bool IsDone() {
        return true;
    }
    public override void ExecuteAction(){}

    public override Stack<HTNaction> DecomposeAction(AgentWorldState world_state) {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        actions = GetComponent<HTNdomain>().Attack(world_state);
        return actions;
    }
}
