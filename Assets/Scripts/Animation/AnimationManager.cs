using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {
	//[HideInInspector]
    
    [System.Serializable]
    public class Animation
    {
       public string name;
       public bool isActive;
    }
    public Animation[] animationList;
    private int currentActive = -1;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setAnimation(string name, bool isActive = true){

		if(currentActive != -1){
			// Disabling current animation.
			animationList[currentActive].isActive = false;
			anim.SetBool(animationList[currentActive].name, animationList[currentActive].isActive);
		}

		
		// Keep reference to the new active animation.
		for(int i = 0; i < animationList.Length; i++){
			if(animationList[i].name == name){
				animationList[i].isActive = isActive;
				currentActive = i;
			}
		}

		// Activating new animation.
		anim.SetBool(animationList[currentActive].name, animationList[currentActive].isActive);

	}
}
