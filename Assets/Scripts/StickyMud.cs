using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyMud : MonoBehaviour
{

    private float speedDecrease = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StickyMud(other);
        }


        void StickyMud(Collider2D player)
        {
            //player slows down
        
            PlayerController controller  = player.GetComponent<PlayerController>();
            controller.zombieSpeed -= speedDecrease;

              //remove puddle
            Destroy(gameObject);
        }

    }


}
