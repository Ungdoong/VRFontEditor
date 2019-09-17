using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Crosstales.FB;

public class FileManager : MonoBehaviour
{
    #region Variables
    public Dropdown font_drop;
    #endregion

    #region Public methods

    public void OpenFiles()
    {
        string directory_path = string.Empty, filename = string.Empty;

        string extensions = "ttf";

        string[] paths = FileBrowser.OpenFiles("Open Files", string.Empty, extensions, true);
        string[] split_path;

        int count = 0;

        foreach (string path in paths)
        {
            Debug.Log("Selected file: " + path);
            split_path = path.Split('/');
            foreach (string piece in split_path)
            {
                if (count++ == split_path.Length - 1)
                {
                    filename = piece;
                }
                else
                {
                    directory_path += piece + '/';
                }
            }
            Debug.Log("Directory : " + directory_path + ", Filename : " + filename);
            fileCopy(filename, directory_path, Application.dataPath + "/StreamingAssets/Fonts");
        }
    }

    public void SaveFile()
    {
        //Debug.Log("SaveFile");

        /*
        ExtensionFilter[] extensions = new[] {
                    new ExtensionFilter("Binary", "bin"),
                    new ExtensionFilter("Text", "txt"),
                    new ExtensionFilter("C#", "cs"),
                };
        */

        string extensions = "txt";

        string path = FileBrowser.SaveFile("Save File", string.Empty, "MySaveFile", extensions);

        //Debug.Log("Save file: " + path);
    }

    public void fileCopy(string fileName, string sourcePath, string targetPath)
    {
        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, fileName);

        if (!System.IO.Directory.Exists(targetPath))
        {
            System.IO.Directory.CreateDirectory(targetPath);
        }

        if (System.IO.Directory.Exists(sourcePath))
        {
            System.IO.File.Copy(sourceFile, destFile, true);
            font_drop.ClearOptions();
            font_drop.AddOptions(VTextInterface.GetAvailableFonts());
        }
        else
        {
            Debug.Log("Source path is Not Exists");
        }
    }
    #endregion
}
