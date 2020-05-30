﻿using Xamarin.Essentials;

namespace CollegePortalApplication.Helper
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string fileName)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, fileName);
        }
    }
}
