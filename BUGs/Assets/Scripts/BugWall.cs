using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugWall : MonoBehaviour
{
    [SerializeField] KeyCode key = KeyCode.F;
    PlayerMovement Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(key) && GameManager.instance.stage >= 2)
        {

            Destroy(this.gameObject);
        }
    }
}
