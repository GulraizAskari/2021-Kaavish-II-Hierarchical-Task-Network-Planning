using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSearchForPlayer : HTNaction
{
    bool m_searching;

    void Start() {
        m_is_primitive = true;
        m_searching = true;
    }

    void Update() {        
    }

    public override void ResetAction(){}

    public override bool IsDone(){
        print("SEARCHPLAYER CALLED--------");
        if (m_searching)
            return false;
        else
            return true;
    }
    public override void ExecuteAction(){
        print("Execute Function of SearchForPlayer");
        m_searching = false;
    }
    public override Stack<HTNaction> DecomposeAction(AgentWorldState world_state) {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        return actions;
    }
}
