/******************************************************
* Author: Thormod
* Date:   21/09/2016
* CustomCursor.cs
*******************************************************/

using UnityEngine;
using System.Collections;

public class CustomCursor : MonoBehaviour {

    /************* Public variables ******************/
    //The texture that's going to replace the current cursor 
    public Texture2D cursor_default_texture;
    public Texture2D cursor_attack_texture;
    public Texture2D cursor_goals_texture;

    //Enum for each cursor state
    public enum cursor_state{ cursor_default, cursor_attack, cursor_goal };

    //This variable flags whether the custom cursor is active or not 
    public bool isEnable = false;
    /************ /Public variables ******************/
    
    // Use this for initialization
    void Start () {
        //Call the 'SetCustomCursor' (see below) with a delay of 2 seconds.  
        Invoke("SetCustomCursor", 2.0f);
    }

    void OnDisable(){
        //Resets the cursor to the default 
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        //Set the _ccEnabled variable to false 
        this.isEnable = false;
    }

    private void SetCustomCursor(){
        //Replace the 'cursorTexture' with the cursor   
        Cursor.SetCursor(this.cursor_default_texture, Vector2.zero, CursorMode.Auto);
        Debug.Log("Custom cursor has been set.");
        //Set the ccEnabled variable to true 
        this.isEnable = true;
    }
}
