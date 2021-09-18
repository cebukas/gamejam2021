using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Transform destination;
    [SerializeField]
    private Transform trigger;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private bool FinalTeleport = false;

    private SpriteRenderer _renderer;
   
    void Start()
    {
        _renderer = player.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!(Vector3.Distance(player.GetComponent<Transform>().position, trigger.position) <= 1f)) return;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine("FadeIn");
        FindObjectOfType<AudioManager>().Play("Teleport");
        player.GetComponent<Transform>().position = destination.position;

        if(FinalTeleport)
        {
            GameManager.Win = true;
        }
    }
    IEnumerator FadeIn()
    {
        for (var f = 0.05f; f <= 1; f += 0.05f)
        {
            var c = _renderer.material.color;
            c.a = f;
            _renderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    IEnumerator FadeOut()
    {
        for (var f = 1f; f >= 0.05f; f -= 0.05f)
        {
            var c = _renderer.material.color;
            c.a = f;
            _renderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
