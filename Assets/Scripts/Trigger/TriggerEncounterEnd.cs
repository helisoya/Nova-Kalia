using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEncounterEnd : Trigger
{

    [SerializeField] private int nbEnnemies;
    public override void Activate(){
        nbEnnemies--;
        if(nbEnnemies <= 0){
            Manager.instance.ChangeLevel("WorldMap",Vector3.zero);
        }
    }

    public override void Desactivate()
    {
        throw new System.NotImplementedException();
    }
}
