using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kontrol : MonoBehaviour
{
    
    SpriteRenderer spriteRenderer;
    Rigidbody2D fizik;
    OyunKontrol oyunKontrol;
    AudioSource []sesler;

    public Sprite[] KusSprite;
    public Text puanText;
    

    bool ileriGeriKontrol = true;
    bool oyunBitti = true;

    int enYuksekPuan = 0;
    int kusSayac = 0;
    int puan = 0;
    int reklamSayaci = 0;
    float kusAnimasyonZaman = 0;

   
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<OyunKontrol>();
        sesler = GetComponents<AudioSource>();
        enYuksekPuan = PlayerPrefs.GetInt("enYuksekPuankayit");

        reklamSayaci = PlayerPrefs.GetInt("reklamSayaci");
        reklamSayaci++;
        PlayerPrefs.SetInt("reklamSayaci", reklamSayaci);

    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && oyunBitti)
        {
            fizik.velocity = new Vector2(0, 0);
            fizik.AddForce(new Vector2(0,200));
            sesler[0].Play();
        }
        if (fizik.velocity.y>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }
        Animasyon();
    }

    void Animasyon()
    {
        kusAnimasyonZaman += Time.deltaTime;
        if (kusAnimasyonZaman > 0.2f)
        {
            kusAnimasyonZaman = 0;
            if (ileriGeriKontrol)
            {
                spriteRenderer.sprite = KusSprite[kusSayac];
                kusSayac++;
                if (kusSayac == KusSprite.Length)
                {
                    kusSayac--;
                    ileriGeriKontrol = false;
                }
            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = KusSprite[kusSayac];
                if (kusSayac == 0)
                {
                    kusSayac++;
                    ileriGeriKontrol = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "puan")
        {
            puan++;
            puanText.text = "SKOR = " + puan;
            sesler[1].Play();
        }
        if (collision.gameObject.tag=="engel")
        {

            oyunBitti = false;
            sesler[2].Play();
            oyunKontrol.OyunBitti();
            GetComponent<CircleCollider2D>().enabled = false;

            if (puan>enYuksekPuan)
            {
                enYuksekPuan = puan;
                PlayerPrefs.SetInt("enYuksekPuankayit", enYuksekPuan);
            }
            Invoke("anaMenuyeDon", 2);
        }
    }

    void anaMenuyeDon()
    {
        PlayerPrefs.SetInt("puankayit", puan);
        SceneManager.LoadScene("mainMenu");
    }
}
