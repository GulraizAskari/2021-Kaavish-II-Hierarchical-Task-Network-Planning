using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name == "Dead Player")
        {
            if (this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f && !this.animator.IsInTransition(0))
            {
                GameObject.Find("Obstacle Finder").GetComponent<ObstacleFinder>().Info = new List<Obstacle>();
                Brave.Covers = new List<GameObject>();
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
