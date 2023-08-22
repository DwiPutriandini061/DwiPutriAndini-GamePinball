using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public GameObject sfxAudioSource;

    private void Start()
    {
        // jalankan BGM saat game dimulai
        PlayBGM();
    }

    // fungsi yang disiapkan untuk perintah menjalankan bgm dari script lain
    private void PlayBGM()
    {
        bgmAudioSource.Play();
    }
    // fungsi yang disiapkan untuk perintah menjalankan sfx dari script lain
    // ini tidak di jalankan pada script ini, tapi nanti di jalankan pada script bumpernya
    public void PlaySFX(Vector3 spawnPosition)
    {
        // berbeda dengan bgm, disini kita buat script untuk 
        // memunculkan prefabnya pada posisi sesuai dengan parameternya
        GameObject.Instantiate(sfxAudioSource, spawnPosition, Quaternion.identity);
    }
    public void SwitchSFX(Vector3 spawnPosition)
    {
        // berbeda dengan bgm, disini kita buat script untuk 
        // memunculkan prefabnya pada posisi sesuai dengan parameternya
        GameObject.Instantiate(sfxAudioSource, spawnPosition, Quaternion.identity);
    }
}
