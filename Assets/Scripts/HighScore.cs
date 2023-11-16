using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
	
	int HighScoreD;
	public Text HighScoreConv;
    
   private void Start(){
		
		
		HighScoreD = PlayerPrefs.GetInt("HighScore");	
		HighScoreConv.text = HighScoreD.ToString();
		
	}

    
    void Update()
    {
        
    }
}
