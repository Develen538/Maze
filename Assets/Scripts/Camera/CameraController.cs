using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _maxYAngle;
    [SerializeField] private GameObject _plane;

    private AudioSource _audio;
    private float _rotationX = 0.0f;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Controler();
        Pause();
    }

    private void Controler()
    {
        float mouseX = Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(1))
        {
            transform.parent.Rotate(Vector3.up * mouseX * _sensitivity);

            _rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);
            transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
        }
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _audio.Play();
            _plane.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _audio.Play();
            _plane.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(0);
        }
    }
}
