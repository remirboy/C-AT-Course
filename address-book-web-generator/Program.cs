using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using address_book_web;
using address_book_web.Tests;
using System.IO;
using address_book_web.Models;
using Newtonsoft.Json;
using System.Collections;

namespace address_book_web_generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int dataCount = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            string model = args[3];
            ArrayList modelList = new ArrayList();
            if (model.Equals("group"))
            {
                for (int i=0; i < dataCount; i++)
                    modelList.Add(new GroupData()
                    {
                        GroupName = TestBase.GenerateRandomString(30),
                        GroupHeader = TestBase.GenerateRandomString(30),
                        GroupFooter = TestBase.GenerateRandomString(30)
                    }
                 );
            }
            else if (model.Equals("contact"))
            {
                for (int i = 0; i < dataCount; i++)
                    modelList.Add(new Contact()
                    {
                        Name = TestBase.GenerateRandomString(15),
                        LastName = TestBase.GenerateRandomString(15),
                        Address = TestBase.GenerateRandomString(15),
                        Email1 = TestBase.GenerateRandomString(15),
                        Email2 = TestBase.GenerateRandomString(15),
                        Email3 = TestBase.GenerateRandomString(15),
                        HomePhone = "44191",
                        MobilePhone = "89172462952",
                        WorkPhone = "89132462932"
                    }
                 );
            }
            for (int i = 0;i< modelList.Count;i++)
                Console.Out.WriteLine(";" + modelList[i]);
            if (format.Equals("json"))
                writer.AutoFlush = true;
                WriteToJSONFile(modelList, writer);
        }

        public static void WriteToJSONFile(ArrayList modelList, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(modelList, Formatting.Indented));
        }
    }
}
