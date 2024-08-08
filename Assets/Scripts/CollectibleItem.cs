using UnityEngine;
using UnityEngine.Events;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private string _scoreCollectid;

    private AudioSource _audio;

    public event UnityAction<string> Score;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player player))
        {
            Score?.Invoke(_scoreCollectid);
            Destroy(gameObject);
        }
    }
}


