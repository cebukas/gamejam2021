using UnityEngine;

public class LightRotation : MonoBehaviour
{
    [SerializeField]
    private int speedInDegrees;

    private void Update()
    {
        transform.Rotate (0,0,speedInDegrees * Time.deltaTime);
    }
}
