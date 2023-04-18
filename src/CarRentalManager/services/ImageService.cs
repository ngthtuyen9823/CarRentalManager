﻿using CarRentalManager.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRentalManager.services
{
    public class ImageService
    {
        public ImageService() { }

        public string getProjectImagePath(string imagePath, string fName, string imgName)
        {
            try
            {
                string currentDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName.ToString().Replace('\\', '/');
                string imageProjectPath = String.Format("/Assets/images/{0}/{1}.jpg", fName, imgName);
                string folderPath = String.Format("{0}/CarRentalManager/{1}", currentDirectory, imageProjectPath);
                if (System.IO.File.Exists(folderPath)) {
                    MessageBox.Show("INSIDE");
                    System.IO.File.Delete(folderPath);
                }
                System.IO.File.Copy(imagePath, folderPath);

                return imageProjectPath;
            }
            catch
            {
                MessageBox.Show("Your image file does not exist!");
                return null;
            }
        }
    }
}