using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class FailAndStopCheering : MonoBehaviour
{
    public Player player;

    public AudioSource cheer;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(2, 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (cheer.isPlaying)
        {
            gameObject.transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            gameObject.transform.localScale = Vector3.zero;

        }
        
        if (player.isGameOver)
        {
            gameObject.transform.localScale = Vector3.zero;

        }

    }
    
}
