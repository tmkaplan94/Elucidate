/*
 * Version - 1.0
 * Date - 01/22/2022
 * Description - AudioManager managers all audio sources.
 * Summary
 *  - AudioManager extends Singleton, which extends MonoBehavior.
 *  - contains a varying list of all sound sources
 *  - responsible for finding and playing them
 * 
 * Author - Tyler Kaplan
 * Contributors
 *  - 
 */

using UnityEngine;
using UnityEditor.Audio;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] _sounds;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
