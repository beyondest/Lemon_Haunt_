using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;        // Use transform instead of gameobject to make it easier to determine clear line
    public GameEnding gameEnding;
    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player )
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    private void Update()
    {
        if ( m_IsPlayerInRange )
        {
            // transform.postion is the position of the observer, player.position is the position of the feet of player, so add up
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if ( Physics.Raycast(ray, out raycastHit ))
            {
                if ( raycastHit .collider.transform  == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }


}
