using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManaget : MonoBehaviour
{
    [SerializeField] private GameObject _panelPause;
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private GameObject _panelLose;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _hud;
    [SerializeField] private GameObject _spawner;
    
    
    public void PauseOn()
    {
        _panelPause.SetActive(true);
        Time.timeScale = 0;
    }
    public void PauseOff()
    {
        _panelPause.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void Win()
    {
        _panelWin.SetActive(true);
        _player.SetActive(false);
        _hud.SetActive(false);
        _spawner.SetActive(false);
    }
    
    public void Lose()
    {
        _panelLose.SetActive(true);
        _player.SetActive(false);
        _hud.SetActive(false);
        _spawner.SetActive(false);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _panelPause.SetActive(false);
        Time.timeScale = 1;
    }
}