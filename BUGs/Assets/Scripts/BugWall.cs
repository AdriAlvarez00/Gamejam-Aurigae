using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugWall : MonoBehaviour
{
    [SerializeField] KeyCode key = KeyCode.F;
    void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(key))
        {

            Destroy(this.gameObject);
        }
    }
}
