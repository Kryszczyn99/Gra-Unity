using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip closeD, openD, coinPickUp, cherrydialog1,cherrydialog11, cherrydialog2, cherrydialog22, cherrydialog3, cherrydialog33;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        closeD = Resources.Load<AudioClip>("close_door");
        openD = Resources.Load<AudioClip>("open_door");
        coinPickUp = Resources.Load<AudioClip>("pickup");
        cherrydialog1 = Resources.Load<AudioClip>("wisienka_dialog_1");
        cherrydialog11 = Resources.Load<AudioClip>("wisienka_dialog_1_2");
        cherrydialog2 = Resources.Load<AudioClip>("wisienka_dialog_2");
        cherrydialog22 = Resources.Load<AudioClip>("wisienka_dialog_2_2");
        cherrydialog3 = Resources.Load<AudioClip>("wisienka_dialog_3");
        cherrydialog33 = Resources.Load<AudioClip>("wisienka_dialog_3_2");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "close_door":
                audioSrc.PlayOneShot(closeD);
                break;
            case "open_door":
                audioSrc.PlayOneShot(openD);
                break;
            case "pickup":
                audioSrc.PlayOneShot(coinPickUp);
                break;
            case "wisienka_dialog_1":
                audioSrc.PlayOneShot(cherrydialog1);
                break;
            case "wisienka_dialog_2":
                audioSrc.PlayOneShot(cherrydialog2);
                break;
            case "wisienka_dialog_1_2":
                audioSrc.PlayOneShot(cherrydialog11);
                break;
            case "wisienka_dialog_2_2":
                audioSrc.PlayOneShot(cherrydialog22);
                break;
            case "wisienka_dialog_3":
                audioSrc.PlayOneShot(cherrydialog3);
                break;
            case "wisienka_dialog_3_2":
                audioSrc.PlayOneShot(cherrydialog33);
                break;
        }
    }
    public static bool Playing()
    {
        return audioSrc.isPlaying;
    }
}
