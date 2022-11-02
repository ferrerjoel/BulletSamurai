using System.Runtime.CompilerServices;
using UnityEngine;
using Pvr_UnitySDKAPI;

[RequireComponent(typeof(MeshRenderer))]
public class GameObjectConcreteButtonHandler : MonoBehaviour {
	private Color originalColor;
	private Color currentColor;
	
	private MeshRenderer meshRenderer;
    
    private void Awake() {
		meshRenderer = GetComponent<MeshRenderer> ();
		originalColor = meshRenderer.material.color;
	    currentColor = originalColor;
    }

	private void Update() {
		


	    if (Controller.UPvr_GetKey(0, Pvr_KeyCode.TOUCHPAD))
	    {
		    currentColor = Color.cyan;
		
	    }
	    else if (Controller.UPvr_GetKey(0, Pvr_KeyCode.APP))
	    {
		    currentColor = Color.red;
	    }
	    else if (Controller.UPvr_GetKey(0, Pvr_KeyCode.VOLUMEUP))
	    {
		    currentColor = Color.grey;
	    }
	    else if (Controller.UPvr_GetKey(0, Pvr_KeyCode.VOLUMEDOWN))
	    {
		    currentColor = Color.white;
	    } 
	    // Headset buttons: 
	    else if (Input.GetKey(KeyCode.JoystickButton0))
	    {
		    currentColor = Color.black;
	    }
	    else
	    {
		    currentColor = originalColor;
	    }

	switch (Controller.UPvr_GetTouchPadClick(0))
        	{
            case TouchPadClick.No:
                break;
            case TouchPadClick.ClickUp:
                Debug.LogError("Swipe up");
				currentColor = Color.red;
				meshRenderer.material.color = currentColor;
                break;
            case TouchPadClick.ClickDown:
                Debug.LogError("Slide down");
				currentColor = Color.blue;
				meshRenderer.material.color = currentColor;
                
                break;
            case TouchPadClick.ClickRight:
                Debug.LogError("Slide to the right");
				currentColor = Color.black;
				meshRenderer.material.color = currentColor;
                
                break;
            case TouchPadClick.ClickLeft:
                Debug.LogError("Slide to the left");
				currentColor = Color.yellow;
				meshRenderer.material.color = currentColor;
                
                break;
            default:
                break;
        	}
		meshRenderer.material.color = currentColor;
	}

}

