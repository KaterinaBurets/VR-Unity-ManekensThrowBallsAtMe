using UnityEngine;

public class BallMovingHandler : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _whereInstantiate;

    public void BallAppearanceHandler()
    {
        GameObject newBall = Instantiate(_ball, _whereInstantiate.transform.position, Quaternion.identity, gameObject.transform);

        newBall.GetComponent<Rigidbody>().AddForce((GameObject.Find("Player").transform.position - transform.position).normalized * _force, ForceMode.Impulse);

        Destroy(newBall, 10);
    }
}