using OWML.ModHelper;
using OWML.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace ModTemplate
{
    public class ModTemplate : ModBehaviour
    {
        private void Awake()
        {
            // You won't be able to access OWML's mod helper in Awake.
            // So you probably don't want to do anything here.
            // Use Start() instead.
        }
        private static string dllPath;
        public static string DllExecutablePath { get { if (string.IsNullOrEmpty(dllPath)) dllPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); return dllPath; } private set { } }
        private void Start()
        {
            // Starting here, you'll have access to OWML's mod helper.

            // Import Stuff
            // ==============================

            // Audio

            // Images
            Texture2D newSplash = ImportTextureFromImage(Path.Combine(DllExecutablePath, "GamepadSplashImage.png"));
            Texture2D oweLogo = ImportTextureFromImage(Path.Combine(DllExecutablePath, "MENU_OWE_d.png"));
            var duckAsset = ModHelper.Assets.LoadTexture("GamepadSplashImage.png");
            // Models

            // Replace or add Assets
            // ===============================

            // Audio

            var ogTheme = Resources.FindObjectsOfTypeAll<AudioSource>().First(x => x.name == "AudioSource_Music");
            ogTheme = ogTheme.GetComponent<AudioSource>();
            ogTheme.clip = (AudioClip)Resources.Load("Main.mp3", typeof(AudioClip));

            // Images
            var oldSplash = Resources.FindObjectsOfTypeAll<Image>().First(x => x.name == "GamepadSplashImage");
            oldSplash.material.mainTexture = newSplash;

            // Models

            ModHelper.Console.WriteLine($"My mod {nameof(ModTemplate)} is loaded!", MessageType.Success);
        }
        public static Texture2D ImportTextureFromImage(string filePath)
        {
            byte[] imageBytes = File.ReadAllBytes(filePath);
            Texture2D image = new Texture2D(2, 2); image.LoadImage(imageBytes);
            return image;
        }
 
    }
}
