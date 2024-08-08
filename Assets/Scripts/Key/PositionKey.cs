using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private float t = 0;
    [SerializeField] private float Amp = 0.25f;
    [SerializeField] private float Freq = 2;
    [SerializeField] private float Offset = 0;
    [SerializeField] private Vector3 StartPos;

    private void Start()
    {
        StartPos = transform.position;
    }

    private void Update()
    {
        t = t + Time.deltaTime;
        Offset = Amp * Mathf.Sin(t * Freq);

        transform.position = StartPos + new Vector3(0, Offset, 0);

        transform.Rotate(new Vector3(0, 0.5f, 0));
    }
}
