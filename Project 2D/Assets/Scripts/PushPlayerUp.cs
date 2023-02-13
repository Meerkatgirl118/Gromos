using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayerUp : MonoBehaviour
{
    [SerializeField] float upwardsForce = 150f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, upwardsForce));
        }
    }
}
