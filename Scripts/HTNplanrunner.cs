using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class HTNplanrunner : MonoBehaviour
{
    HTNoperator m_operator;
    Queue<HTNaction> m_plan;
    bool m_executing;

    void Start()
    {
        m_plan = new Queue<HTNaction>();
        m_executing = false;
    }

    void Update()
    {
        // print("Executing: " + m_executing);
        if (GetComponent<HTNplanner>().IsPlanComplete() && !m_executing)
        {
            m_executing = true;
            m_plan = GetComponent<HTNplanner>().GetPlan();
            StartCoroutine("ExecutePlan");
        }
    }

    IEnumerator ExecutePlan()
    {    // should this be a coroutine??
        HTNaction current_action = GetComponent<HTNaction>();
        bool next_action = true;
        //print("Executing Plan!!");
        //print("-----------first current action is: " + current_action);
        while (m_plan.Count != 0)
        {
            if (current_action.IsDone())
            {
                //print("-----------current action is: " + current_action);
                current_action = m_plan.Dequeue();
                current_action.ExecuteAction();
            }
            // if (current_action.IsDone()) {
            //     next_action = true;
            // } 
            // else {
            //     next_action = false;
            // }
            yield return null;
        }
        // print("Action status: " + current_action.IsDone());
        // while (current_action.IsDone() == false) {} // do nothing while the last task isn't finished

        GetComponent<HTNplanner>().SetPlanCompletionState(false);
        m_executing = false;
        yield return null;
    }
}