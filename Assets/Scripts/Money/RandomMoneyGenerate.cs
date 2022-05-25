using System.Collections.Generic;
using UnityEngine;

public class RandomMoneyGenerate : MonoBehaviour
{
    [SerializeField] private List<Vector3> spawnPositions;
    [SerializeField] private GameObject monet;

    private int countMonetInOnePrefab;

    private void Start()
    {
        countMonetInOnePrefab = Random.Range(0, 3);
        for (int i = 0; i < countMonetInOnePrefab; i++)
        {
            SpawnMoneyOnRandomPosition();
        }
    }

    private void SpawnMoneyOnRandomPosition()
    {
        GameObject _monet = Instantiate(monet);
        int randomIndexPosition = Random.Range(0, spawnPositions.Count);
        Vector3 monetPosition = spawnPositions[randomIndexPosition];
        spawnPositions.RemoveAt(randomIndexPosition);
        _monet.transform.parent = transform;
        _monet.transform.localPosition = monetPosition;
    }
}
