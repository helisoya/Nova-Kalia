using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldMapEnnemy : MonoBehaviour
{
    [SerializeField] private FieldOfView fov;
    [SerializeField] private NavMeshAgent agent;

    void Start()
    {
        GetComponent<Animator>().SetBool("Walking",true);
    }

    // Update is called once per frame
    void Update()
    {
        if(fov.canSeePlayer){
            agent.SetDestination(fov.playerRef.transform.position);
        }else{
            if(agent.remainingDistance <= 1){
                ChooseNewWaypoint();
            }
        }
    }

    void ChooseNewWaypoint(){
        Vector3 randomDirection = Random.insideUnitSphere * 5;

        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 5, 1);
        agent.SetDestination(hit.position);
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            Manager.instance.ChangeLevel("Encounter1",col.transform.position);
        }
    }
}
