using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_death : MonoBehaviour
{
	public int treshhold;
    public Text dead_string;
	public bool BDead;
    private bool Win;
    private float Time = 15000;
    private int points;
    private string result;
    public Text totaltime_string;
    public Text coin_string;
    public int maxHealth = 50;
	public int currentHealth;
	public HealthBar healthbar;
	// Start is called before the first frame update
	void Start()
    {
		BDead = false;
        Win = false;
        dead_string.text= "Zbierz jak najwięcej punktów i dojdź do mety aby przejść dalej";
		currentHealth = maxHealth;
		healthbar.SetMaxHealth(maxHealth);
	}

    void FixedUpdate()
	{
        if (Win == false && BDead == false)
        {
            dead_string.text = "";
            Time--;
        }
        totaltime_string.text = "Time: " + (Time / 50).ToString("F0");


    }
	
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < treshhold)
        {
            TakeDamage(10);

        }
        if (Input.GetButtonDown("Jump") && BDead == true)
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (currentHealth <= 0)
        {
            Dead();
        }

        if (Win)
		{
            points = GetComponent<collector>().point_count;
            result = ((points+(Time / 50))).ToString("f0");
            dead_string.text= "You Won!\n"+"Points: "+ result + "\nPress 'Space' to restart. \nPress 'ESC' to Quit.";
		    Destroy(GetComponent<player_control>());
		    Destroy(GetComponent<Rigidbody2D>());
		
		if (Input.GetButtonDown("Jump"))
			{
			    SceneManager.LoadScene("SampleScene");	
			}
        else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

        }
    }
	
	void OnTriggerEnter2D(Collider2D won)
    {
	    if (won.gameObject.CompareTag("Finish"))
			{
			    Win=true;
            }

    }
    public void Dead()
    {
        BDead = true;
        dead_string.text = "You Died!\nPress 'Space' to restart. \nPress 'ESC' to Quit.";
        Destroy(GetComponent<player_control>());
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<Renderer>());

    }
    //public void GetHealth(int health)
    //{
    //    currentHealth += health;
    //    healthbar.SetHealth(currentHealth);
    //}
	 public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}
