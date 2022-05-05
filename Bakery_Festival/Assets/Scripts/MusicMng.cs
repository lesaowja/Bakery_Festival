using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
public class MusicMng : MonoBehaviour
{

    int SongNum = 0;

    AudioSource MusicPlayer;

    void Start()
    {
        MusicPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
