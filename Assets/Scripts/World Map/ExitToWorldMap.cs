using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToWorldMap : MonoBehaviour
{

    void OnTriggerEnter(Collider col){
        if(col.tag =="Player"){
            Manager.instance.ChangeLevel("WorldMap",Vector3.zero);
        }
    }
}
