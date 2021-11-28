using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera[] cam;
    public NavMeshAgent agent;
    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (Camera i in cam)
            {
                ray = i.ScreenPointToRay(Input.mousePosition);
            }

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }


        }
    }
}
