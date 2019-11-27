using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class genNumbers : MonoBehaviour {


	int number1;
	int number2;
	int number3;
	int number4;
	int number5;
	int megaNumber;
	int pwrNumberBig;
	int cflNumberBig;
	int tncNumberBig;

	public Text MMnum1;
	public Text MMnum2;
	public Text MMnum3;
	public Text MMnum4;
	public Text MMnum5;
	public Text MMnumMega;

	public Text PWRnumBig;
	public Text pwrnum1;
	public Text pwrnum2;
	public Text pwrnum3;
	public Text pwrnum4;
	public Text pwrnum5;

	public Text CFLnumBig;
	public Text CFLnum1;
	public Text CFLnum2;
	public Text CFLnum3;
	public Text CFLnum4;
	public Text CFLnum5;

	public Text TNCnumBig;
	public Text TNCnum1;
	public Text TNCnum2;
	public Text TNCnum3;
	public Text TNCnum4;
	public Text TNCnum5;

	public AudioClip splatSnd;
	public AudioClip popSnd;

	List<int> numbers=new List<int>();
	int currentGame=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void genMegaNumbers()
	{
		number1 = Random.Range (1, 71);

		number2 = Random.Range (1, 71);
		number3 = Random.Range (1, 71);
		number4 = Random.Range (1, 71);
		number5 = Random.Range (1, 71);

		megaNumber = Random.Range (1, 26);

		if(number2==number1 || number2==number3 || number2==number4 || number2==number5)
			number2 = Random.Range (1, 71);

		if(number3==number1 || number3==number2 || number3==number4 || number3==number5)
			number3= Random.Range (1, 71);

		if(number4==number1 || number4==number2 || number4==number3 || number4==number5)
			number4= Random.Range (1, 71);
		
		if(number5==number1 || number5==number2 || number5==number3 || number5==number4)
			number5= Random.Range (1, 71);

	

		numbers.Add (number1);
		numbers.Add (number2);
		numbers.Add (number3);
		numbers.Add (number4);
		numbers.Add (number5);
		numbers.Sort ();

		number1 = numbers [0];
		number2 = numbers [1];
		number3 = numbers [2];
		number4 = numbers [3];
		number5 = numbers [4];

		MMnum1.text = number1.ToString ();
		MMnum2.text = number2.ToString ();
		MMnum3.text = number3.ToString ();
		MMnum4.text = number4.ToString ();
		MMnum5.text = number5.ToString ();
		numbers.Clear ();

		MMnumMega.text = megaNumber.ToString ();

		currentGame = 1;
		AudioSource.PlayClipAtPoint (splatSnd, Vector3.zero);
	}

	public void genPwrNumbers()
	{
		number1 = Random.Range (1, 70);

		number2 = Random.Range (1, 70);
		number3 = Random.Range (1, 70);
		number4 = Random.Range (1, 70);
		number5 = Random.Range (1, 70);

		pwrNumberBig = Random.Range (1, 27);

		if(number2==number1 || number2==number3 || number2==number4 || number2==number5)
			number2 = Random.Range (1, 70);

		if(number3==number1 || number3==number2 || number3==number4 || number3==number5)
			number3= Random.Range (1, 70);

		if(number4==number1 || number4==number2 || number4==number3 || number4==number5)
			number4= Random.Range (1, 70);

		if(number5==number1 || number5==number2 || number5==number3 || number5==number4)
			number5= Random.Range (1, 70);

		numbers.Add (number1);
		numbers.Add (number2);
		numbers.Add (number3);
		numbers.Add (number4);
		numbers.Add (number5);
		numbers.Sort ();

		number1 = numbers [0];
		number2 = numbers [1];
		number3 = numbers [2];
		number4 = numbers [3];
		number5 = numbers [4];


		pwrnum1.text = number1.ToString ();
		pwrnum2.text = number2.ToString ();
		pwrnum3.text = number3.ToString ();
		pwrnum4.text = number4.ToString ();
		pwrnum5.text = number5.ToString ();
		numbers.Clear ();
		PWRnumBig.text =pwrNumberBig.ToString ();

		currentGame = 2;
		AudioSource.PlayClipAtPoint (splatSnd, Vector3.zero);

	}

	public void genCFLNumbers()
	{
		number1 = Random.Range (1, 61);

		number2 = Random.Range (1, 61);
		number3 = Random.Range (1, 61);
		number4 = Random.Range (1, 61);
		number5 = Random.Range (1, 61);

		cflNumberBig = Random.Range (1,5);

		if(number2==number1 || number2==number3 || number2==number4 || number2==number5)
			number2 = Random.Range (1, 61);

		if(number3==number1 || number3==number2 || number3==number4 || number3==number5)
			number3= Random.Range (1, 61);

		if(number4==number1 || number4==number2 || number4==number3 || number4==number5)
			number4= Random.Range (1, 61);

		if(number5==number1 || number5==number2 || number5==number3 || number5==number4)
			number5= Random.Range (1, 61);

		numbers.Add (number1);
		numbers.Add (number2);
		numbers.Add (number3);
		numbers.Add (number4);
		numbers.Add (number5);
		numbers.Sort ();

		number1 = numbers [0];
		number2 = numbers [1];
		number3 = numbers [2];
		number4 = numbers [3];
		number5 = numbers [4];

		CFLnum1.text = number1.ToString ();
		CFLnum2.text = number2.ToString ();
		CFLnum3.text = number3.ToString ();
		CFLnum4.text = number4.ToString ();
		CFLnum5.text = number5.ToString ();
		numbers.Clear ();
		CFLnumBig.text =cflNumberBig.ToString ();
		currentGame = 3;
		AudioSource.PlayClipAtPoint (splatSnd, Vector3.zero);
	}

	public void genTNCNumbers()
	{
		number1 = Random.Range (1, 36);

		number2 = Random.Range (1, 36);
		number3 = Random.Range (1,36);
		number4 = Random.Range (1,36);
		number5 = Random.Range (1, 36);

		tncNumberBig = Random.Range (1,6);

		if(number2==number1 || number2==number3 || number2==number4 || number2==number5)
			number2 = Random.Range (1, 36);

		if(number3==number1 || number3==number2 || number3==number4 || number3==number5)
			number3= Random.Range (1, 36);

		if(number4==number1 || number4==number2 || number4==number3 || number4==number5)
			number4= Random.Range (1, 36);

		if(number5==number1 || number5==number2 || number5==number3 || number5==number4)
			number5= Random.Range (1, 36);

		numbers.Add (number1);
		numbers.Add (number2);
		numbers.Add (number3);
		numbers.Add (number4);
		numbers.Add (number5);
		numbers.Sort ();

		number1 = numbers [0];
		number2 = numbers [1];
		number3 = numbers [2];
		number4 = numbers [3];
		number5 = numbers [4];


		TNCnum1.text = number1.ToString ();
		TNCnum2.text = number2.ToString ();
		TNCnum3.text = number3.ToString ();
		TNCnum4.text = number4.ToString ();
		TNCnum5.text = number5.ToString ();
		numbers.Clear ();
		TNCnumBig.text =tncNumberBig.ToString ();

		currentGame = 4;
		AudioSource.PlayClipAtPoint (splatSnd, Vector3.zero);
	}

	public void saveLottoNumbers()
	{

		AudioSource.PlayClipAtPoint (popSnd, Vector3.zero);
		globalVar.recordAdded = true;
		globalVar.recordsAdded = globalVar.recordsAdded + 1;
		string d;
		string m; 
		if (mainScreen.day < 10) {
			 d = "0"+mainScreen.day.ToString ();
		} else {
			 d = mainScreen.day.ToString ();
		}
		if (mainScreen.month < 10) {
			m = "0"+mainScreen.month.ToString ();
		} else {
			 m = mainScreen.month.ToString ();
		}

		string y = mainScreen.year.ToString ();

		string game = "";
		int bigNumber=0;
		if (currentGame == 1) 
		{
			game = "MMG,";
			bigNumber = megaNumber;
		}
		if (currentGame == 2) 
		{
			game = "PWR,";
			bigNumber = pwrNumberBig;
		}

		if (currentGame == 3) 
		{
			game = "CFL,";
			bigNumber = cflNumberBig;
		}
		if (currentGame == 4) 
		{
			game = "TNC,";
			bigNumber = tncNumberBig;
		}

		if (number1 != 0) {
			string saveFilePath;
			#if UNITY_EDITOR

			saveFilePath= Application.dataPath.ToString () + @"/lottoGS1.txt";
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR
			string p=Application.persistentDataPath;
			saveFilePath=p+"/lottoGS1.txt";
			#endif

			TextWriter writer = new StreamWriter (saveFilePath, true);
			string fn;		//These three varibles are used to put a 0 in front of a single digit number for better writing to the text file 
			string sn;
			string tn;
			string BN;
			if (number1 < 10) {
				fn = "0" + number1.ToString ();


			} else {fn = number1.ToString ();
			}
			if (number2 < 10) {
				sn = "0" + number2.ToString ();


			} else {sn = number2.ToString ();
			}
			if (number3 < 10) {
				tn = "0" + number3.ToString ();


			} else {tn = number3.ToString ();
			}

			if (bigNumber < 10) {
				BN = "0" + bigNumber.ToString ();


			} else {BN = bigNumber.ToString ();
			}
			Debug.Log (fn);

			writer.WriteLine (game + fn + "," + sn + "," + tn + "," + number4.ToString () + "," + number5.ToString () + "," + BN +"-"+ m +"-"+d+"-"+y);

			writer.Close ();
		}

        StartCoroutine(ShowSavedGoodTxt());



    }

          private IEnumerator ShowSavedGoodTxt()
            {
                GameObject.Find("SSTxt").GetComponent<Text>().text = "Save successful!";
                 yield return new WaitForSeconds(2f);
                 GameObject.Find("SSTxt").GetComponent<Text>().text = "";
    }

    }
