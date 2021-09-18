using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{ 
    [SerializeField]
    private GameObject[] controlledGameObjects;

    [SerializeField]
    private Sprite leverDown;

    [SerializeField]
    private Sprite leverUp;

    private bool _leverEnabled = false;

    public void Interact()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SwitchState();

        if (controlledGameObjects != null)
        {
            foreach(var controlledObject in controlledGameObjects)
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
        GetComponent<SpriteRenderer>().sprite = _leverEnabled ? leverDown : leverUp;
    }
}
