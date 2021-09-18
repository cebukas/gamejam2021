using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    private bool _leverEnabled = false;
    
    [SerializeField]
    private GameObject[] ControlledGameObjects;

    [SerializeField]
    private Sprite _leverDown;

    [SerializeField]
    private Sprite _leverUp;

    public void Interact()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SwitchState();

        if (ControlledGameObjects != null)
        {
            foreach(var controlledObject in ControlledGameObjects)
            {
                controlledObject.GetComponent<IControllable>().Control();
            }
        }
        else
        {
            Debug.LogWarning("Lever doesn't control anything");
        }
    }

    private void SwitchState()
    {
        _leverEnabled = !_leverEnabled;
        GetComponent<SpriteRenderer>().sprite = _leverEnabled ? _leverDown : _leverUp;
    }
}
