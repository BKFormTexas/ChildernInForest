#Utils
***
  - Language: C#
***
  -Update Log
      - 21.07.07: FixedStartScene.cs script production.
      - 21.07.12: TTS.cs script work started.
      - 21.07.19: TTS.cs script production.
      - 21.07.19: VoiceManager.cs script production.
      - 21.07.19: SoundManager.cs script production.
      - 21.07.22: ImgSizeResize.cs script production.
      - 21.07.23: BGMmanager.cs script production.
      - 21.07.29: BlinkObject.cs, CharacterMovesWhenDragging.cs, ScriptManager.cs added.
***
- Utils configuration information
> 🗂 *Scripts*
> ⌙A folder consisting of commonly used script codes.
>
> > ⌙📄 FixedStartScene.cs
> > > A script that sets the game to the intro scene when running.
> > >
> > ⌙📄 TTS.cs
> > > A script that contains a class that communicates with the Google TTS API server to use TTS technology that can read words or conversations needed during games by voice.
> > >
> > ⌙📄 VoiceManager.cs
> > > How to use the TTS class is to create a class instance using voice text, voice customization settings, etc. and communicate with the API server. It is an object class script that wraps it once for convenient application to the scene.
> > >
> > ⌙📄 SoundManager.cs
> > > This is an object class script to output sound effects used in the scene.
> > >
> > ⌙📄 ImgSizeResize.cs
> > > This is a script that adjusts the size of the scene background to various screen sizes.
> > >
> > ⌙📄 BGMmanager.cs
> > > Because the operation characteristics are different from SoundManager, the code was written separately. It doesn't matter if the sound output from SoundManager is cut off when the scene changes, but the background sound output from BGMmanager must remain alive even when the scene changes, so the code was written separately because of its different properties.
> > >
> > ⌙📄 BlinkObject.cs
> > > A script that makes objects sparkle. It is set to sparkle by default, and you can stop the sparkle or make the object invisible by changing the Flag value through the declared functions.
> > >
> > ⌙📄 CharacterMovesWhenDragging.cs
> > > A script that moves an object according to the mouse position when dragging it. Through the previously declared function, you can set whether to activate or deactivate the drag function, whether it is in the current dragging state or when the mouse is released. By default, the drag function is activated.
> > >
> > ⌙📄 ScriptManager.cs
> > > Script that manages scripts (dialogue). You can put the script into an empty object, put the dialogue in Ms_Script and an object in Mg_ScriptObject, and use the function to output the next dialogue to the object or delete existing contents.
> > >
> 🗂 *Prefab*
> ⌙A folder composed of commonly used Prefab objects.
>
> > ⌙📄 backController.prefab
> > > This is a prefab that generalizes the back button to exit the game stage.
> > >
> > ⌙📄 BackgroundCanvas.prefab
> > > This is a generalized prefab that matches the background size to the screen size by applying the ImgSizeResize script mentioned above.
> > >
> > ⌙📄 JackBackgroundCanvas.prefab
> > > In Jack and the Beanstalk, not only the background but also the buttons are a little different from regular game stages, so this is a generalized prefab for use in the Jack and the Beanstalk stage.
> > >
> > ⌙📄 Loading.prefab
> > > This is a prefab that generalizes the loading screen.
> > >
> > ⌙📄 SoundManager.prefab
> > > This is a prefab that generalizes the object that performs the content defined in the SoundManager script, and outputs the sound effect clip entered in the inspector window.
> > >
> > ⌙📄 VoiceManager.prefab
> > > This is a prefab that generalizes the object that performs the contents defined in the VoiceManager script, and outputs the voice input in the inspector window.
> > >

***

  - Note

1. When using the VoiceManager prefab

     - You can set the prefab by dragging it to the scene you want to use, and adjust the desired voice pitch, speaking rate, and text in the inspector window of the VoiceManager object.
     - After setting in the inspector window, use playVoice in the desired script code (id or name -> At this time, id can be considered the index of the settings list set in the inspector window)

2. Comment processing in FixedStartScene script

     - When building, be sure to uncomment and build.

3. When using the BackgroundCanvas prefab

     - Set the prefab by dragging it to the scene you want to use, set the Render Camera in the canvas component window of the inspector window by dragging the Main Camera of the scene, and drag the background image you want to use using the sprite value of the applied ImgSizeResize script. You must set it. (The same applies when using the JackBackgroundCanvas prefab.)
