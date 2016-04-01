------------------------------------------------------------------
GUI Animator for Unity UI 0.9.95
------------------------------------------------------------------

	Quickly and easily add professional animations for Unity UI elements. This package will save your time.

	Features:

		� 9 Demo scenes with sample scripts for C# developers.
		� 9 Demo scenes with sample scripts for JavaScript developers.
		� Animate position, rotation, scale, fade using tweeners.
		� Able to play sounds along with UI animations.
		� Categorizes into In/Idle/Out animations into tabs.
		� Ignorable time scale.
		� Callbacks capability.
		
		� DOTween, HOTween, iTween and LeanTween compatible.
		� You can add more tweeners.
		� Use preprocessor directives to examines Tweener before actual compilation.

		� Unity UI compatible (http://unity3d.com/learn/tutorials/modules/beginner/ui).
		� All Unity Canvas Render Modes and Unity Canvas Scale Modes compatible.

		� Support all build player platforms.

	Compatible:

		� Unity 4.6.9 or higher.
		� Unity 5.3.2 or higher.

	Note:
	
		� Unity Editor does not generate Texture Atlas for Unity UI. Please visit http://docs.unity3d.com/Manual/SpritePacker.html.
		� This package makes a discount price for UI Pack: Toony PRO (https://www.assetstore.unity3d.com/#!/content/44103).

	Product page:

		https://www.assetstore.unity3d.com/en/#!/content/28709

	Please direct any bugs/comments/suggestions to support e-mail (geteamdev@gmail.com).
		
	Thank you for your support,

	Gold Experience Team
	E-mail: geteamdev@gmail.com
	Website: http://www.ge-team.com

------------------------------------------------------------------
Release notes
------------------------------------------------------------------

	Version 0.9.95
	
		� Fixed GUID conflict with other packages.
		� Update Demo scenes and sample scripts.
		� Change refactor some classes and variables.
		� Change rearrange folders.
		� Unity 4.6.9 and higher compatible.
		� Unity 5.3.2 and higher compatible.

	Version 0.9.93 (Submitted on Oct 29, 2015)

		� Fixed "Coroutine couldn't be started"� error occurs when user sets the GameObject to active/inactive while GEAnim is animating.

	Version 0.9.92c (Releasd on Oct 14, 2015)

		� Change Canvas UI Scale Mode in all demo scenes to Scale With Screen Size.
		� Change Some parameters of GEAnim in Callback demo scene (only in Unity 5.2.0).
		� Fixed wrong folder names.
		� Supports multiple version of Unity; Unity 4.6.0 or higher, Unity 5.0.0 or higher, Unity 5.2.0 or higher.

	Version 0.9.92 (Released on Sep 28, 2015)

		� Fixed GETween has memory leak.
		� Fixed Friendly Inspector has Texture2D memory leak when user saves the scene.
		� Fixed Wrong ease type convertion when use with LeanTween.
		� Update smaller of GETween.dll file size.
		� Update speed up Friendly Inspector.
		� Unity 5.2.0 and higher compatible.

	Version 0.9.91 (Released on Sep 21, 2015)

		� Add Show/Hide icon in Hierarchy tab (it can be set in Friendly Inspector).
		� Add Icon alignment in Hierarchy tab.
		� Change Camera clear flags to solid color in all demo scenes.
		� Fixed GUIAnim has protection errors when it works with DOTween, HOTween, LeanTween.
		� Fixed User can not drop GameObject to callbacks in Friendly Inspector.
		� Update DOTween 1.0.750 and higher compatible.
		� Update LeanTween 2.28 and higher compatible.
		� Unity 5.1.3 and higher compatible.

	Version 0.9.9 (Released on Sep 9, 2015)

		� Add "960x600px"� to all demo scene names.
		� Add 9 demo scenes for Javascript developers.
		� Add 11 sample scripts for Javascript developers.
		� Add Friendly Inspector for GUIAnimSystem and GEAnimSystem elements.
		� Add GEAnim has new 10 override functions; Anim_In_MoveComplete(), Anim_In_RotateComplete(), Anim_In_ScaleComplete(), Anim_In_FadeComplete(), Anim_In_AllComplete(), Anim_Out_MoveComplete(), Anim_Out_RotateComplete(), Anim_Out_ScaleComplete(), Anim_Out_FadeComplete(), Anim_Out_AllComplete().
		� Add Hide animation parameters in Friendly Inspector unless it has been enabled.
		� Add GUIAnim and GEAnim can play In-Animations on Start() function ("On Start"� parameter in Inspector tab).
		� Add An option to disable/destroy GameObject after In-Animations completed ("On In-anims Complete" parameter in Inspector tab).
		� Add An option to disable/destroy GameObject after Out-Animations completed ("On Out-anims Complete" parameter in Inspector tab).
		� Add After Delay Sound into each animation, this will let user play AudioClip at right time after the delay.
		� Add GUIAnimSystem and GEAnimSystem has MoveInAll() and MoveOutAll() functions to play all GUI Animator elements in the scenes.
		� Add GUI Animator item shows mini-icon at the right edge of row in Inspector tab.
		� Add GUIAnimSystem will be add into the scene automatically when GUIAnim or GEAnim component is added into a GameObject.
		� Change Rename "Demo"� folder to "Demo (CSharp)".
		� Fixed Remove rotation and scale issues of In-Animation.
		� Fixed Sometimes error happens when select GUIAnimSystem or GEAnimSystem object in Hierarchy tab.
		� Fixed Remove minor known issues.
		� Fixed GETween is more smooth.
		� Update Sample Callback scene.

	Version 0.9.8 (Released on Aug 14, 2015)

		� Add Callback system for Move, Rotate, Scale, Fade.
		� Add Callback demo scene.
		� Fixed GUIAnimaEditor and GEAnimEditor components have duplicated parameters.
		� Fixed The same field name is serialized multiple times in the class.
		� Fixed Inspector tab, sometimes focus on wrong control when animation tab is changed in Friendly Inspector mode.
		� Update UI layout of Friendly Inspector.

	Version 0.9.6 (Released on Jun 23, 2015)

		� Update Unity 5.0.1 and higher compatible.
		� Update Support latest version of LeanTween and DOTween.
		� Update Friendly Inspector.
		� Fixed Wrong Move and Rotate animations.
		� Fixed Known issues in version 0.8.4.
		� Unity 5.0.1 and higher compatible.

	Version 0.8.4 (Released on Apr 6, 2015)

		� Add Unity 5.x.x compatible.
		� Add DOTween (HOTween v2) compatible.
		� Add Works with all Unity Canvas Render Modes.
		� Add Works with all Unity Canvas UI Scale Modes.
		� Add User can separately test MoveIn/Idle/MoveOut animations.
		� Add User can set Idle time for Auto animation.
		� Add Rotation In/Out.
		� Add Begin/End Sounds to animations.
		� Add Friendly inspector, all animation are categorised into tabs.
		� Add Friendly inspector, show/hide Easing graphs.
		� Add Friendly inspector, show/hide help boxes.
		� Fixed Bugs and known issues in 0.8.3.
		� Update Demo scenes and scripts.
		� Unity 4.6.0 and higher compatible.

	Version 0.8.3 (Initial version, released on Jan 31, 2015)

		� Unity 4.5.0 and higher compatible.


------------------------------------------------------------------
URLs
------------------------------------------------------------------

	GUI Animator for Unity UI web demo:
		http://ge-team.com/pages/unity-3d/gui-animator-for-unity-ui/

	GE-Team Products page:
		http://ge-team.com/pages/unity-3d/

------------------------------------------------------------------
Compatible Tweeners
------------------------------------------------------------------

	DOTween
		Unity Asset Store: https://www.assetstore.unity3d.com/en/#!/content/27676
		Documentation: http://dotween.demigiant.com/documentation.php

	HOTween
		Unity Asset Store: https://www.assetstore.unity3d.com/#/content/3311
		Documentation: http://hotween.demigiant.com/documentation.html
	
	iTween
		Unity Asset Store: https://www.assetstore.unity3d.com/#/content/84
		Documentation: http://itween.pixelplacement.com/documentation.php

	LeanTween
		Unity Asset Store: https://www.assetstore.unity3d.com/#/content/3595
		Documentation: http://dentedpixel.com/LeanTweenDocumentation/classes/LeanTween.html

------------------------------------------------------------------
Easing type references
------------------------------------------------------------------
	
	� Easings.net
		http://easings.net

	� RobertPenner.com
		http://www.robertpenner.com/easing/easing_demo.html
