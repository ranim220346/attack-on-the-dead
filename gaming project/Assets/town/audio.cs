using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_b : MonoBehaviour

{
    public AudioSource Soundeffx;
    public AudioSource Bgsource;
    public static AudioManager_b instance = null;
    public float lowPitchRange;
    public float highPitchRange;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
