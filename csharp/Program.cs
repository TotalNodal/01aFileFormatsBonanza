using System;
using Newtonsoft;
using Newtonsoft.Json;
using CsvHelper;
using System.Globalization;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var cust = new Customer()
        {
            FirstName = "Josh",
            LastName = "Lewis",
            Address = "123 main st"    
        };

        System.Console.WriteLine("serializing to json...");
        SerializeToJson(cust);
        System.Console.WriteLine("deserializing from json...");
        DeserializeFromJson(@"C:\Users\T580\Documents\GitHub\03aDataParsingServer\filetypes\customer.json");

        System.Console.WriteLine("serializing to csv...");
        SerializeToCsv(cust);
        System.Console.WriteLine("deserializing from csv...");
        DeserializeFromCsv("customerdata.csv");

        System.Console.WriteLine("serializing to xml...");
        
        SerializeToXml(cust);
        System.Console.WriteLine("deserializing from xml...");
        DeserializeFromXml("customer.xml");

        System.Console.WriteLine("serializing to yaml...");
        SerializeToYaml(cust);
        System.Console.WriteLine("deserializing from yaml...");
        DeserializeFromYaml("customer.yaml");

        System.Console.WriteLine("serializing to text...");
        SerializeToText(cust);
        System.Console.WriteLine("deserializing from text...");
        DeserializeFromText("customer.txt");
       

        Console.ReadKey();
    }



    //Serialization and Deserialization



    //Json
    private static void SerializeToJson(Customer cust)
    {
        
        string json = JsonConvert.SerializeObject(cust, Formatting.Indented);

        System.Console.WriteLine(json);
    }

    private static void DeserializeFromJson(string filename)
    {
        string json = System.IO.File.ReadAllText(filename);
        var customer = JsonConvert.DeserializeObject<Customer>(json);
        System.Console.WriteLine(customer.FirstName);
    }

    //Csv
    private static void SerializeToCsv(Customer cust)
    {
        using var writer = new StreamWriter("customerdata.csv");
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(new List<Customer> { cust });
    }
    private static void DeserializeFromCsv(string filename)
    {
        using var reader = new StreamReader(filename);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<Customer>();
        foreach (var customer in records)
        {
            Console.WriteLine(customer.FirstName + "," + customer.LastName + "," + customer.Address);
        }
    }

    //Xml
    private static void SerializeToXml(Customer cust)
    {
        var xmlSerializer = new XmlSerializer(typeof(Customer));
        using (var writer = new StreamWriter("customer.xml"))
        {
            xmlSerializer.Serialize(writer, cust);
        }
    }

    private static void DeserializeFromXml(string filename)
    {
        var xmlSerializer = new XmlSerializer(typeof(Customer));
        using (var reader = new StreamReader(filename))
        {
            var customer = (Customer)xmlSerializer.Deserialize(reader);
            Console.WriteLine(customer.FirstName);
        }
    }

    //Yaml
    private static void SerializeToYaml(Customer cust)
    {
        var serializer = new YamlDotNet.Serialization.Serializer();
        var yaml = serializer.Serialize(cust);
        Console.WriteLine(yaml);
    }

    private static void DeserializeFromYaml(string filename)
    {
        var deserializer = new YamlDotNet.Serialization.Deserializer();
        var yaml = File.ReadAllText(filename);
        var customer = deserializer.Deserialize<Customer>(yaml);
        Console.WriteLine(customer.FirstName);
    }

    //Text
    private static void SerializeToText(Customer cust)
    {
        var text = $"{cust.FirstName},{cust.LastName},{cust.Address}";
        Console.WriteLine(text);
    }

    private static void DeserializeFromText(string filename)
    {
        var text = File.ReadAllText(filename);
        var parts = text.Split(',');
        var customer = new Customer
        {
            FirstName = parts[0],
            LastName = parts[1],
            Address = parts[2]
        };
        Console.WriteLine(customer.FirstName);
    }


    //Encoding and Decoding
    private static void EncodeToBase64(string text)
    {
        var bytes = Encoding.UTF8.GetBytes(text);
        var base64 = Convert.ToBase64String(bytes);
        Console.WriteLine(base64);
    }

    private static void DecodeFromBase64(string base64)
    {
        var bytes = Convert.FromBase64String(base64);
        var text = Encoding.UTF8.GetString(bytes);
        Console.WriteLine(text);
    }


}

