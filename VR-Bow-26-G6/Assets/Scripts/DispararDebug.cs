using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DispararDebug : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable mano;
    [SerializeField] private ArrowController arrow;

    private bool _wasPressed;

    private void Update()
    {
        if (!mano.isSelected) return;

        if (Input.GetKeyDown(KeyCode.M))
        {
            arrow.PrepareArrow();
            _wasPressed = true;
        }
        
        if (Input.GetKeyUp(KeyCode.M))
        {
            arrow.ReleaseArrow(1);
            _wasPressed = false;
        }



    }
}
