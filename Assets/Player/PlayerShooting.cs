using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPlayerPrefab;
    [SerializeField] Transform aim;
    [SerializeField] AudioClip shootBulletAudio;
    [SerializeField] [Range(10,50)] float bulletSpeed = 16f;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        GetUserInput();
    }

    void GetUserInput(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
    }

    void Shoot(){
        if(bulletPlayerPrefab != null){
            GameObject g = Instantiate(bulletPlayerPrefab, aim.transform.position, Quaternion.identity);
            g.GetComponent<BulletPlayer>().Initialize(aim.right, bulletSpeed);
            if(shootBulletAudio != null){
                audioSource.clip = shootBulletAudio;
                audioSource.Play();
            }
        }
    }
}
