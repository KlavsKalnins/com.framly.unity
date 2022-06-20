#if UNITY_EDITOR
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;
#endif
// shoould move this to Non-Runtime scripts
namespace Framly
{
    public static class FYEnumGenerator
    {
        public static string path = $"Packages/com.klavs.framly/Runtime/GeneratedEnums/";
        public static string csharp = ".cs";
        public static void CreateEnum(string fileName, string[] enumList)
        {
#if UNITY_EDITOR
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
            AssetDatabase.Refresh();
#endif
        }
    }
}