using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugable : MonoBehaviour
{
    public Sprite bugged;
    SpriteRenderer sp;
    BoxCollider2D col;
    public KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        if (!sp) Debug.Log("El renderer melon",this);
        col = GetComponent<BoxCollider2D>();
        if (!sp) Debug.Log("El colider fisico melon", this);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(key) && GameManager.instance.stage >= 2)
        {
            col.enabled = false;
            sp.sprite = bugged;
        }
    }
}
