using UnityEngine;
using System.Collections;

public class UI_manager : MonoBehaviour {

    public GameObject aboutPanel;


    public void StartGame()
    {
        Application.LoadLevel("1_game");
    }

    void Start () {
      // hideAboutPanel();
    }

    public void showAboutPanel()
    {
        aboutPanel.SetActive(true);
    }

    public void hideAboutPanel()
    {
        aboutPanel.SetActive(false);
        print("hide panel");
    }
    // Use this for initialization
   
	
	// Update is called once per frame
	void Update () {
	
	}
}
