using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public Weapon[] weapons;

    int currentWeapon = 0;

    public Camera cam;

    public ParticleSystem muzzleFlare;

    public static PlayerWeapons instance;

    void Start()
    {
        instance = this;
        ChangeWeapon(0);
    }



    void ChangeWeapon(int newWeapon){
        weapons[currentWeapon].gunModel.SetActive(false);
        currentWeapon = newWeapon;
        weapons[currentWeapon].gunModel.SetActive(true);
        muzzleFlare.transform.parent = weapons[currentWeapon].barrel.transform;
        muzzleFlare.transform.localPosition = Vector3.zero;
    }


    void Update(){

        if(Time.timeScale == 0) return;

        if(Input.mouseScrollDelta.y > 0){
            ChangeWeapon( (currentWeapon + 1 + weapons.Length) % weapons.Length);
        }
        else if(Input.mouseScrollDelta.y < 0){
            ChangeWeapon( (currentWeapon - 1 + weapons.Length) % weapons.Length);
        }

        weapons[currentWeapon].Cooldown();
        if(weapons[currentWeapon].CanShoot()){
            if(Input.GetMouseButton(0)){
                Shoot(); 
            }
        }
    }

    void Shoot(){
        weapons[currentWeapon].Shoot();
        muzzleFlare.Play();
        weapons[currentWeapon].animation.Play();

        RaycastHit hit;
        if(Physics.Raycast(transform.position,cam.transform.forward ,out hit,weapons[currentWeapon].maxDistance)){
            if(hit.transform.tag=="Ennemy" && hit.transform.GetComponent<NPCLogic>() != null){
                hit.transform.GetComponent<NPCLogic>().TakeHit(weapons[currentWeapon].damage);
            }
        }
    }

}
