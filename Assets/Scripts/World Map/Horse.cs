using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Horse : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl)){
            MenuUI.instance.CloseMenu();
            Time.timeScale = 3;
        }else{
            Time.timeScale = 1;
        }

        if(!agent.isStopped && agent.remainingDistance<=0.5){
            agent.isStopped = true;
            animator.SetBool("Walking",false);
        }

        if(Input.GetMouseButtonDown(1)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit)){
                if(hit.transform.tag=="Map"){
                    agent.isStopped = false;
                    agent.SetDestination(hit.point);
                    animator.SetBool("Walking",true);
                }
            }
        }
    }
}
