using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PlayMusic : MonoBehaviour {
	
	public AudioClip[] musicClips;					
	public AudioMixerSnapshot volumeDown;			
	public AudioMixerSnapshot volumeUp;				


	private AudioSource musicSource;				

	void Awake () 
	{
		//Get a component reference to the AudioSource attached to the UI game object
		musicSource = GetComponent<AudioSource> ();
	}
	
	//Used if running the game in a single scene, takes an integer music source allowing you to choose a clip by number and play.
	public void PlaySelectedMusic(int musicChoice)
	{
		//Play the music clip at the array index musicChoice
		musicSource.clip = musicClips [musicChoice];

		//Play the selected clip
		musicSource.Play ();
	}

	//Call this function to very quickly fade up the volume of master mixer
	public void FadeUp(float fadeTime)
	{
		//call the TransitionTo function of the audioMixerSnapshot volumeUp;
		volumeUp.TransitionTo (fadeTime);
	}

	//Call this function to fade the volume to silence over the length of fadeTime
	public void FadeDown(float fadeTime)
	{
		//call the TransitionTo function of the audioMixerSnapshot volumeDown;
		volumeDown.TransitionTo (fadeTime);
	}
}
