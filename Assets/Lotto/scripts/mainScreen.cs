using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using GoogleMobileAds.Api;

public class mainScreen : MonoBehaviour {


	 int currentGamePlaying;
	 Animator menuButtons;
	 Animator startAnimator;
	Animator MMGameAnimator;
	Animator historyAni;

	bool startClicked=false;
	 public Text Day;
	 public Text Month;
	 public Text Year;

	 public Text debugtxt;

	[HideInInspector]
	static public int month;
	[HideInInspector]
	static public int day;
	[HideInInspector]
	static public int year;
	int agree=0;

	GameObject toggleBackdrop1;
	GameObject toggleBackdrop2;
	GameObject toggleBackdrop3;

	public AudioClip popSnd;

	public AudioClip menuSelect;


	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("firstTime", 0); //uncomment to Reset First Time
		string appID = "Appid"; //
		MobileAds.Initialize (appID);
		string readFilePath="";
		string p="";

		if(PlayerPrefs.GetInt("backdrop")==1)
		GameObject.Find ("backDrop").GetComponent<Image> ().sprite=Resources.Load("backDrop1", typeof(Sprite)) as Sprite;
		if(PlayerPrefs.GetInt("backdrop")==2)
			GameObject.Find ("backDrop").GetComponent<Image> ().sprite=Resources.Load("backDrop2", typeof(Sprite)) as Sprite;
		if(PlayerPrefs.GetInt("backdrop")==3)
			GameObject.Find ("backDrop").GetComponent<Image> ().sprite=Resources.Load("backDrop3", typeof(Sprite)) as Sprite;


		#if UNITY_ANDROID && !UNITY_EDITOR
	
		p=Application.persistentDataPath;
		string file=p+"/lottoGS1.txt";
		if(!System.IO.File.Exists(file))
		{
		File.CreateText(p+"/lottoGS1.txt");



		}else{ }
	

		#endif

		//pub-3324188928461575
		//#if UNITY_ANDROID
		BannerView BV= new BannerView("ca-app-pub-3324188928461575/1285574780",AdSize.Banner,AdPosition.Top);

		AdRequest r=new AdRequest.Builder().Build();

		BV.LoadAd(r);			//Load Ad in the update



	//	#if UNITY_EDITOR && !UNITY_ANDROID
		//readFilePath = Application.dataPath.ToString () + @"/lottoGS1.txt";
	//	if(!System.IO.File.Exists(readFilePath))
	//	{
	//		File.CreateText(readFilePath);



	//	}else{ }

	//#endif



	
		day = System.DateTime.Now.Day;
		month = System.DateTime.Now.Month;
		year = System.DateTime.Now.Year;
		//Debug.Log(day.ToString()+","+ month.ToString()+","+year.ToString());
		Day.text=day.ToString()+"/";
		Month.text = month.ToString ()+"/";
		Year.text = year.ToString ();
		//globalVar.firstTimeRun = PlayerPrefs.GetInt ("firstTime");
		//	Debug.Log("FirstRun :"+globalVar.firstTimeRun.ToString());

		agree=PlayerPrefs.GetInt ("agree1");
		if (agree == 1)
		{
			agreeButton ();
			enableButtons ();
		}
		if (agree == 0)
		{
			GameObject.Find ("disclamierWin").transform.localPosition = new Vector3 (0, 0, 0);
			disableButtons ();
		}


		toggleBackdrop1 = GameObject.Find ("BPBackToggle");
		toggleBackdrop2 = GameObject.Find ("RGBackToggle");
		toggleBackdrop3 = GameObject.Find ("YBBackToggle");
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void showDisclamier()
	{
		GameObject.Find ("disclamierWin").transform.localPosition = new Vector3 (0, 0, 1);
		disableButtons ();
	}

    public void showPrivacyPolicy()
    {
        Application.OpenURL("http://squashy.games/ppDoc/mobile-privacy-policy-SQ.html");
    }
	public void changeToBPBackDrop()
	{
		//if (toggleBackdrop1.GetComponent<Toggle> ().isOn ==false) 
		//{
			
			GameObject.Find ("backDrop").GetComponent<Image> ().sprite=Resources.Load("backDrop1", typeof(Sprite)) as Sprite;
			toggleBackdrop2.GetComponent<Toggle> ().isOn = false;
			toggleBackdrop3.GetComponent<Toggle> ().isOn = false;
			PlayerPrefs.SetInt ("backdrop", 1);

		//}
	}

	public void changeToRBBackDrop()
	{
		

			GameObject.Find ("backDrop").GetComponent<Image> ().sprite=Resources.Load("backDrop2", typeof(Sprite)) as Sprite;
			toggleBackdrop1.GetComponent<Toggle> ().isOn = false;
			toggleBackdrop3.GetComponent<Toggle> ().isOn = false;
			PlayerPrefs.SetInt ("backdrop", 2);
			
	//	}
	}
	public void changeToYBBackDrop()
	{

			
			GameObject.Find ("backDrop").GetComponent<Image> ().sprite=Resources.Load("backDrop3", typeof(Sprite)) as Sprite;
			toggleBackdrop1.GetComponent<Toggle> ().isOn = false;
			toggleBackdrop2.GetComponent<Toggle> ().isOn = false;
			PlayerPrefs.SetInt ("backdrop", 3);

	}

	void disableButtons()
	{
		GameObject.Find ("menubutt").GetComponent<Button> ().interactable = false;
		GameObject.Find ("settingsbutt").GetComponent<Button> ().interactable = false;
		GameObject.Find ("historybutt").GetComponent<Button> ().interactable = false;
	}
	void enableButtons()
	{
		GameObject.Find ("menubutt").GetComponent<Button> ().interactable = true;
		GameObject.Find ("settingsbutt").GetComponent<Button> ().interactable = true;
		GameObject.Find ("historybutt").GetComponent<Button> ().interactable = true;
	}

	 public void showMenuButtons()
	{
		GameObject.Find ("settingsbutt").GetComponent<Button> ().interactable = true;
		GameObject.Find ("historybutt").GetComponent<Button> ().interactable = true;
	
		AudioSource.PlayClipAtPoint (menuSelect, Vector3.zero);
		GameObject.Find ("historybutt").GetComponent<Button> ().enabled = true;
		if (currentGamePlaying == 1   ) {
			hideMMGame ();
			menuButtons = GameObject.Find ("buttonsPanel").GetComponent<Animator> ();
			menuButtons.enabled = true;
			menuButtons.Play ("menuSlide");

		}

		if (currentGamePlaying == 2   ) {
			hidePWRBGame();
			menuButtons = GameObject.Find ("buttonsPanel").GetComponent<Animator> ();
			menuButtons.enabled = true;
			menuButtons.Play ("menuSlide");

		}
		if (currentGamePlaying == 3   ) {
			hideCFLGame();
			menuButtons = GameObject.Find ("buttonsPanel").GetComponent<Animator> ();
			menuButtons.enabled = true;
			menuButtons.Play ("menuSlide");

		}
		if (currentGamePlaying == 4   ) {
			hideTNCGame();
			menuButtons = GameObject.Find ("buttonsPanel").GetComponent<Animator> ();
			menuButtons.enabled = true;
			menuButtons.Play ("menuSlide");

		}
		if (startClicked == false || globalVar.showingHistory==true) {
			menuButtons = GameObject.Find ("buttonsPanel").GetComponent<Animator> ();
			menuButtons.enabled = true;
			menuButtons.Play ("menuSlide");
			startAnimator = GameObject.Find ("startImgbutt").GetComponent<Animator> ();
			startAnimator.enabled = true;
			startAnimator.Play ("startSlide");
			startClicked = true;


			globalVar.showingHistory = false;
		}
		historyAni = GameObject.Find ("HistoryScrollView").GetComponent<Animator> ();
		historyAni.enabled = true;
		historyAni.Play ("historySlideOut");
	}

	public void showMMGame()
	{
		currentGamePlaying = 1;
		menuButtons = GameObject.Find ("buttonsPanel").GetComponent<Animator> ();
		menuButtons.enabled = true;
		menuButtons.Play ("menuSlideOut");

		MMGameAnimator = GameObject.Find ("megaMillPanel").GetComponent<Animator> ();
		MMGameAnimator.enabled = true;
		MMGameAnimator.Play ("showMMGame");
		AudioSource.PlayClipAtPoint (menuSelect, Vector3.zero);
		GameObject.Find ("settingsbutt").GetComponent<Button> ().interactable = false;
		GameObject.Find ("historybutt").GetComponent<Button> ().interactable = false;
	}

	public void hideMMGame()
	{
		MMGameAnimator = GameObject.Find ("megaMillPanel").GetComponent<Animator> ();
		MMGameAnimator.enabled = true;
		MMGameAnimator.Play ("hideMMGame");
	}

	 public void hidePWRBGame()
	{
		MMGameAnimator = GameObject.Find ("PowerBPanel").GetComponent<Animator> ();
		MMGameAnimator.enabled = true;
		MMGameAnimator.Play ("hideMMGame");
	}

	public void showPWRBGame()
	{
		currentGamePlaying = 2;
		menuButtons = GameObject.Find ("buttonsPanel").GetComponent<Animator> ();
		menuButtons.enabled = true;
		menuButtons.Play ("menuSlideOut");

		MMGameAnimator = GameObject.Find ("PowerBPanel").GetComponent<Animator> ();
		MMGameAnimator.enabled = true;
		MMGameAnimator.Play ("showMMGame");
		AudioSource.PlayClipAtPoint (menuSelect, Vector3.zero);
		GameObject.Find ("settingsbutt").GetComponent<Button> ().interactable = false;
		GameObject.Find ("historybutt").GetComponent<Button> ().interactable = false;
	}

	public void showCFLGame()
	{
		currentGamePlaying = 3;
		menuButtons = GameObject.Find ("buttonsPanel").GetComponent<Animator> ();
		menuButtons.enabled = true;
		menuButtons.Play ("menuSlideOut");

		MMGameAnimator = GameObject.Find ("CashLifePanel").GetComponent<Animator> ();
		MMGameAnimator.enabled = true;
		MMGameAnimator.Play ("showMMGame");
		AudioSource.PlayClipAtPoint (menuSelect, Vector3.zero);
		GameObject.Find ("settingsbutt").GetComponent<Button> ().interactable = false;
		GameObject.Find ("historybutt").GetComponent<Button> ().interactable = false;
	}

	 public void hideCFLGame()
	{
		MMGameAnimator = GameObject.Find ("CashLifePanel").GetComponent<Animator> ();
		MMGameAnimator.enabled = true;
		MMGameAnimator.Play ("hideMMGame");
	}

	public void showTNCGame()
	{
		currentGamePlaying = 4;
		menuButtons = GameObject.Find ("buttonsPanel").GetComponent<Animator> ();
		menuButtons.enabled = true;
		menuButtons.Play ("menuSlideOut");

		MMGameAnimator = GameObject.Find ("TNCashPanel").GetComponent<Animator> ();
		MMGameAnimator.enabled = true;
		MMGameAnimator.Play ("showMMGame");
		AudioSource.PlayClipAtPoint (menuSelect, Vector3.zero);
		GameObject.Find ("settingsbutt").GetComponent<Button> ().interactable = false;
		GameObject.Find ("historybutt").GetComponent<Button> ().interactable = false;
	}

	public void hideTNCGame()
	{
		MMGameAnimator = GameObject.Find ("TNCashPanel").GetComponent<Animator> ();
		MMGameAnimator.enabled = true;
		MMGameAnimator.Play ("hideMMGame");
	}

	public void exitApp()
	{
		Application.Quit ();
	}

	public void agreeButton()
	{
		showMenuButtons ();
		GameObject.Find ("disclamierWin").transform.position = new Vector3 (0, -1000, 0);
		if (GameObject.Find ("agreeToggle").GetComponent<Toggle> ().isOn == true) {
			PlayerPrefs.SetInt ("agree1", 1);

		} 
		enableButtons ();
		AudioSource.PlayClipAtPoint (menuSelect, Vector3.zero);
	}

	public void activateDisclamier()
	{
		PlayerPrefs.SetInt("agree1",0);
	}

	public void showSettingWindow()
	{
		GameObject SW = GameObject.Find ("settingsWin");
		SW.transform.localPosition = new Vector3 (0, 0, 0);
		globalVar.showingSettings = true;
		AudioSource.PlayClipAtPoint (menuSelect, Vector3.zero);
	}

	public void hideSettingsWindow()
	{

		GameObject SW = GameObject.Find ("settingsWin");
		SW.transform.localPosition = new Vector3 (-200, -2600, 0);
		globalVar.showingSettings = false;
		
	}

	public void showHowTo()
	{
		GameObject.Find ("howtoWin").gameObject.transform.localPosition = new Vector3 (0, -50, 0);
	}

	public void closeHowTo()
	{
		GameObject.Find ("howtoWin").gameObject.transform.localPosition = new Vector3 (0, -4000, 0);
	}
}


