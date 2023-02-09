using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{   
    public Animation animation;
    public GameObject gunModel;
    public GameObject barrel;
    public int damage;
    public int maxDistance;
    public float maxCooldown;
    float cooldown = 0;



    public void Shoot(){
        cooldown = maxCooldown;
    }

    public void Cooldown(){
        if(cooldown>0){
            cooldown-=Time.deltaTime;
        }
    }


    public bool CanShoot(){
        return cooldown <= 0;
    }



}
