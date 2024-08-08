using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private CollectibleItem _ball;

    private void OnEnable()
    {
        _ball.Score += OnCollectible;
    }

    private void OnDisable()
    {
        _ball.Score -= OnCollectible;
    }

    private void OnCollectible(string Size)
    {
        _view.text = Size.ToString();
        
    }

   
}

