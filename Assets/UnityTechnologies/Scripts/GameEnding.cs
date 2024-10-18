using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// GameEnding is used to trigger the end of the level and quit the game.
/// </summary>
public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    bool m_IsPlayerAtExit = false;
    bool m_IsPlayerCaught = false;
    float m_Timer = 0f;
    bool m_HasAudioPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }
    /// <summary>
    /// Called when the player is caught by the Gargoyle. Will reload the scene.
    /// </summary>
    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }
    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup,true, caughtAudio);
        }
    }
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;      // alpha will over 1???

        if (m_Timer > fadeDuration + displayDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }


    
}
