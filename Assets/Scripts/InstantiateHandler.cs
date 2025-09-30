using System.Collections.Generic;
using UnityEngine;

public class InstantiateHandler : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints = new Transform[7];
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _allSpawnedGO;
    [SerializeField] private GameObject _ball;
    [SerializeField] private float _force;

    private GameObject _player;
    private Transform _spawnPoint;
    private GameObject _go;
    private List<GameObject> _instEnemiesList = new List<GameObject>();

    private int _enemiesCount;
    public int EnemiesCount => _enemiesCount;

    private void Start()
    {
        _player = GameObject.Find("Player");

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoint = _spawnPoints[i];
            _go = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.Euler(new Vector3(0, 45, 0)), _allSpawnedGO.transform);
            _go.transform.LookAt(_player.transform);
            _instEnemiesList.Add(_go);
        }
    }

    private void Update()
    {
        int ballDamage = PlayerPrefs.GetInt("Health");

        foreach (GameObject enemy in _instEnemiesList)
        {
            if (enemy != null)
            {
                if (enemy.GetComponent<HealthHandler>().Health == ballDamage)
                {
                    int j = _instEnemiesList.IndexOf(enemy);
                    _instEnemiesList[j] = null;

                    DestroyImmediate(enemy);

                    _enemiesCount++;

                    SpawnOneObj(enemy);
                }
            }
        }
    }

    public void SpawnOneObj(GameObject go)
    {
        foreach (GameObject deletedEnemy in _instEnemiesList)
        {
            if (deletedEnemy == null)
            {
                int j = _instEnemiesList.IndexOf(deletedEnemy);

                _spawnPoint = _spawnPoints[j];

                gameObject.BroadcastMessage("ChangeColorEnemy", _enemyPrefab, SendMessageOptions.DontRequireReceiver);

                go = Instantiate(ColorHandler(_enemyPrefab), _spawnPoint.position, Quaternion.Euler(new Vector3(0, 45, 0)), _allSpawnedGO.transform);
                go.transform.LookAt(_player.transform);

                _instEnemiesList.Insert(j, go);
            }
        }
    }

    public GameObject ColorHandler(GameObject recievedEnemy)
    {
        _enemyPrefab = recievedEnemy;
        return recievedEnemy;
    }
}