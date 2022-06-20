#if UNITY_EDITOR // Should figure if its better to wrapp the whole thing in this so it wouldnt trigger perhaps
using UnityEditor;
#endif
using System.IO;
using System.Text.RegularExpressions;
namespace Framly
{
    public static class FYEnumGenerator
    {
        // get script root path and continue ./GeneratedEnums/
        public static string path = $"Packages/com.klavs.framly/Runtime/GeneratedEnums/";
        public static string csharp = ".cs"; // TODO: maybe can hardcode it? for other scripts support file enum types if needed
        public static void CreateEnum(string fileName, string[] enumList)
        {
            string filePathAndName = $"{path}{fileName}{csharp}";
            using (StreamWriter streamWriter = new StreamWriter(filePathAndName))
            {
                streamWriter.WriteLine("namespace Framly.Enums \n{");
                streamWriter.WriteLine("\t[System.Serializable]");
                streamWriter.WriteLine($"\tpublic enum {fileName}");
                streamWriter.WriteLine($"{"\t{"}");
                for (int i = 0; i < enumList.Length; i++)
                {
                    if (enumList[i].Contains(" "))
                        enumList[i] = Regex.Replace(enumList[i], @"\s+", "");
                    streamWriter.WriteLine("\t\t" + enumList[i] + ",");
                }
                streamWriter.WriteLine("\t}");
                streamWriter.WriteLine("}");
            }
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }
    }
}