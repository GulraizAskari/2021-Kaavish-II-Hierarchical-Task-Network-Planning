using System.Collections.Generic;
using UnityEngine;
using System;

public class HTNdomain : MonoBehaviour
{

    Component[] m_actions;
    List<Vector3> m_patrol_locations = new List<Vector3>();
    [SerializeField] GameObject m_player;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_actions = gameObject.GetComponents(typeof(HTNaction));
        foreach (Component comp in m_actions)
        {
            //print("done");
        }
        m_patrol_locations = new List<Vector3>();
        Vector3 temp = new Vector3(-10.61f, 3.97f, 0.0f);
        m_patrol_locations.Add(temp);
    }

    void Update() { }

    // compound task 0 - Be Soldier (ROOT)
    public Stack<HTNaction> BeSoldier(AgentWorldState world_state)
    {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        if (world_state.GetAgentRange() == AgentWorldState.Ranges.out_of_range)
            actions.Push(GetComponent<ActionPatrol>());
        else
            actions.Push(GetComponent<ActionAttack>());

        return actions;
    }

    // compound task 1 - Attack the player
    public Stack<HTNaction> Attack(AgentWorldState world_state)
    {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        if (world_state.GetAgentRange() == AgentWorldState.Ranges.shoot_range)
            actions.Push(GetComponent<ActionUseRangeWeapon>());
        else if (world_state.GetAgentRange() == AgentWorldState.Ranges.view_range)
            actions.Push(GetComponent<ActionRangeAttack>());
        else if (world_state.GetAgentRange() == AgentWorldState.Ranges.melee_range)
            actions.Push(GetComponent<ActionMeleeAttack>());

        return actions;
    }

    // compound task 2 - Patrol available patrol locations
    public Stack<HTNaction> Patrol(AgentWorldState world_state)
    {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        if (world_state.GetAgentRange() == AgentWorldState.Ranges.out_of_range)
        {
            actions.Push(GetComponent<ActionSelectLocation>());                 // select patrol location
            actions.Push(GetComponent<ActionMoveTo>());                         // move to selected location
            actions.Push(GetComponent<ActionSearchForPlayer>());                // search for player
        }
        return actions;
    }

    // compound task 2 - Range attack the player
    public Stack<HTNaction> RangeAttack(AgentWorldState world_state)
    {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        if (world_state.HasAmmo() == true)
        {
            actions.Push(GetComponent<ActionMoveToShootingRange>());
            actions.Push(GetComponent<ActionUseRangeWeapon>());
        }
        else
        {
            actions.Push(GetComponent<ActionSearchForAmmo>());
            actions.Push(GetComponent<ActionRefillAmmo>());
            actions.Push(GetComponent<ActionRangeAttack>());
        }

        return actions;
    }

    // compound task 3 - Melee attack the player
    public Stack<HTNaction> MeleeAttack(AgentWorldState world_state)
    {
        Stack<HTNaction> actions = new Stack<HTNaction>();
        if (world_state.HasMeleeWeapon() == true)
            actions.Push(GetComponent<ActionUseMeleeWeapon>());
        else
            actions.Push(GetComponent<ActionUseMeleeHands>());
        return actions;
    }

    // primitive task 0 - check for enemy
    public void Search(Vector3 player_pos)
    {
        // execute: scout for enemy

    }

    public void MoveTowardsEnemy()
    {
        // effect - update agent's location in worldstate
        // ActionMoveTo move(m_player.transform.position);
        // move.ExecuteAction();
        // if (move.IsDone())
        //     print("Reached Player!!");
        // else
        //     print("Failed Move!!");
    }

    // primitive task 1 - Choose an available patrol location
    public void ChoosePatrolLocation() { }

    // primitive task 2 - Attack player with range weapon
    public void UseRangeWeapon()
    {
        GetComponent<ActionUseRangeWeapon>().ExecuteAction();
    }

    // primitive task 3 - Move to a valid location to shoot the player 
    public void MoveToShootingRange()
    {
        GetComponent<ActionMoveToShootingRange>().ExecuteAction();
    }

    // primitive task 4
    public void MoveTo()
    {
        // effect - update goober's location in worldstate
        //ActionMoveTo move = new ActionMoveTo(m_patrol_locations[0], this.transform.position);
        //move.SetDestination(m_player.transform.position);
        ActionMoveTo move = GetComponent<ActionMoveTo>();
        move.SetDestination(m_patrol_locations[0]);
        move.ExecuteAction();
        //if (move.IsDone() == false)
        //    print("Moving");

        //if (move.IsDone())
        //    print("Moved!!");
    }

    // primitive task 5 - Attack player with melee weapon
    public void UseMeleeWeapon() { }

    // primitive task 6 - Attack player with hands
    public void UseMeleeHands() { }
}