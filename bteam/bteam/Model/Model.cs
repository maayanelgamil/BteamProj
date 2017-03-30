using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    class Model
    {
        public Model()
        {

        }

        public int getNumOfWords(string path)
        {
            int result;
            string text;
            using (StreamReader streamReader = new StreamReader(path))
            {
                text = streamReader.ReadToEnd();
            }
            result = text.Split(' ').Length;
            return result;
        }
    }
}
