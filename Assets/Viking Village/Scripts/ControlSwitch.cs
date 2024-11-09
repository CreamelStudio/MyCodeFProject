using System;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class ControlSwitch : MonoBehaviour {

	public KeyCode toggleKey = KeyCode.C;
	public GameObject manualController;
	public GameObject automaticController;

	private bool useAutomaticControl = false;
	private const string automaticControlDefaultCMDLineArgument = "-automaticControl";

	void Awake()
	{
		useAutomaticControl = HasCommandLineArgument (automaticControlDefaultCMDLineArgument);
		SetControllerState (false);
	}
	
	void Toggle()
	{
		useAutomaticControl = !useAutomaticControl;
		SetControllerState(useAutomaticControl);
	}

	void SetControllerState(bool useAutomaticControl)
	{
		manualController.SetActive (!useAutomaticControl);
		automaticController.SetActive (useAutomaticControl);
	}

	bool HasCommandLineArgument(string argument)
	{
		string[] passedArguments = System.Environment.GetCommandLineArgs ();
		foreach (string passedArgument in passedArguments) {
			if (passedArgument.Equals(argument))
				return true;
		}
		return false;
	}
}
