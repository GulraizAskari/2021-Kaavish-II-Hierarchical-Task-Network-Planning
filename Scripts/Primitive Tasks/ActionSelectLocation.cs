using System.Collections.Generic;
using UnityEngine;

public class ActionSelectLocation : HTNaction
{
    static List<Vector3> m_locations = new List<Vector3>();
    Vector3 m_last_visited;
    int m_visiting;
    bool m_location_set;

    public void Start() {
        // add preconditions
        // add effects
        m_is_primitive = true;
        m_location_set = false;
        SetLocations();
    }

    public void RemoveLocation(int index) {
        m_locations.RemoveAt(index);
    }

    public void AddLocation(Vector3 loc) {
        m_locations.Add(loc);
    }

    public static void SetLocations() {
        m_locations.Add(new Vector3(-6.0f, 4.0f, 0.0f));
        m_locations.Add(new Vector3(-6.0f, -4.0f, 0.0f));
        m_locations.Add(new Vector3(-10.0f, 0.0f, 0.0f));
    }

    public void SetLastVisited(Vector3 pos) {
        m_last_visited = pos;
    }

    public override void ResetAction() {
        m_location_set = false;
    }

    public override bool IsDone() {
        print("SELECTLOC CALLED--------");
        if (m_location_set)
            return true;
        return false;
    }

    public override void ExecuteAction() {
        print("Execute function of ActionSelectLocation");
        // add check for last visited loc
        if (m_locations.Count > 0) {
            m_visiting = Random.Range(0, m_locations.Count);

            while (m_locations[m_visiting] == m_last_visited)
                m_visiting = Random.Range(0, m_locations.Count);

            gameObject.GetComponent<AgentWorldState>().SetMoveLocation(m_locations[m_visiting]);
            m_location_set = true;
        }
    }

    public override Stack<HTNaction> DecomposeAction(AgentWorldState world_state) {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        return actions;
    }
}