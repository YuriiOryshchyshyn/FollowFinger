using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform finger;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = finger.transform.position;
    }

    private void Update()
    {
        GetComponent<Text>().text = $"--------\n{Convert.ToInt32((finger.position.y - _startPosition.y)) / 2}cm";
    }
}
