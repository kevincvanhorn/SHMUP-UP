using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

    public int difficulty;

    private static Options options;

    public static Options Instance()
    {
        // Maintain one copy through scene reload.
        if (!options)
        {
            options = FindObjectOfType(typeof(Options)) as Options;
            if (!options)
                Debug.LogError("There needs to be one active Options script on a GameObject in the scene.");
        }

        return options;
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
