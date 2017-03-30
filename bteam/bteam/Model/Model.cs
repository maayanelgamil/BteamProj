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

        public string getNumOfWords(string path)
        {
            string result;
            using (StreamReader streamReader = new StreamReader(path))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}
