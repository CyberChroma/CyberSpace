using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceTrigger : MonoBehaviour {

    public AudioClip[] voices;
    public string[] subtitles;
    public float timeBetweenVoices;

    private int currentLine;
    private AudioSource voiceAudio;
    private Text subtitleText;
    private bool activated;
    private bool betweenLines;

	// Use this for initialization
	void Start () {
        voiceAudio = GameObject.Find("Voice Audio").GetComponent<AudioSource>();
        subtitleText = GameObject.Find("Subtitle Text").GetComponent<Text>();
	}
	
    void OnEnable () {
        currentLine = 0;
        activated = false;
        betweenLines = false;
    }

    void OnDisable () {
        if (subtitleText)
        {
            subtitleText.text = "";
        }
        if (voiceAudio)
        {
            voiceAudio.Stop();
        }
    }

	// Update is called once per frame
	void Update () {
        if (activated && !voiceAudio.isPlaying && !betweenLines)
        {
            StartCoroutine(NextLine());
        }
	}

    IEnumerator NextLine () {
        betweenLines = true;
        yield return new WaitForSeconds(timeBetweenVoices);
        currentLine++;
        if (currentLine < voices.Length)
        {
            voiceAudio.clip = voices[currentLine];
            voiceAudio.Play();
            subtitleText.text = subtitles[currentLine];
            betweenLines = false;
        }
        else
        {
            subtitleText.text = "";
        }
    }

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player") && !activated)
        {
            voiceAudio.clip = voices[0];
            voiceAudio.Play();
            subtitleText.text = subtitles[0];
            activated = true;
        }
    }
}
