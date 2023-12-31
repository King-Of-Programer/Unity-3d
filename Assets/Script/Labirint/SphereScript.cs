using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
   // [SerializeField]
    private GameObject _camera;
    [SerializeField]
    private GameObject cameraAnchor;

    private Rigidbody body;
    private float forceFactor = 400f;
    private Vector3 anchorOffset;

    private AudioSource collectSound;
    private AudioSource backgroundMusic;
    private bool isMuted;
    private static SphereScript instance = null;
    void Start()
    {
        if (instance != null)
        {
            this.transform.position += new Vector3(0, instance.transform.position.y, 0);
            GameObject.Destroy(instance.gameObject);
            
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        _camera = Camera.main.gameObject;
        
        body = GetComponent<Rigidbody>();

        anchorOffset = this.transform.position -
            cameraAnchor.transform.position;

        AudioSource[] audioSources = GetComponents<AudioSource>();
        collectSound = audioSources[0];
        backgroundMusic = audioSources[1];
        backgroundMusic.ignoreListenerVolume = false;
        isMuted = LabirintState.isSoundsMuted;
        if (!LabirintState.isSoundsMuted)
        {
            //backgroundMusic.volume = MazeState.musicVolume;
            backgroundMusic.Play();
        }
        LabirintState.AddNotifyListener(OnMazeStateChanged);
    }

    void Update()
    {
        //_camera = Camera.main.gameObject;
        
        float kh = Input.GetAxis("Horizontal");
        float kv = Input.GetAxis("Vertical");

        Vector3 right = _camera.transform.right;
        Vector3 forward = _camera.transform.forward;
        forward.y = 0;
        forward = forward.normalized;


        Vector3 forceDirection = //new Vector3(kh, 0, kv); - World space
            kh * right + kv * forward;

        forceDirection = forceDirection.normalized;

        body.AddForce(forceFactor * Time.deltaTime * forceDirection);
        cameraAnchor.transform.position = this.transform.position - anchorOffset;
        /*if (MazeState.isSoundsMuted != isMuted)
        {
            isMuted = MazeState.isSoundsMuted;
            backgroundMusic.mute = isMuted;
            collectSound.mute = isMuted;
        }*/
        /*if (backgroundMusic.volume != MazeState.musicVolume&&!MazeState.isSoundsMuted)
        {
            backgroundMusic.Pause();
            backgroundMusic.volume = MazeState.musicVolume;
            backgroundMusic.Play();
        }*/       /*if (collectSound.volume != MazeState.effectsVolume && !MazeState.isSoundsMuted)
        {
            collectSound.volume = MazeState.musicVolume;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("SphereScript: " + other.name);
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            if (!LabirintState.isSoundsMuted)
            {
                collectSound.volume = LabirintState.effectsVolume;
                collectSound.Play();
            }
        }
    }
    private void OnDestroy()
    {
        LabirintState.RemoveNotifyListener(OnMazeStateChanged);
    }

    private void OnMazeStateChanged(string propertyName)
    {
        if (propertyName == nameof(LabirintState.musicVolume))
        {
            Debug.Log("OnMazeStateChanged: " + propertyName);
            //if (backgroundMusic.volume != MazeState.musicVolume && !MazeState.isSoundsMuted)
            //{
            //    backgroundMusic.volume = MazeState.musicVolume;
            //}
        }
    }
}
