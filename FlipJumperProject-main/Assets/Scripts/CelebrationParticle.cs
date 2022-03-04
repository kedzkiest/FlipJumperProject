using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationParticle : MonoBehaviour
{
    public UIManager u;
    
    public bool goalAchieved;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        Invoke(nameof(stopThis), 0.5f);
    }

    private int smallGoal = 5;
    
    // Update is called once per frame
    void Update()
    {
        
        if (u.score >= smallGoal)
        {
            smallGoal += 5;
            gameObject.GetComponent<ParticleSystem>().Play();
            goalAchieved = true;
            Invoke(nameof(stopThis), 1.0f);
        }
        
        
    }

    void stopThis()
    {
        gameObject.GetComponent<ParticleSystem>().Stop();
        goalAchieved = false;
    }
}
