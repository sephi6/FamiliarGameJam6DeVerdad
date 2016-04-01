// GUI Animator for Unity UI
// Version: 0.9.95
// Compatilble: Unity 4.6.9 or higher and Unity 5.3.2 or higher, more info in Readme.txt file.
//
// Author:	Gold Experience Team (http://www.ge-team.com)
// Details:	https://www.assetstore.unity3d.com/en/#!/content/28709
// Support:	geteamdev@gmail.com
//
// Please direct any bugs/comments/suggestions to support e-mail.

#region Namespaces

using UnityEngine;
using UnityEditor;
using System.Collections;

#endregion // Namespaces

// ######################################################################
// GSuiEditor class
// Custom editor for GSui component
// ######################################################################

// http://docs.unity3d.com/ScriptReference/CustomEditor.html
// http://docs.unity3d.com/ScriptReference/CustomEditor-ctor.html
// http://unity3d.com/learn/tutorials/modules/intermediate/editor/adding-buttons-to-inspector
[CustomEditor(typeof(GSui))]
// http://docs.unity3d.com/ScriptReference/Editor.html
public class GSuiEditor : GUIAnimSystemEditor
{

	// ########################################
	// Variables
	// ########################################

	#region Variables

	#endregion // Variables

	// ########################################
	// Editor functions
	// http://docs.unity3d.com/ScriptReference/Editor.html
	// ########################################
	
	#region Editor functions

		// This function is called when the object is loaded
	// http://docs.unity3d.com/ScriptReference/ScriptableObject.OnEnable.html
		public override void OnEnable()
		{

		// ########################################
		//*** PERFORM YOUR EDITOR SCRIPTS HERE ***//


		// ########################################
		}

		// Implement this function to make a custom inspector
	// http://docs.unity3d.com/ScriptReference/Editor.OnInspectorGUI.html
		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI();

		// ########################################
		//*** PERFORM YOUR EDITOR SCRIPTS HERE ***//


		// ########################################
		}
	
	#endregion // Editor functions
}
