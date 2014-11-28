using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Text itText;
    public Text immunitytext;

	// Use this for initialization
	void Start () {
        itText.enabled = true;
        immunitytext.enabled = false;
	}
	
    public void ShowItText()
    {
        itText.enabled = true;
    }

    public void HideItText()
    {
        itText.enabled = false;
    }

    public void ShowImmunityText()
    {
        immunitytext.enabled = true;
    }

    public void HideImmunityText()
    {
        immunitytext.enabled = false;
    }
}
