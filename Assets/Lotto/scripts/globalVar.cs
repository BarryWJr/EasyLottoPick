using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalVar : MonoBehaviour {


	static public bool showingHistory = false;
	static public bool recordAdded=false;
	static public int recordsAdded = 0;
	static public int firstTimeRun;
	static public bool showingSettings = false;
	static public int totalRecordsSaved = 0;

    public static void showSavedToast()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
           
        }
    }
}
