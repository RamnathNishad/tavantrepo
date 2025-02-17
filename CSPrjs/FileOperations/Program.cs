using System.IO;
using System.Security.Cryptography;
using MessagePack;
using System.Xml;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using N1;
using N3;
using N1.N2;

namespace FileOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {

           N1.Hr hr = new N1.Hr();

            Department dept=new Department ();
            Project project=new Project ();

            N3.Hr hr2 = new N3.Hr();    



            //WriteTextFormat();
            //ReadTextFormat();

            //WriteBinaryData();
            //ReadBinaryFormat();

            //SerializeEmp();
            DeserializeEmp();
        }
        static void WriteTextFormat()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("letter.txt", FileMode.Create, FileAccess.Write);

                StreamWriter sw = new StreamWriter(fs);
                string str = "";
                Console.WriteLine("Enter lines(pres ENTER to finish):");
                str = Console.ReadLine();

                while (!String.IsNullOrEmpty(str))
                {
                    sw.WriteLine(str);
                    str = Console.ReadLine();
                }

                Console.WriteLine("Data written to file");
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        static void ReadTextFormat()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("letter.txt", FileMode.Open, FileAccess.Read);

                StreamReader sr = new StreamReader(fs);

                string str = sr.ReadLine();
                while (!String.IsNullOrEmpty(str))
                {
                    Console.WriteLine(str);
                    str = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        static void WriteBinaryData()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("data.txt", FileMode.Create, FileAccess.Write);

                int ecode = 101;
                string ename = "ramnath";
                int salary = 1111;

                BinaryWriter bw = new BinaryWriter(fs);

                bw.Write(ecode);
                bw.Write(ename);
                bw.Write(salary);

                Console.WriteLine("Data written");

                bw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    
        static void ReadBinaryFormat()
        {
            FileStream fs = null;
            try
            {

                fs = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                int ecode = br.ReadInt32();
                string ename = br.ReadString();
                int salary = br.ReadInt32();

                Console.WriteLine($"{ecode}\t{ename}\t{salary}"); 

                br.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    
        static void SerializeEmp()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("emp.txt", FileMode.Create, FileAccess.Write);
                //use MessagePack
                var emp = new Employee
                {
                    Ecode=101,
                    Ename="Ravi",
                    Salary=1111
                };
                //MessagePackSerializer.Serialize(fs,emp);
                XmlSerializer serializer = new XmlSerializer(emp.GetType());
                serializer.Serialize(fs, emp);
                
                Console.WriteLine("data saved");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                fs.Close();
            }
        }

        static void DeserializeEmp()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("emp.txt", FileMode.Open, FileAccess.Read);
                //use MessagePack

                //var emp = MessagePackSerializer.Deserialize<Employee>(fs);

                XmlSerializer serializer = new XmlSerializer(typeof(Employee));
                var emp=(Employee)serializer.Deserialize(fs);

                Console.WriteLine($"{emp.Ecode}\t{emp.Ename}\t{emp.Salary}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}


//[MessagePackObject]
public class Employee
{
    //[Key(0)]
    public int Ecode { get; set; }
    //[Key(1)] 
    public string Ename { get; set; }
    //[Key(2)] 
    public int Salary { get; set; }
}

namespace N1
{

    class Hr
    {

    }

    namespace N2
    {
        class Department
        {

        }
    }
}

namespace N3
{
    class Hr
    {

    }
}