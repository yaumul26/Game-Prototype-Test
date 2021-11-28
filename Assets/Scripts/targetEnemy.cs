using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetEnemy : MonoBehaviour
{

    public float hp;
    public float maxhp;
    public int[] hpRandomZombNormal = { 100, 125, 150, 175 };

    private void Start()
    {
        if (gameObject.name != "SZomb(Clone)")
        {
            int temp = Random.Range(0, hpRandomZombNormal.Length);
            hp = hpRandomZombNormal[temp];
            maxhp = hp;
        }else if (gameObject.name != "BZomb(Clone)")
        {

        }
       
    }
    public void takeDamage(float amount)
    {
        hp -= amount;
        if(hp <= 0)
        {
            Die();
        }

        transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = CalculateHealt();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    float CalculateHealt()
    {
        return hp / maxhp;
    }
}
