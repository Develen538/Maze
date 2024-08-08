using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private AudioClip Key;

    private CharacterController _controller;
    private AudioSource _audio;
    
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        
        moveDirection.y -= 9.81f * Time.deltaTime;

        _controller.Move(moveDirection * _moveSpeed * Time.deltaTime);

        SoundMove();
    }

   private void SoundMove()
   {

        if (Input.GetKeyDown(KeyCode.W))
        {
            _audio.Play();
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            _audio.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out CollectibleItem item))
        {
            _audio.PlayOneShot(Key);
        }
    }
}
