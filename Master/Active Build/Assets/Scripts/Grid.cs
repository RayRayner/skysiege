﻿using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour 
{
	//Public Variables 
	public Color mouseOverColor;
	public GameObject currBuiltObject;

	// Private Variables
	GameObject buildObject; //Object we want to build
	Renderer _renderer;
	BuildManager buildManager;
	private Color gridStartColor;

	// Use this for initialization
	void Start () 
	{
		//Fetching our components
		_renderer = GetComponent<Renderer> ();
		buildManager = GameObject.Find ("GameManagers").GetComponent<BuildManager> ();
		gridStartColor = _renderer.material.color;
	
	}

	void OnMouseDown ()
	{
		//When clicked we check if we can build. If currBuiltObject is not null then we can't build :( 
		if (currBuiltObject == null ) 
			
			{
				if (buildManager.currentObject != null) 
				
					{
						Debug.Log ("YOU CAN BUILD HERE");
						buildObject = buildManager.currentObject;

						Instantiate (buildObject, transform.position, transform.rotation);


						currBuiltObject = buildObject;
						buildManager.currentObject = null; //Once the obejct is placed... Empty buildObject otherwise we can keep on building. 

						return;

					} 
						else 
					{

						Debug.Log ("PLEASE SELECT A SHIP TO DEPLOY");
					}
				} 

				else
			
				{

					Debug.Log ("UPS YOU CAN'T FUCKING BUILD HERE");

				}
			} 


	// OnMouseEnter & OnMouseExit Objects Color Change
	void OnMouseEnter ()
	{
		
		_renderer.material.color = mouseOverColor;
			
	}

	void OnMouseExit ()
	{

		_renderer.material.color = gridStartColor;

	}
}
