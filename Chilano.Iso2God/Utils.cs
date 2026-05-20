using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Chilano.Iso2God
{
    internal class Utils
    {
        public static string sanitizePath(string path)
        {
            return new Regex(@"[\\/:*?""<>|]").Replace(path, "").Trim();
        }

        public static string getCsvTitle(string TitleID, string file)
        {
            var title = "";

            if (File.Exists(file))
            {
                try
                {
                    char delimiter = ',';

                    using (var reader = new StreamReader(file))
                    {
                        var firstLine = reader.ReadLine();
                        if (firstLine == null) return title;

                        if (firstLine.Contains("\t"))
                        {
                            delimiter = '\t';
                        }

                        string pattern = $"{delimiter}(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)";
                        var headers = Regex.Split(firstLine, pattern);

                        int idIndex = -1;
                        int nameIndex = -1;

                        for (int i = 0; i < headers.Length; i++)
                        {
                            var header = headers[i].Trim('\"').ToLower();
                            if (header == "title_id") idIndex = i;
                            if (header == "title_name") nameIndex = i;
                        }

                        if (idIndex == -1 || nameIndex == -1) return title;

                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = Regex.Split(line, pattern);
                            if (parts.Length > idIndex && parts.Length > nameIndex)
                            {
                                if (parts[idIndex].Trim('\"').ToUpper() == TitleID.ToUpper())
                                {
                                    title = parts[nameIndex].Trim('\"');
                                    break;
                                }
                            }
                        }
                    }
                }
                catch { }
            }

            return title;
        }
    }
}
