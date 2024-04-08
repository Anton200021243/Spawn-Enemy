using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyMove[] _enemy;

    [SerializeField] private Transform _point;
    [SerializeField] private Transform _target;

    private Transform[] _spawnPoints;
    private Transform[] _targets;

    private float _delayForSpawn = 1.0f;
    private float _spawnRate = 2.0f;

    private void Awake()
    {
        _spawnPoints = FillArray(_spawnPoints, _point);
        _targets = FillArray(_targets, _target);
    }

    private Transform[] FillArray(Transform[] array, Transform point)
    {
        array = new Transform[point.childCount];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = point.GetChild(i);
        }

        return array;
    }

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), _delayForSpawn, _spawnRate);
    }

    private void Spawn()
    {
        int randomEnemy = Random.Range(0, _enemy.Length);
        Vector3 offset = Vector3.up;

        var enemy = Instantiate(_enemy[randomEnemy], _spawnPoints[randomEnemy].transform.position + offset, Quaternion.identity);

        enemy.SetTarget(_targets[randomEnemy]);
    }
}
