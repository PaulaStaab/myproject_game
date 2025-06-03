using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer an;

    public void SetVolume(string groupName, float volume)
    {
        an.SetFloat(groupName + "Volume", volume);
    }
    public void SetAmbienteVolume(float volume)
    {
        an.SetFloat("AmbienteVolume", volume);
    } 
    
    public void SetMasterVolume(float volume)
    {
        an.SetFloat("MasterVolume", volume);
    }
    


