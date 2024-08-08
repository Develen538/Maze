using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ceiling _ceiling;

    private void Start()
    {
        Build();
    }

    private Ceiling Build()
    {
       return Instantiate(_ceiling, transform.position,Quaternion.identity);
    }
}
