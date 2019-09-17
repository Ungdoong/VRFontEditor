using UnityEngine;
using UnityEngine.UI;

namespace Crosstales.FB.Demo
{
    /// <summary>Examples for all methods.</summary>
    [HelpURL("https://www.crosstales.com/media/data/assets/FileBrowser/api/class_crosstales_1_1_f_b_1_1_demo_1_1_examples.html")]
    public class Example : MonoBehaviour
    {
        #region Variables

        #endregion

        #region Public methods

        public void OpenSingleFile() {
            //Debug.Log("OpenSingleFile");
            
            /*
            ExtensionFilter[] extensions = new[] {
                new ExtensionFilter("Image Files", "png", "jpg", "jpeg" ),
                new ExtensionFilter("Sound Files", "mp3", "wav" ),
                new ExtensionFilter("All Files", "*" ),
            };
            */
            
            string extensions = string.Empty;
            
            string path = FileBrowser.OpenSingleFile("Open File", string.Empty, extensions);

            //Debug.Log("Selected file: " + path);
        }
        
        public void OpenFiles() {
            //Debug.Log("OpenFiles");

            /*
            ExtensionFilter[] extensions = new[] {
                new ExtensionFilter("Image Files", "png", "jpg", "jpeg" ),
                new ExtensionFilter("Sound Files", "mp3", "wav" ),
                new ExtensionFilter("All Files", "*" ),
            };
            */

            string directory_path = string.Empty, filename = string.Empty;
            
            string extensions = "ttf";
            
            string[] paths = FileBrowser.OpenFiles("Open Files", string.Empty, extensions, true);
            string[] split_path;

            int count = 0;

            foreach (string path in paths)
            {
                Debug.Log("Selected file: " + path);
                split_path = path.Split('/');
                foreach(string piece in split_path)
                {
                    if(count++ == split_path.Length - 1)
                    {
                        filename = piece;
                    }
                    else
                    {
                        directory_path += piece + '/';
                    }
                }
                Debug.Log("Directory : " + directory_path + ", Filename : " + filename);
                fileCopy(filename, directory_path, Application.dataPath+"/StreamingAssets/Fonts");
            }
        }
        
        public void OpenSingleFolder() {
            //Debug.Log("OpenSingleFolder");
            
            string path = FileBrowser.OpenSingleFolder("Open Folder");

            //Debug.Log("Selected folder: " + path);

            //Debug.Log("Files: " + FileBrowser.GetFiles(path, "*").CTDump());
            //Debug.Log("Directories: " + FileBrowser.GetDirectories(path).CTDump());
        }
        
        public void OpenFolders() {
            //Debug.Log("OpenFolders");
            
            //string[] paths = FileBrowser.OpenFolders("Open Files", string.Empty, true);
            string[] paths = FileBrowser.OpenFolders("Open Folders");

            /*
            foreach (string path in paths)
            {
                Debug.Log("Selected folder: " + path);
            }
            */
        }
        
        public void SaveFile() {
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

        public void OpenFilesAsync() {
            //Debug.Log("OpenFilesAsync");
            
            /*
            ExtensionFilter[] extensions = new[] {
                new ExtensionFilter("Image Files", "png", "jpg", "jpeg" ),
                new ExtensionFilter("Sound Files", "mp3", "wav" ),
                new ExtensionFilter("All Files", "*" ),
            };
            */
            
            //string extensions = string.Empty;
            
            //FileBrowser.OpenFilesAsync("Open Files", string.Empty, extensions, true, (string[] paths) => { writePaths(paths); });
        }
        
        public void OpenFoldersAsync() {
            //Debug.Log("OpenFoldersAsync");
            
            //FileBrowser.OpenFoldersAsync("Open Folders", string.Empty, true, (string[] paths) => { writePaths(paths); });
        }
        
        public void SaveFileAsync() {
            //Debug.Log("SaveFileAsync");
            
            /*
            ExtensionFilter[] extensions = new[] {
                        new ExtensionFilter("Binary", "bin"),
                        new ExtensionFilter("Text", "txt"),
                        new ExtensionFilter("C#", "cs"),
                    };
            */
            
            //string extensions = "txt";
            
            //FileBrowser.SaveFileAsync("Save File", string.Empty, "MySaveFile", extensions, (string paths) => { writePaths(paths); });
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
            }
            else
            {
                Debug.Log("Source path is Not Exists");
            }
        }

        private void writePaths(params string[] paths) {
            /*
            foreach (string path in paths)
            {
                Debug.Log("Selected path: " + path);
            }
            */
        }

        #endregion
    }
}
// © 2017-2018 crosstales LLC (https://www.crosstales.com)