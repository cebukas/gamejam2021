﻿using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public Transform destination;
    public Transform trigger;
    public GameObject player;
    private SpriteRenderer rend;

    public bool FinalTeleport = false;

    void Start()
    {
        rend = player.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(player.GetComponent<Transform>().position, trigger.position) <= 1f)
        {
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine("FadeIn");
            FindObjectOfType<AudioManager>().Play("Teleport");
            player.GetComponent<Transform>().position = destination.position;

            if(FinalTeleport)
            {
                GameManager.Win = true;
            }
        }
    }
    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    IEnumerator FadeOut()
    {

        for (float f = 1; f >= 0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

    }
}
