using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private EnemyAnimator _enemyAnimator;
    private enum State {
        Roaming,
        ChaseTarget,
    }
    private State state; 
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    [SerializeField] Transform target;
    // Transform area;
    NavMeshAgent agent;

    private void Awake()
    {
        state = State.Roaming;
        _enemyAnimator = GetComponent<EnemyAnimator>();
    }
    void Start()
    {   
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();
    }

    
    // Update is called once per frame
    void Update()
    {
        
        
        switch (state)
        {            
        default:
        case State.Roaming:
            agent.SetDestination(roamPosition);
         
            if(roamPosition.x < startingPosition.x) {
                _enemyAnimator.flipSprite(true);
            }
            if(roamPosition.x > startingPosition.x){
                _enemyAnimator.flipSprite(false);
            }
            _enemyAnimator.playRunAnimation();

            float reachedPositionDistance = 1f;
            if(Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance){
            //reached destination
            _enemyAnimator.playIdleAnimation();
            roamPosition = GetRoamingPosition();
            agent.SetDestination(roamPosition);
            }
            FindTarget();          
            break;
        case State.ChaseTarget:
            _enemyAnimator.playRunAnimation();
            agent.SetDestination(target.position);
            
            if(target.position.x < transform.position.x) {
            _enemyAnimator.flipSprite(true);
            }
            if(target.position.x > transform.position.x) {
            _enemyAnimator.flipSprite(false);
            }
            FindTarget();

            break;

        }

        
        
    }
    private Vector3 GetRoamingPosition() {
        return startingPosition + UtilsClass.GetRandomDir() * Random.Range(5f,20f);
    }

    private void FindTarget(){
        float targetRange = 20f;
        if(Vector3.Distance(transform.position, target.position) < targetRange){
            //target in range
            state = State.ChaseTarget;
        }
        else {state = State.Roaming;}
    }

}
