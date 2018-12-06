using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    public player_control player;

	// Use this for initialization
	void Start () {
        this.name.Equals("ButtonLeft");	
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}
    

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.name.Equals("ButtonRight"))
        {
            player.moveThisRight();
        }
        else if (this.name.Equals("ButtonLeft"))
        {
            player.moveThisLeft();
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (this.name.Equals("ButtonRight"))
        {
            player.notMoveThisRight();
        }
        else if (this.name.Equals("ButtonLeft"))
        {
            player.notMoveThisLeft();
        }

    }
}
