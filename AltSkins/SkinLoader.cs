﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BepInEx;
using UnityEngine;
using AltSkins.Data;

namespace AltSkins
{
    public static class SkinLoader
    {
        public static string folder = Path.Combine(Paths.BepInExRootPath, "Skins");

        public static Dictionary<string, List<CustomSkin>> skinMaps = new Dictionary<string, List<CustomSkin>>();

        public static void LoadSkins()
        {
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            foreach(var skinFolder in Directory.GetDirectories(folder))
            {
                List<CustomSkin> skins = new List<CustomSkin>();
                skins.Add(new CustomSkin(""));

                Console.WriteLine(new DirectoryInfo(skinFolder).Name);
                string[] supportedFileTypes = { ".png", ".jpg" };

                var files = Directory.GetFiles(skinFolder).Where(x => supportedFileTypes.Contains(Path.GetExtension(x).ToLower()));

                foreach(var file in files)
                {
                    skins.Add(new CustomSkin(file));
                }

                skinMaps.Add(new DirectoryInfo(skinFolder).Name, skins);
            }

            Console.WriteLine("Loaded " + skinMaps.Count + " skin(s)");
            /*string[] supportedFileTypes = { ".png", ".jpg" };
            var file = Directory.GetFiles(folder).Where(x => supportedFileTypes.Contains(Path.GetExtension(x).ToLower())).First();

            Texture2D tex = new Texture2D(2048, 2048);
            tex.LoadImage(File.ReadAllBytes(Path.Combine(Paths.BepInExRootPath, "plugins", "AltSkins", "Mascot_Albedo.png")));
            textureCache = tex;*/
        }
    }
}