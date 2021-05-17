using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMeleeAttack : HTNaction
{
    // Start is called before the first frame update
    void Start() {
        // m_type = m_type_list.primitive;
        m_is_primitive = true;
    }

    // Update is called once per frame
    void Update() {
        
    }
    public override void ResetAction() {}
        // ha_in_range = false;
        // ha_target = null;

    public override bool IsDone() {
        return true;
    }
    public override void ExecuteAction() {
        // print("stab stab stab ---------->");
    }
    public override Stack<HTNaction> DecomposeAction(AgentWorldState world_state) {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        actions = GetComponent<HTNdomain>().MeleeAttack(world_state);
        return actions;
    }
}
