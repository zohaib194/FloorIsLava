using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IClient : MonoBehaviour {
	private List<Command> commandList = new List<Command>();

	// IClient config.
	public IClientConfig config;

	bool onGround = true;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			commandList.Add(new MoveLeft());
		} else if(Input.GetKey(KeyCode.D)){
			commandList.Add(new MoveRight());
		} 
		if(Input.GetButton("Jump")){
			if(onGround){
				commandList.Add(new MoveJump());
				onGround = false;
			}
		}

		foreach(Command command in this.commandList){
		
			command.Execute(this);
			//this.commandList.Remove(command);
		}
		this.commandList.Clear();
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.name == "Cube"){
			onGround = true;
		}
	}
}
