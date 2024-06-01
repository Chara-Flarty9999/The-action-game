using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knife : MonoBehaviour
{

    SpriteRenderer mesh;
    public Vector2 movement;
    Rigidbody2D rigidbody2d;
    AudioSource audioSource;
    public AudioClip spawn;
    public AudioClip fly;
    public int rote;
    float rotation;
    public float magnification;


    public static Vector2 AngleToVector2(float angle)
    {
        var radian = angle * (Mathf.PI / 180);
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, rote);
        audioSource = GetComponent<AudioSource>();
        mesh = GetComponent<SpriteRenderer>();
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        StartCoroutine("Transparent");
        mesh.material.color -= new Color32(0, 0, 0, 255);
        rigidbody2d.rotation -= 180;

    }

    IEnumerator Transparent()�@//�����ŏ����̋����B�x�N�g�����擾���Ă���B
    {

        audioSource.PlayOneShot(spawn);
        for (int i = 0; i < 30; i++)
        {
            mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 9);
            rigidbody2d.rotation += 6;
            yield return new WaitForSeconds(0.01f);

        }
        yield return new WaitForSeconds(0.1f);
        rotation = transform.localEulerAngles.z;

        movement = AngleToVector2(rotation);
        
        

        //c = 1; //�����Ŕ��ł����������J�n�����悤�ɂȂ��Ă���B

        audioSource.PlayOneShot(fly);

        for (int i = 0; i < 50; i++)
        {
            rigidbody2d.AddForce(movement * new Vector2(magnification, magnification)); //ForceMode2D.Impulse
            yield return new WaitForSeconds(0.01f);
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {

    }
}