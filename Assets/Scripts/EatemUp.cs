using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatemUp : MonoBehaviour
{

    private float speedIncrease = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EatUp(other);
        }


        void EatUp(Collider2D player)
        {
            //explosion of guts


            //player gets to speed up
        
            PlayerController controller  = player.GetComponent<PlayerController>();
            controller.zombieSpeed *= speedIncrease;

              //remove eaten person
            Destroy(gameObject);
        }

    }


}
