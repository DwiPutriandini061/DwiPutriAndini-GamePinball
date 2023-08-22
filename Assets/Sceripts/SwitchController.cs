using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }
    // menyimpan variabel bola sebagai referensi untuk pengecekan
    public Collider bola;
    // menyimpan variabel material nyala dan mati untuk merubah warna
    public Material offMaterial;
    public Material onMaterial;
    // komponen renderer pada object yang akan diubah
    private Renderer renderer;
    private SwitchState state;
    //score
    public ScoreManager scoreManager;
    public float score;

    public AudioManager audioManager;
    public VFXManager VFXManager;
    private void Start()
    {
        // ambil renderernya
        renderer = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(BlinkTimerStart(5));

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();


            // kita jalankan SFX saat tabrakan dengan bola pada posisi tabrakannya
            audioManager.SwitchSFX(collision.transform.position);
            //score
            scoreManager.AddScore(5);


        }
    }


    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }
    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }

    }
    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
