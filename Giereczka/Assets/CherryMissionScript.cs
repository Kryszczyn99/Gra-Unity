using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryMissionScript : MonoBehaviour
{
    public GameObject needCherry;
    public GameObject pressSpace;
    public GameObject white;
    public GameObject player;
    public GameObject cherry;
    public Transform placeForPlayer;
    public Transform placeForCherry;
    bool showItStill;
    bool playAudioStartMission;
    bool playAudioEndMission;
    bool doNotPlayAgain;
    bool showTextAfterTakingMission;
    bool destroyObjects;
    static bool missionStarted;
    bool haveLastDialogEnd;
    int whichAudioToPlay;
    int whichAudioToPlayEnd;
    // Start is called before the first frame update
    void Start()
    {
        needCherry.SetActive(false);
        pressSpace.SetActive(false);
        showItStill = true;
        playAudioStartMission = false;
        playAudioEndMission = false;
        showTextAfterTakingMission = false;
        doNotPlayAgain = false;
        destroyObjects = false;
        haveLastDialogEnd = false;
        missionStarted = false;
        whichAudioToPlay = 0;
        whichAudioToPlayEnd = 0;
    }
    void Update()
    {
        if (playAudioStartMission)
        {
            if (!PlayerMovement.IsFreeze()) PlayerMovement.Freeze();
            if (!SoundManagerScript.Playing())
            {
                pressSpace.SetActive(true);
            }
            switch (whichAudioToPlay)
            {
                case 4:
                    {
                        playAudioStartMission = false;
                        showTextAfterTakingMission = true;
                        PlayerMovement.UnFreeze();
                        break;
                    }
                case 3:
                    {
                        if (Input.GetKeyDown(KeyCode.Space) && !SoundManagerScript.Playing())
                        {
                            SoundManagerScript.PlaySound("wisienka_dialog_2_2");
                            pressSpace.SetActive(false);
                            whichAudioToPlay += 1;
                        }
                        break;
                    }
                case 2:
                    {
                        if (Input.GetKeyDown(KeyCode.Space) && !SoundManagerScript.Playing())
                        {
                            SoundManagerScript.PlaySound("wisienka_dialog_2");
                            pressSpace.SetActive(false);
                            whichAudioToPlay += 1;
                        }
                        break;
                    }
                case 1:
                    {
                        if (Input.GetKeyDown(KeyCode.Space) && !SoundManagerScript.Playing())
                        {
                            SoundManagerScript.PlaySound("wisienka_dialog_1_2");
                            pressSpace.SetActive(false);
                            whichAudioToPlay += 1;
                        }
                        break;
                    }
                case 0:
                    {

                        SoundManagerScript.PlaySound("wisienka_dialog_1");
                        pressSpace.SetActive(false);
                        needCherry.SetActive(false);
                        whichAudioToPlay += 1;
                        missionStarted = true;
                        break;
                    }
                        
            }
            
        }
        if(playAudioEndMission)
        {
            if (!PlayerMovement.IsFreeze()) PlayerMovement.Freeze();
            if (!SoundManagerScript.Playing())
            {
                pressSpace.SetActive(true);
            }
            switch (whichAudioToPlayEnd)
            {
                case 2:
                    {
                        playAudioEndMission = false;
                        showTextAfterTakingMission = false;
                        destroyObjects = true;
                        break;
                    }
                case 1:
                    {
                        if (Input.GetKeyDown(KeyCode.Space) && !SoundManagerScript.Playing())
                        {
                            SoundManagerScript.PlaySound("wisienka_dialog_3_2");
                            pressSpace.SetActive(false);
                            whichAudioToPlayEnd += 1;
                        }
                        break;
                    }

                case 0:
                    {

                        SoundManagerScript.PlaySound("wisienka_dialog_3");
                        whichAudioToPlayEnd += 1;
                        pressSpace.SetActive(false);
                        Vector2 pos = placeForPlayer.position;
                        player.transform.position = pos;
                        pos = placeForCherry.position;
                        cherry.transform.position = pos;
                        
                        break;
                    }
            }
        }
        if(destroyObjects)
        {
            if(haveLastDialogEnd)
            {
                Destroy(white);
                Destroy(cherry);
                PlayerMovement.UnFreeze();
            }
            else if(!SoundManagerScript.Playing())
            {
                haveLastDialogEnd = true;
            }
            
        }
    }
    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.tag == "Player" && showItStill)
        {
            float number = CherryPicker.getNumberOfCherries();
            if (number>0)
            {
                showItStill = false;

                playAudioEndMission = true;

            }
            else
            {
                if(doNotPlayAgain==false)
                {
                    playAudioStartMission = true;
                    doNotPlayAgain = true;
                }
                else if(showTextAfterTakingMission)
                {
                    needCherry.SetActive(true);
                }
                
            }
            
        }
    }
    void OnTriggerExit2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player" && showItStill)
        {
            needCherry.SetActive(false);
        }
    }
    static public bool DidMissionStart()
    {
        return missionStarted;
    }
}
