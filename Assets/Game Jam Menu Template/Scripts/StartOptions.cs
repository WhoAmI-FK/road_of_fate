using UnityEngine;
using System.Collections;
using UnityEngine.Audio;


public class StartOptions : MonoBehaviour {



	public bool changeScenes;											// UI and continue in single scene
	public int sceneToStart = 1;										//true
	public bool changeMusicOnStart;										//clip
	public int musicToChangeTo = 0;										//is true.


	[HideInInspector] public bool inMainMenu = true;					//r, default escape key)
	[HideInInspector] public Animator animColorFade; 					//ng game.
	[HideInInspector] public Animator animMenuAlpha;					//group
	[HideInInspector] public AnimationClip fadeColorAnimationClip;		//
	[HideInInspector] public AnimationClip fadeAlphaAnimationClip;		//U elements alpha


	private PlayMusic playMusic;										//it
	private float fastFadeIn = .01f;									//iately without a click/glitch
	private ShowPanels showPanels;										//anels

	
	void Awake()
	{
		//Get a reference to ShowPanels attached to UI object
		showPanels = GetComponent<ShowPanels> ();

		//Get a reference to PlayMusic attached to UI object
		playMusic = GetComponent<PlayMusic> ();
	}


	public void StartButtonClicked()
	{
		//If changeMusicOnStart is true, fade out volume of music group of AudioMixer by calling FadeDown function of PlayMusic, using length of fadeColorAnimationClip as time. 
		//To change fade time, change length of animation "FadeToColor"
		if (changeMusicOnStart) 
		{
			playMusic.FadeDown(fadeColorAnimationClip.length);
			Invoke ("PlayNewMusic", fadeAlphaAnimationClip.length);
		}

		//If changeScenes is true, start fading and change scenes halfway through animation when screen is blocked by FadeImage
		if (changeScenes) 
		{
			//Use invoke to delay calling of LoadDelayed by half the length of fadeColorAnimationClip
			Invoke ("LoadDelayed", fadeColorAnimationClip.length * .5f);

			//Set the trigger of Animator animColorFade to start transition to the FadeToOpaque state.
			animColorFade.SetTrigger ("fade");
		} 

		//If changeScenes is false, call StartGameInScene
		else 
		{
			//Call the StartGameInScene function to start game without loading a new scene.
			StartGameInScene();
		}

	}


	public void LoadDelayed()
	{
		//Pause button now works if escape is pressed since we are no longer in Main menu.
		inMainMenu = false;

		//Hide the main menu UI element
		showPanels.HideMenu ();

		//Load the selected scene, by scene index number in build settings
		Application.LoadLevel (sceneToStart);
	}


	public void StartGameInScene()
	{
		//Pause button now works if escape is pressed since we are no longer in Main menu.
		inMainMenu = false;

		//If changeMusicOnStart is true, fade out volume of music group of AudioMixer by calling FadeDown function of PlayMusic, using length of fadeColorAnimationClip as time. 
		//To change fade time, change length of animation "FadeToColor"
		if (changeMusicOnStart) 
		{
			//Wait until game has started, then play new music
			Invoke ("PlayNewMusic", fadeAlphaAnimationClip.length);
		}
		//Set trigger for animator to start animation fading out Menu UI
		animMenuAlpha.SetTrigger ("fade");

		//Wait until game has started, then hide the main menu
		Invoke("HideDelayed", fadeAlphaAnimationClip.length);

		Debug.Log ("Game started in same scene! Put your game starting stuff here.");


	}


	public void PlayNewMusic()
	{
		//Fade up music nearly instantly without a click 
		playMusic.FadeUp (fastFadeIn);
		//Play music clip assigned to mainMusic in PlayMusic script
		playMusic.PlaySelectedMusic (musicToChangeTo);
	}

	public void HideDelayed()
	{
		//Hide the main menu UI element
		showPanels.HideMenu();
	}
}
