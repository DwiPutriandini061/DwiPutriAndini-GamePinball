using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    public float score;

    private Renderer renderer;
    private Animator animator;

    public AudioManager audioManager;
    public VFXManager VFXManager;

    public ScoreManager scoreManager;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        GetComponent<Renderer>().material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            //animasi 
            animator.SetTrigger("hit");

            // kita jalankan SFX saat tabrakan dengan bola pada posisi tabrakannya
            audioManager.PlaySFX(collision.transform.position);
            // playVFX
            VFXManager.PlayVFX(collision.transform.position);
            //score
            scoreManager.AddScore(10);


        }
    }
}
