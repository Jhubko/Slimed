using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collector : MonoBehaviour
{
	public int point_count;
	public Text pointString;
   
    void Start()
    {
		pointString.text="Points: " + point_count.ToString("F0");
    }

	void OnTriggerEnter2D(Collider2D collider)
	{
	if (collider.gameObject.CompareTag("Point"))
		{
		Destroy(collider.gameObject);
		point_count += 100;
		pointString.text="Points: "+ point_count.ToString("F0");
		}


    }
	
	void Update()
    {
		pointString.text = "Points: " + point_count.ToString("F0");
	}


}
