using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        print("hit " + other.name + "!");
        if(other.name != "Ground")
        Destroy(other.gameObject);
    }
}
