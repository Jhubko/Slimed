using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private GameObject player;
    public player_death pb;
    public bool touch;
    public int damage;

   
    // Start is called before the first frame update
        void Start()
        {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        touch = false;
    }

    // Update is called once per frame
        public async void OnTriggerEnter2D(Collider2D col)
        {
    
            if (col.CompareTag("Player"))
            {
                touch = true;
            }

            while (touch == true)
            {

                pb.TakeDamage(damage);
                await Task.Delay(1000);
            }


    }
        public void OnTriggerExit2D(Collider2D other)
        {
        touch = false;
        }


}
