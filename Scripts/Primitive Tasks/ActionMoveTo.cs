using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ActionMoveTo : HTNaction
{
    [SerializeField] Vector3 m_dest = new Vector3(-4.0f, 0, 0);
    [SerializeField] Vector3 m_agent_pos;
    //[SerializeField] AgentController amt_agent;

    void Start()
    {
        // m_preconditions.Add(new KeyValuePair<string, object>(""));
        // m_type = m_type_list.primitive;
        m_is_primitive = true;

    }

    void Update() { }
    // public void SetState(Vector3 dest, Vector3 agent_pos) {
    //     m_dest = dest;
    //     m_agent_pos = agent_pos;
    // }

    public void SetDestination(Vector3 dest)
    {
        m_dest = dest;
    }

    // Coroutine to move the agent to patrol location
    IEnumerator Move()
    {
        while (Vector2.Distance(transform.position, m_dest) > 0)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, m_dest, 1 * Time.deltaTime);
            //print("Moving npc.------");
            yield return null;
        }
        yield return null;
    }

    public override void ResetAction() { }

    public override bool IsDone()
    {
        //print("MOVETO CALLED--------");
        if (this.transform.position == m_dest)
        {
            GetComponent<ActionSelectLocation>().ResetAction();
            GetComponent<ActionSelectLocation>().SetLastVisited(m_dest);
            print("IS DONE Returning true for moveToAction");
            return true;
        }
        return false;
    }

    public override void ExecuteAction()
    {
        // Pathfind to destination
        print("Execute function of ActionMoveTo");

        SetDestination(gameObject.GetComponent<AgentWorldState>().GetMoveLocation());
        StartCoroutine("Move");
    }
    public override Stack<HTNaction> DecomposeAction(AgentWorldState world_state)
    {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        return actions;
    }
}