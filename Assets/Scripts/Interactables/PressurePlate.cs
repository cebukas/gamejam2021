using UnityEngine;

public class PressurePlate : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject ControlledGameObject;

    private bool _pressureApplied = false;

    public void Interact()
    {
        if (ControlledGameObject != null && !_pressureApplied)
        {
            ControlledGameObject.GetComponent<IControllable>().Control();
            _pressureApplied = true;
        }
        else if (ControlledGameObject == null)
        {
            Debug.LogWarning("Pressure plate doesn't control anything");
        }
    }
}
