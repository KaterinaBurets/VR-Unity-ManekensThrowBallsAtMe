using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private OnBallPickedUpHandler _onBallPickedUpHandlerClass;
    public int Health => _health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (other.GetComponent<OnBallPickedUpHandler>().IsPickedUp == true)
            {
                _health--;
                PlayerPrefs.SetInt("Health", _health);
                Destroy(other.gameObject);
            }
        }
    }
}