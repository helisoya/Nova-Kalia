using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldMapInit : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject prefabEnnemy;
    [SerializeField] private int nbEnnemies;

    [SerializeField] private Transform spawnPointsRoot;

    void Start(){
        Save save = Manager.instance.GetSave();
        if(save.worldMapPos.x != 0 && 
            save.worldMapPos.y != 0 &&
            save.worldMapPos.z != 0){
            player.GetComponent<NavMeshAgent>().Warp(save.worldMapPos);
        }

        for(int i = 0;i< nbEnnemies;i++){
            Vector3 randomDirection = Random.insideUnitSphere * 5;
            randomDirection += spawnPointsRoot.GetChild(Random.Range(0,spawnPointsRoot.childCount)).position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 5, 1);

            if(hit.position.x == Mathf.Infinity) continue;
            Instantiate(prefabEnnemy).transform.position = hit.position;
        }
    }
}
