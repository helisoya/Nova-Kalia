using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] protected GameObject mark;
    [SerializeField] protected Trigger whatToEnable;


    void Start(){
        mark.SetActive(true);
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            whatToEnable.Activate();
        }
    }

    void OnTriggerExit(Collider col){
        if(col.tag == "Player"){
            whatToEnable.Desactivate();
        }
    }
}
