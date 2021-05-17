using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMoveToShootingRange : HTNaction
{
    [SerializeField] Vector3 m_dest;
    [SerializeField] Vector3 m_agent_pos;

    void Start() {
        m_is_primitive = true;
    }

    void Update() {}
    
    public void SetState(Vector3 dest, Vector3 agent_pos) {
        m_dest = dest;
        m_agent_pos = agent_pos;
    }
    
    public void SetDestination(Vector3 dest) {
        m_dest = dest;
    }

    public override void ResetAction() {}

    public override bool IsDone() {
        if (this.transform.position == m_dest)
            return true;
        return false;
    }

    public override void ExecuteAction() {
        // Pathfind to destination
        print("Execute function of ActionMoveToShootingRange");
        SetDestination(gameObject.GetComponent<AgentWorldState>().GetMoveLocation());
        this.transform.position = Vector3.MoveTowards(this.transform.position, m_dest, 2.0f * Time.deltaTime);
    }
    public override Stack<HTNaction> DecomposeAction(AgentWorldState world_state) {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        return actions;
    }
}
