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
		if(CurrentTrack != Tracks.Count - 1)
		{
			Tracks[CurrentTrack].Stop();
			CurrentTrack++;
			Play();
		}
	}

	public void PrevTrack()
	{
		if(CurrentTrack != 0)
		{
			Tracks[CurrentTrack].Stop();
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
