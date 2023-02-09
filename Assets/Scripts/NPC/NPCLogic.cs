using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCLogic : MonoBehaviour
{
    [SerializeField] private FieldOfView fov;

    [SerializeField]private bool agressive;

    [SerializeField] private float speed;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Animator animator;

    [SerializeField] private int distanceRequired;

    private bool inRange;
    private bool dead;

    [SerializeField] private int health;

    private float cooldown;

    [SerializeField] private float maxCooldown;

    [SerializeField] private int armor;

    [SerializeField] private int attack;

    [SerializeField] private int exp;

    [SerializeField] private Trigger triggerWhenDead;

    private bool first;

    void Start()
    { 
        first = true;
        cooldown = 0;
        inRange = false;
        agent.speed = speed;
    }


    void Update()
    {
        if(dead || Time.timeScale == 0){
            return;
        }

        if(agressive && fov.canSeePlayer){
            agent.SetDestination(fov.playerRef.transform.position);
            if(first){
                first = false;
                return;
            }
        }

        inRange = agent.remainingDistance <= distanceRequired;
        agent.isStopped = inRange;
        animator.SetBool("Walking", !inRange);

        if(inRange && agressive && fov.canSeePlayer){
            if(cooldown > 0){
                cooldown-=Time.deltaTime;
                animator.SetBool("Attacking", false); 
            }else{
                Fire();
                animator.SetBool("Attacking", true); 
                cooldown = maxCooldown;
            }
        }
    }

    public bool isAgressive {
        get => agressive;
        set => agressive = value;
    }

    public void TakeHit(int damage){
        health -= Mathf.Clamp(0,damage,damage-armor);
        if(health<=0){
            agent.SetDestination(transform.position);
            dead = true;
            animator.SetBool("Dead",true);
            GetComponent<Collider>().enabled = false;
            Manager.instance.AddExp(exp);
            PlayerUI.instance.RefreshPlayerLevel();

            if(triggerWhenDead != null){
                triggerWhenDead.Activate();
            }
        }else{
            agressive = true;
            transform.LookAt(fov.playerRef.transform);
        }
    }


    void Fire(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward ,out hit,distanceRequired)){
            if(hit.transform.tag=="Player" && hit.transform.GetComponent<PlayerHealth>() != null){
                hit.transform.GetComponent<PlayerHealth>().TakeDamage(attack);
            }
        }
    }
}
