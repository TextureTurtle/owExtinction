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
        void OnCompleteSceneLoad(OWScene originalScene, OWScene loadScene)
        {
            // Import Stuff
            // ==============================
            ModHelper.Console.WriteLine($"SUS", MessageType.Info);

            // Audio

            // Images

            //Texture2D oweLogo = ImportTextureFromImage(Path.Combine(DllExecutablePath, "MENU_OWE_d.png"));

            // Models

            // Replace or add Assets
            // ===============================

            // Audio

            //var ogTheme = Resources.FindObjectsOfTypeAll<AudioSource>().First(x => x.name == "AudioSource_Music");
            //ogTheme = ogTheme.GetComponent<AudioSource>();
            //ogTheme.clip = (AudioClip)Resources.Load("Main.mp3", typeof(AudioClip));

            // Images


            // Models

            ModHelper.Console.WriteLine($"SUS2", MessageType.Info);
        }
        private void Start()
        {
            // Starting here, you'll have access to OWML's mod helper.

            // Menu Stuff
            Sprite newSplash = LoadNewSprite(Path.Combine(DllExecutablePath, "GamepadSplashImage.png"));
            var oldSplash = Resources.FindObjectsOfTypeAll<Image>().First(x => x.name == "GamepadSplashImage");
            oldSplash.sprite = newSplash;


            // End Stuff
            LoadManager.OnCompleteSceneLoad += OnCompleteSceneLoad;
            ModHelper.Console.WriteLine($"My mod {nameof(ModTemplate)} is loaded!", MessageType.Success);
        }
        public static Texture2D ImportTextureFromImage(string filePath)
        {
            byte[] imageBytes = File.ReadAllBytes(filePath);
            Texture2D image = new Texture2D(2, 2); image.LoadImage(imageBytes);
            return image;
        }
        public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f, SpriteMeshType spriteType = SpriteMeshType.Tight)
        {
            // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
            Texture2D SpriteTexture = ImportTextureFromImage(FilePath);
            Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit, 0, spriteType);

            return NewSprite;
        }

    }
}
