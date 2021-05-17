using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRefillAmmo : HTNaction
{
    // Start is called before the first frame update
    void Start() {
        m_is_primitive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ResetAction() {}

    public override bool IsDone() {
        return true;
    }

    public override void ExecuteAction() {
        // Pathfind to destination
        print("Execute function of RefillAmmo");
    }
    public override Stack<HTNaction> DecomposeAction(AgentWorldState world_state) {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        return actions;
    }
}
