using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public float damage = 40;
    public float lookRadius = 20;
    public float moveSpeed;
    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = managerCharacter.instance.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if(distance <= agent.stoppingDistance)
            {
                faceTarget();
            }
        }
        else
        {
            agent.SetDestination(new Vector3(Random.Range(0, 100), Random.Range(0, 100), 0));
        }
    }

    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("hit Player " + other.name + "!");
        if (other.name == "MainCharacter")
        {
            FindObjectOfType<stats>().takeDamage(damage);
        }
        
            Destroy(other.gameObject);
    }
}
