using UnityEngine;

public class ChangeColorEnemyHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] _newEnemy = new GameObject[5];
    public void ChangeColorEnemy(GameObject enemy)
    {
        enemy = _newEnemy[Random.Range(0, _newEnemy.Length)];
        gameObject.SendMessageUpwards("ColorHandler", enemy);
    }
}