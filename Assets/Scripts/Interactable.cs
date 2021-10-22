using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = true;
    public Transform player;

    void Update()
    {
        if (isFocus)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
            }
        }
    }
    void onDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public virtual void Interact()
    {

    }
    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
    }

    public void DeFocused()
    {
        isFocus = false;
        player = null;
    }
}
