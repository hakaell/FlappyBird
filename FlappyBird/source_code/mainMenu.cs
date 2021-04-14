using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public Text enYuksekpuanText;
    public Text puanText;
    void Start()
    {
        int enYuksekPuan = PlayerPrefs.GetInt("enYuksekPuankayit");
        int Puan = PlayerPrefs.GetInt("puankayit");
        int reklamSayaci = PlayerPrefs.GetInt("reklamSayaci");

        enYuksekpuanText.text = "En Yüksek Puan = " + enYuksekPuan;
        puanText.text = "Puan = " + Puan;

        if (reklamSayaci==3)
        {
            GameObject.FindGameObjectWithTag("reklam").GetComponent<reklam>().reklamiGoster();
            PlayerPrefs.SetInt("reklamSayaci", 0);
        }
        
        
    }

    
    void Update()
    {
        
    }

    public void oyunaGit()
    {
        SceneManager.LoadScene("level 1");
    }
    public void oyundanCik()
    {
        Application.Quit();
    }
}
