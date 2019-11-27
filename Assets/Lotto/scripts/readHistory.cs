using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class readHistory : MonoBehaviour {


	string[] data;
	int linesInFile=0;
	lottocard[] theCards;
	int records=0;
	Animator historyAni;
	bool historyDisplayed=false;
	int recordstoAdd;

	bool animateRecordDelete=false;
	float moveSpeed = 0;
	int accel=0;
	string recordName;

	public AudioClip menuSelect;
	// Use this for initialization
	void Start () {
		
		
	}
	void Awake()
	{
		//readFile ();

	}
	
	float cnt=0;
	bool reload=true;
	// Update is called once per frame
	void Update () {
		//GameObject.Find ("debugtxt").GetComponent<Text> ().text = historyDisplayed.ToString ();
		if (animateRecordDelete == true) 
		{
			
			accel = accel + 45;
			try{
				GameObject g = GameObject.Find (recordName);
				moveSpeed = moveSpeed + accel * Time.deltaTime;
				g.transform.localPosition = new Vector3 (moveSpeed, g.transform.localPosition.y, 0);
			}catch{
			}
		
			if (accel == 2115) {
				reload = true;
				animateRecordDelete = false;

				accel = 0;
				moveSpeed = 0;
				for (int f = 0; f < linesInFile; f++) {
					Destroy (GameObject.Find ("save" + f));
									
				}
				historyDisplayed = false;
						
			}


		}
		if (reload == true) {
			cnt = cnt + 1 * Time.deltaTime;
			if (cnt > 0.4f) {
				
				readFile ();

				reload = false;
				cnt = 0;
			
			}

		}


	}


	void hideButtons()
	{
	     Animator menuButtons = GameObject.Find ("buttonsPanel").GetComponent<Animator> ();
		menuButtons.enabled = true;
		menuButtons.Play ("menuSlideOut");

	}


	 public void showHistory()
	{
		hideButtons ();
		globalVar.showingHistory = true;
		historyAni = GameObject.Find ("HistoryScrollView").GetComponent<Animator> ();
		historyAni.enabled = true;
		historyAni.Play ("historySlideIn");
		GameObject.Find ("historybutt").GetComponent<Button> ().enabled = false;
		readFile ();
		AudioSource.PlayClipAtPoint (menuSelect, Vector3.zero);

	}
	public void readFile()
	{
		string readFilePath="";

		#if UNITY_EDITOR_WIN
		readFilePath = Application.dataPath.ToString () + @"/lottoGS1.txt";
		#endif

		#if UNITY_ANDROID && !UNITY_EDITOR
		string p=Application.persistentDataPath;
		readFilePath=p+"/lottoGS1.txt";
		#endif
	
	StreamReader reader = new StreamReader (readFilePath);

		int numlines = 0;

		records = 0;
		linesInFile = 0;



		while (!reader.EndOfStream)
		{
			
			string lines = reader.ReadLine ();

			linesInFile = linesInFile + 1;

		}
		reader.Close ();
		Debug.Log ("Lines: " + linesInFile.ToString ());

		if (linesInFile > 0) {
			data = new string[linesInFile];

			StreamReader reader2 = new StreamReader (readFilePath);

			while (!reader2.EndOfStream) {
				string lines = "";
				 lines = reader2.ReadLine ();
				data [numlines] = lines;
				numlines = numlines + 1;


			}
			reader2.Close ();

			for (int i = 0; i < linesInFile; i++) {
				//Debug.Log ("first: " + data [i]);
			}

			records = linesInFile;
			recordstoAdd = globalVar.recordsAdded;
			Debug.Log ("Record: "+records.ToString ());
		



				if (globalVar.recordAdded == true) 
				{
					
					globalVar.recordAdded = false;

					theCards = new lottocard[records];
					populateTheCards ();
					
					historyDisplayed = true;
					
					Debug.Log (historyDisplayed.ToString ());
					globalVar.recordsAdded = 0;
				}


			
			if (historyDisplayed == false )
			{
				Debug.Log("record amt : "+records.ToString());
				theCards = new lottocard[records];
				populateTheCards ();
				historyDisplayed = true;
			}


		}
	}

	int m;
	///Take each DATA item and break in down..build a card and add it to the scrollView
	void populateTheCards()
	{

		 m = 0;
		if(recordstoAdd>0)
		m =records-recordstoAdd;
		Debug.Log ("I: " + m.ToString ());
		for (int i=m; i < data.Length; i++) {
				

				theCards[i] = new lottocard();
				
				
					string game = data [i].Substring (0, 3);
				Debug.Log ("Game Type: " + game);
					theCards [i].number1 = data [i].Substring (4,2);
					theCards [i].number2 = data [i].Substring (7, 2);
					theCards [i].number3 = data [i].Substring (10, 2);
					theCards [i].number4 = data [i].Substring (13, 2);
					theCards [i].number5 = data [i].Substring (16, 2);
					theCards [i].number6 = data [i].Substring (19, 2);
					
					string mo=data[i].Substring(22,2); 
					string da=data[i].Substring(25,2);
					string yr=data[i].Substring(28,4); 
					
					theCards[i].date=mo+"/"+da+"/"+yr;

			Debug.Log (game);
				theCards [i].gameName = game;
				

			addACard (game, theCards [i].number1, theCards [i].number2, theCards [i].number3, theCards [i].number4, theCards [i].number5, theCards [i].number6, theCards[i].date,i);
		
			}



	}

	void addACard(string lottoName, string firstNum, string secondNum, string thirdNum, string fourthNum, string fifthNum, string bigNum, string recordDate, int recordNum)
	{
		int ypos = 0;
		GameObject card;
		string save="";
		ypos= 230*recordNum;
		 card = Instantiate (GameObject.Find ("historyCard"));
		card.transform.SetParent (GameObject.Find ("HContent").transform);
		card.transform.localPosition = new Vector3 (0, -ypos, 0);
		Vector3 scaleCard = card.transform.localScale;
		Vector3 scaleHost = card.transform.parent.localScale;
		card.transform.localScale = new Vector3 (scaleHost.x-0.08f, scaleCard.y, scaleCard.z);
		card.name="save"+recordNum.ToString();
		for (int sp = 0; sp < 9; sp++) {
			
			card.gameObject.transform.GetChild (sp).name = card.gameObject.transform.GetChild (sp).name + recordNum.ToString ();
			save = card.gameObject.transform.GetChild (sp).name;
			if (save == "hisBall1" + recordNum.ToString ()) {


				GameObject num1ball = GameObject.Find (save);

				GameObject num1 = num1ball.gameObject.transform.GetChild (0).gameObject;
				Debug.Log ("Testing :" + firstNum);
				num1.GetComponent<Text> ().text = firstNum;

			
			}

				if (save == "hisBall2" + recordNum.ToString ()) {
					
					GameObject num2ball = GameObject.Find (save);

					GameObject num2 = num2ball.gameObject.transform.GetChild (0).gameObject;
					num2.GetComponent<Text> ().text = secondNum;

			}

			if (save == "hisBall3" + recordNum.ToString ()) {

				GameObject num3ball = GameObject.Find (save);

				GameObject num3 = num3ball.gameObject.transform.GetChild (0).gameObject;
				num3.GetComponent<Text> ().text = thirdNum;

			}

			if (save == "hisBall4" + recordNum.ToString ()) {

				GameObject num4ball = GameObject.Find (save);

				GameObject num4 = num4ball.gameObject.transform.GetChild (0).gameObject;
				num4.GetComponent<Text> ().text = fourthNum;

			}

			if (save == "hisBall5" + recordNum.ToString ()) {

				GameObject num5ball = GameObject.Find (save);

				GameObject num5 = num5ball.gameObject.transform.GetChild (0).gameObject;
				num5.GetComponent<Text> ().text = fifthNum;

			}

			if (save == "hisBall6" + recordNum.ToString ()) {

				GameObject num6ball = GameObject.Find (save);

				GameObject num6 = num6ball.gameObject.transform.GetChild (0).gameObject;
				num6.GetComponent<Text> ().text = bigNum;

			}

			if (save == "ALogo" + recordNum.ToString ()) {
				
				GameObject gamename = GameObject.Find (save);
				if (lottoName == "MMG")
					gamename.GetComponent<Image> ().sprite = Resources.Load ("mmLOGO", typeof(Sprite)) as Sprite;
				if (lottoName == "PWR")
					gamename.GetComponent<Image> ().sprite = Resources.Load ("pwrlogo", typeof(Sprite)) as Sprite;
				if (lottoName == "CFL")
					gamename.GetComponent<Image> ().sprite = Resources.Load ("cash4lifeLogo", typeof(Sprite))as Sprite;

				if (lottoName == "TNC")
					gamename.GetComponent<Image> ().sprite = Resources.Load ("TNcashlogo", typeof(Sprite)) as Sprite;
			}

			if (save == "deleteCardbutt" + recordNum.ToString ()) 
			{
				GameObject b = GameObject.Find (save);
				Button butt = b.GetComponent<Button> ();
				butt.onClick.AddListener (delegate() {
					GameObject parent=b.transform.parent.gameObject;
					deleteRecord (recordNum,parent);
				});
			}

		}
		GameObject date = card.gameObject.transform.GetChild (0).gameObject;
		date.GetComponent<Text> ().text = recordDate;



		
	

	

	}

	public void deleteRecord(int r,GameObject parent )
	{
		
		Debug.Log ("Delete Pressed:" + r.ToString ());
		int newlinesInFile = 0;
		string readFilePath = "";
		#if UNITY_EDITOR_WIN
		readFilePath = Application.dataPath.ToString () + @"/lottoGS1.txt";
		#endif

		#if UNITY_ANDROID && !UNITY_EDITOR
		string p=Application.persistentDataPath;
		readFilePath=p+"/lottoGS1.txt";
		#endif
		bool readingfile = true;
		StreamReader reader = new StreamReader (readFilePath);
		string[] dataInfo = new string[records];
		string infoToDelete="";
		while (!reader.EndOfStream) {

			Debug.Log (newlinesInFile.ToString ());
			string lines = reader.ReadLine ();

			if (r == newlinesInFile) {
			 infoToDelete = lines;
				Debug.Log ("Line to delete:" + infoToDelete);
			
			
				//newlinesInFile = newlinesInFile + 1;

			} else {
				dataInfo [newlinesInFile] = lines;


			}

			newlinesInFile = newlinesInFile + 1;



		}

		reader.Close ();
		animateRecordDelete = true;
		recordName = parent.name;
		//newlinesInFile = newlinesInFile - 1;
		for (int i = 0; i < dataInfo.Length; i++)
		{
			
			Debug.Log (dataInfo [i]);
		}
			if (System.IO.File.Exists (readFilePath)) {
				File.Delete (readFilePath);
				File.CreateText (readFilePath).Dispose ();
				Debug.Log ("created and deleted");

		
			} else {
			}

			int k = 0;
			TextWriter writer = new StreamWriter (readFilePath, true);	
			Debug.Log ("New line Amt: " + newlinesInFile.ToString ());
		for (int d = 0; d < dataInfo.Length ; d++) {
			
				if (dataInfo [d]==null) {

				} else {
					writer.WriteLine (dataInfo [d]);

				}

			}

			
			writer.Close ();


	}
}
