using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _enemyPrefab;
    [SerializeField] private Transform _point;
    [SerializeField] private Transform[] _spawnPoints;

    private float _delayForSpawn = 2;
    private float _spawnRate = 2;

    private void Awake()
    {
        _spawnPoints = _point.GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), _delayForSpawn, _spawnRate);
    }

    private void Spawn()
    {
        int spawnRandom = Random.Range(0, _spawnPoints.Length);
        Vector3 offset = Vector3.up;

        Instantiate(_enemyPrefab, _spawnPoints[spawnRandom].transform.position + offset, Quaternion.identity);
    }
}
