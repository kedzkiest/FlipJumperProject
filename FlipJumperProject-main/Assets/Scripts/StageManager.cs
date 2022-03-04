using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using DG.Tweening;

public class StageManager : MonoBehaviour
{
    // =========== Stage ==============
    // Stage tempaltes
    public List<GameObject> stageTemplates = new List<GameObject>();

    // Initial Stage
    public GameObject initStage;

    // Current Stage
    public GameObject currentStage;

    // Next Stage
    public GameObject nextStage;

    // Stage List
    private List<GameObject> stageSpawnList = new List<GameObject>();
    private List<GameObject> ringEffectList = new List<GameObject>();

    // Initial Position and Scale of the stage
    public Vector3 stageInitPosition;
    public Vector3 stageInitScale;

    // Maximum Distance to generate a stage
    private float maxDistance = 4;

    // Direction array to generate a stage
    //Vector3[] directionList = new Vector3[] { new Vector3(1, 0, 0), new Vector3(0, 0, 1) };
    private List<Vector3> directionList = new List<Vector3> {new Vector3(1, 0, 0), new Vector3(0, 0, 1)};

    private List<Color> emissionColorList = new List<Color>
    {
        new Color(1, 0, 0), // red
        new Color(1, 0.24f, 0), // orange
        new Color(1, 0.93f, 0), // yellow
        new Color(0.16f, 1, 0), // green
        new Color(0, 1, 0.75f), // cyan
        new Color(0, 0.3f, 1), // blue
        new Color(0.67f, 0, 0.75f) // pink
    };

    public Color emissionColor;

    public GameObject ringEffect;
    public GameObject ringEffectPrefab = null;
    
    // Start is called before the first frame update
    void Start()
    {
        currentStage = initStage;
        //// Direction Vector of the character
        //CameraRelativePosition = Camera.main.transform.position - transform.position;
        stageInitPosition = initStage.transform.localPosition;
        stageInitScale = initStage.transform.localScale;

        SpawnStage();
    }

    public void SpawnStage()
    {
        // Randomly pick out a stage from the template
        GameObject prefab = stageTemplates[Random.Range(0, stageTemplates.Count)];
        nextStage = Instantiate(prefab);

        if (ringEffectPrefab != null)
        {
            ringEffect = Instantiate(ringEffectPrefab);
            ringEffect.GetComponent<Animator>().enabled = false;
        }


            // Randomly create the stage on top side or right side of the current stage
        nextStage.transform.position = currentStage.transform.position +
                                       directionList[Random.Range(0, directionList.Count)] *
                                       Random.Range(1.5f, maxDistance);

        if (ringEffectPrefab != null)
        {
            ringEffect.transform.position =
                new Vector3(nextStage.transform.position.x, -0.09f, nextStage.transform.position.z);
            ringEffectList.Add(ringEffect);
        }

        // Randomly set the scale in a range
        var randomScale = Random.Range(0.7f, 2.0f);
        nextStage.transform.localScale = new Vector3(randomScale, 0.5f, randomScale);
        // Randomly select a color
        nextStage.GetComponent<Renderer>().material.color =
            new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        emissionColor = emissionColorList.ElementAt(Random.Range(0, emissionColorList.Count));
        nextStage.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.48f, 0.48f, 0.48f));

        stageSpawnList.Add(nextStage);

        if (stageSpawnList.Count > 2)
        {
            GameObject go = stageSpawnList[0];
            stageSpawnList.RemoveAt(0);
            Destroy(go);
            //go.GetComponent<Renderer>().material.DOFade(0, 1f);
            //go.GetComponent<Renderer>().material.DOFade(1, 1).SetLoops(-1, LoopType.Yoyo);
        }
        
        if (ringEffectList.Count > 2)
        {
            GameObject go = ringEffectList[0];
            ringEffectList.RemoveAt(0);
            Destroy(go);
        }
        
    }
}
