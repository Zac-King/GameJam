using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Mixer : MonoBehaviour 
{
	public List<AudioSource>Tracks = new List<AudioSource>();
	public Text trackName;
	public int CurrentTrack = 0;
	// Use this for initialization
	void Start () 
	{
		Tracks.AddRange(GetComponentsInChildren<AudioSource>());
	}

	public void SkipTrack()
	{
		Tracks[CurrentTrack].Stop();
		if(CurrentTrack + 1 != Tracks.Count)
		{
			CurrentTrack++;
			Play();
		}
	}

	public void PrevTrack()
	{
		Tracks[CurrentTrack].Stop();
		if(CurrentTrack - 1 <= 0)
		{
			CurrentTrack--;
			Play();
		}
	}

	public void Play()
	{
		Tracks[CurrentTrack].Play();
		trackName.text = Tracks[CurrentTrack].clip.name;
	}

	public void Pause()
	{
		Tracks[CurrentTrack].Pause();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
