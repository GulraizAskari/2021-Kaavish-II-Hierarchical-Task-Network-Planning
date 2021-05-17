using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public abstract class HTNaction : MonoBehaviour {
    // protected m_type_list m_type;
    protected HTNdomain m_htn_domain;
    protected bool m_is_primitive;
    protected List<KeyValuePair<string, object>> m_preconditions;
    protected List<KeyValuePair<string, object>> m_effects;
    // protected enum m_type_list {
    //     primitive,
    //     compound
    // }
    protected bool m_needs_range = false;
    protected bool m_in_range = false;
    protected GameObject m_target;

    void Start() {
        m_htn_domain = GetComponent<HTNdomain>();
        m_preconditions = new List<KeyValuePair<string, object>>();
        m_effects = new List<KeyValuePair<string, object>>();
    }

    public bool IsPrimitive() {
        return m_is_primitive;
    }

    // public HTNdomain GetHtnDomain() {
    //     return m_htn_domain;
    // }

    public abstract void ResetAction();
        // ha_in_range = false;
        // ha_target = null;

    public abstract bool IsDone();
    public abstract void ExecuteAction();
    // public abstract Stack<HTNaction> DecomposeAction();
    public abstract Stack<HTNaction> DecomposeAction(AgentWorldState world_state);
}