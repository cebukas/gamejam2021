using UnityEngine;

public class PressurePlate : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject controlledGameObject;

    private bool _pressureApplied = false;

    public void Interact()
    {
        if (controlledGameObject != null && !_pressureApplied)
        {
            controlledGameObject.GetComponent<IControllable>().Control();
            _pressureApplied = true;
        }
        else if (controlledGameObject == null)
        {
            Debug.LogWarning("Pressure plate doesn't control anything");
        }
    }
}
