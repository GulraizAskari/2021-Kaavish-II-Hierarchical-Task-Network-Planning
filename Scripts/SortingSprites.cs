using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingSprites : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 5000;
    [SerializeField]
    private float offset = 0f;

    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y * 10 - offset);
    }

    public void SetOffset(float off)
    {
        offset = off;
    }

    public int GetOffset()
    {
        return (int)offset;
    }
}
