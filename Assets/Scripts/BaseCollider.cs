using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            FindObjectOfType<Lives>().RemoveLives();
        }
        if (collision)
        {
            Destroy(collision.gameObject);
        }

    }
}
