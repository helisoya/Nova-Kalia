using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapLocation : MonoBehaviour
{
    [SerializeField] private string locationName;
    [SerializeField] private string levelName;

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            WorldMapUI.instance.ShowLocationTab(locationName,levelName);
        }
    }

    void OnTriggerExit(Collider col){
        if(col.tag == "Player"){
            WorldMapUI.instance.HideLocationTab();
        }
    }

}
