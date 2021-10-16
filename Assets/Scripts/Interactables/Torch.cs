using Interfaces;
using UnityEngine;

public class Torch : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Sprite _torchLit;

    [SerializeField]
    private Sprite _torchUnlit;

    [SerializeField]
    private GameObject _lightSource;
    
    private bool _torchIsLit = false;

    public void Start()
    {
        _lightSource.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = _torchUnlit;
        _torchIsLit = false;
    }
    
    public void Interact()
    {
        SwitchState();
    }

    private void SwitchState()
    {
        _torchIsLit = !_torchIsLit;
        if (_torchIsLit)
        {
            FindObjectOfType<AudioManager>().Play("Torch");
            _lightSource.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = _torchLit;
        }
        else
        {
            _lightSource.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = _torchUnlit;
        }
    }
}
