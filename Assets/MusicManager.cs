using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> tracks;
    
    private void Start()
    {
        foreach (var track in Resources.LoadAll<AudioClip>("tracks").ToList())
        {
            tracks.Add(track);
        }
    }
}
