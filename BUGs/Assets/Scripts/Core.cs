using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] KeyCode key = KeyCode.Q;
    PlayerMovement Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(key) && GameManager.instance.stage == 3)
        {
            GameManager.instance.End();
            Destroy(this.gameObject);
        }
    }
}
