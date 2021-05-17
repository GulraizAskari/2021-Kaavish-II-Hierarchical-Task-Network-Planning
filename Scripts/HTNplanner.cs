using System.Collections.Generic;
using UnityEngine;
using System;

public class HTNplanner : MonoBehaviour
{
    AgentWorldState m_working_world_state;
    AgentWorldState.Ranges m_current_range;
    bool m_plan_complete;
    // bool m_planning;
    Stack<HTNaction> m_actions_to_process;
    Queue<HTNaction> m_final_plan;
    /* 
    Start planning if:
    1. NPC completes/fails current plan
    2. NPC does not have a plan
    3. NPC's world state has changed via a sensor
    */
    // make stack for plan

    void Start()
    {
        m_plan_complete = false;
        m_working_world_state = GetComponent<AgentWorldState>();
        foreach (KeyValuePair<string, object> world_condition in m_working_world_state.m_current_world_state)
        {
            print("initial world condition is: " + world_condition);
        }
    }

    void Update()
    {
        if (!m_plan_complete)
        {
            ResetPlan();
            Plan();
        }
        else if (m_current_range != m_working_world_state.GetAgentRange())
        {
            m_plan_complete = false;
        }
    }

    void Plan()
    {
        // execute compound task (BeSoldier here)
        HTNaction current_action;
        Stack<HTNaction> temp = new Stack<HTNaction>();
        m_current_range = m_working_world_state.GetAgentRange();

        while (m_actions_to_process.Count != 0)
        {
            current_action = m_actions_to_process.Pop();
            // print("Action: " + current_action);
            // print("Type: " + current_action.IsPrimitive());
            if (!(current_action.IsPrimitive()))
            {            // compound task
                // print("AAAAAAAAAAA");
                temp = current_action.DecomposeAction(m_working_world_state);
                while (temp.Count != 0)
                {
                    m_actions_to_process.Push(temp.Pop());
                }
                // print("-----------temp plan");
                // foreach (HTNaction action in m_actions_to_process) {
                //     print(action);
                // }
            }
            else
            {  // primitive task
                // if check conditions for primitive are met
                // m_working_world_state.ApplyEffects(current_action.Effects);
                m_final_plan.Enqueue(current_action);
                // else RestoreToLastDecomposedTask();
            }
            // check if agent range changes
            if (m_current_range != m_working_world_state.GetAgentRange())
            {
                m_current_range = m_working_world_state.GetAgentRange();
                ResetPlan();
            }
        }
        m_plan_complete = true;
        //print("FINAL PLAN");
        // foreach (HTNaction action in m_final_plan)
        // {
        //     print(action);
        // }
    }

    public void ResetPlan()
    {
        m_final_plan = new Queue<HTNaction>();
        m_actions_to_process = new Stack<HTNaction>();
        m_actions_to_process.Push(GetComponent<BeSoldier>());
    }

    public bool IsEnemyInView()
    {
        // check if player(enemy) is in view range
        if (m_working_world_state.GetAgentRange() == AgentWorldState.Ranges.view_range)
            return true;
        return false;
    }

    public bool IsPlanComplete()
    {
        return m_plan_complete;
    }

    public void SetPlanCompletionState(bool state)
    {
        m_plan_complete = state;
    }

    public Queue<HTNaction> GetPlan()
    {
        return m_final_plan;
    }

    // public bool hasAmmo()
    // {
    //     if (htn_state.getAmmo() > 0)
    //         return true;
    //     return false;
    // }

    // public bool canMelee()
    // {
    //     if (htn_state.getMelee())
    //         return true;
    //     return false;
    // }
}