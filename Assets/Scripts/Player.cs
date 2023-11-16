using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed;
    public float increment;
    public float maxY;
    public float minY;

    private Vector2 targetPos;

    public int health;

    public GameObject moveEffect;
    public Animator camAnim;
    public Text healthDisplay;

    public GameObject spawner;
    public GameObject restartDisplay;
	
	public GameObject LifeDisplay_1;
	public GameObject LifeDisplay_2;
	public GameObject LifeDisplay_3;
	
	
	
	public Sprite Heart_Full;
	public Sprite Heart_Null;
	
    int score;
	int HighScore;
    public Text DimondCont;
	
	
	public GameObject PlayerSkins;
	
	public AudioSource DiamondSound;
	
	
	
	
	
	
	public void DOWN_BUTTON()
    {
        
    
	if (transform.position.y > minY)
	   {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
        }
		
		
	}
	
	
	
	public void UP_BUTTON()
    {
  if (transform.position.y < maxY) 
  {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
        }
	}
	
	
private void OnTriggerEnter2D(Collider2D other)
    {
		
        if (other.CompareTag("ObstacleDimond")) {
			
			DiamondSound = GetComponent<AudioSource>();
			DiamondSound.clip = Resources.Load<AudioClip>("DiamondAudio"); 
			DiamondSound.Play();
			
			score++;
			
			
			
			
			
            
        }   
    }
	
	
	private void Start(){
		
		
			HighScore = PlayerPrefs.GetInt("HighScore");
			

			if (HighScore >= 25 && HighScore < 50)
			{
				
				var animator = PlayerSkins.GetComponent<Animator>();
                animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("UncommonDragon_AC");
		   
			
			} else if (HighScore >= 50 && HighScore < 100){
				
				 var animator = PlayerSkins.GetComponent<Animator>();
                 animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("EpicDragon_AC"); 

			}
			if (HighScore >= 100)
			{
				
				var animator = PlayerSkins.GetComponent<Animator>();
                animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("LegendaryDragon_AC");
		   
			
			}
			
			
		
	}

    private void Update()
    {
		
		if (score > HighScore)
			{
		
			HighScore = score;
			PlayerPrefs.SetInt("HighScore",HighScore);
			
			} else {
				
		    score = score + 0;
				
			}
		
		        
				DimondCont.text = score.ToString();
				


     if (health == 2) 
     {
            LifeDisplay_3.GetComponent<SpriteRenderer>().sprite = Heart_Null;
			
        } else if (health == 1)
			{
			LifeDisplay_2.GetComponent<SpriteRenderer>().sprite = Heart_Null;
			}
		
		
		
        if (health <= 0) {
			LifeDisplay_1.GetComponent<SpriteRenderer>().sprite = Heart_Null;
            spawner.SetActive(false);
            restartDisplay.SetActive(true);
            Destroy(gameObject);
        }

        healthDisplay.text = health.ToString();

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
		
		
		

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY) {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY) {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
        }
    }
}
