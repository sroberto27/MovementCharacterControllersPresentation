using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    public Animator cattoAnimator;
    public NavMeshAgent cattoNavigation;

    private Transform targetDestination;

    void Start()
    {
        NavMeshAgent cattoNavigation = GetComponent<NavMeshAgent>();
        cattoAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                cattoNavigation.destination = hit.point;

                cattoAnimator.SetBool("Walking", true);
            }
        }

        if(cattoNavigation.remainingDistance <= cattoNavigation.stoppingDistance)
        {
            cattoAnimator.SetBool("Walking", false);
        }
    }
}
