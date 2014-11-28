using UnityEngine;
using System.Collections;

public class PlayerAlert : MonoBehaviour {

    Taggable playerTaggable;
    public UIManager ui;

	// Use this for initialization
	void Start () {
        playerTaggable = GetComponent<Taggable>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if(playerTaggable.isIt)
        {
            ui.ShowItText();
        }
        else if(playerTaggable.isImmune)
        {
            ui.HideItText();
            ui.ShowImmunityText();
        }
        else 
        {
            ui.HideItText();
            ui.HideImmunityText();
        }
	
	}
}
