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
    private bool finalTeleport = false;

    private SpriteRenderer _renderer;
   
    private void Start()
    {
        _renderer = player.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        IsTeleporting();
    }

    private void IsTeleporting()
    {
        if (!((player.GetComponent<Transform>().position - trigger.position).sqrMagnitude <= 1f)) return;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine("FadeIn");
        FindObjectOfType<AudioManager>().Play("Teleport");
        player.GetComponent<Transform>().position = destination.position;

        if(finalTeleport)
        {
            GameManager.Win = true;
        }
    }

    private IEnumerator FadeIn()
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

    private IEnumerator FadeOut()
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
