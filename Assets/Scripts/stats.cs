using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    public int lives;
    public float hp;

    public void takeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            //dead
        }
    }
}
