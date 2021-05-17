using System.Collections.Generic;
using UnityEngine;

public class ActionPatrol : HTNaction {
    
    public ActionPatrol() {
        // m_preconditions.Add(new KeyValuePair<string, object>("PlayerFound", false));
        // m_effects.Add(new KeyValuePair<string, object>("PlayerFound", true));
        // m_type = m_type_list.compound;
        m_is_primitive = false;
        m_in_range = true;            // is agent in range of performing task
    }
    public override void ResetAction() {
        m_in_range = true;
    }
    public override bool IsDone() {
        // set range

        // update ap_locations
        return true;
    }
    public override void ExecuteAction() {
        // Primitive task #1: find available location

        //  Primitive task #2: move to location
        /// either move to player known location
        /// OR move to player last known location

        //  Primitive task #3: check for player
    }

    public override Stack<HTNaction> DecomposeAction(AgentWorldState world_state) {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        actions = GetComponent<HTNdomain>().Patrol(world_state);
        return actions;
    }
}