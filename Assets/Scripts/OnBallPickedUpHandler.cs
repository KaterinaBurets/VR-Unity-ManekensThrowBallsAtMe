using UnityEngine;
using Valve.VR.InteractionSystem;

public class OnBallPickedUpHandler : MonoBehaviour
{
    private Throwable _throwable;
    private bool _isPickedUp = false;
    public bool IsPickedUp => _isPickedUp;
   
    private void Start()
    {
        _throwable = this.GetComponent<Throwable>();
    }
    
    public void OnPickUp()
    {
        _isPickedUp = true;
    }
}