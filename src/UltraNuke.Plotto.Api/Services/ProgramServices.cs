using Microsoft.VisualBasic;
using System.Text;
using System.Xml;
using UltraNuke.Plotto.Domain;

namespace UltraNuke.Plotto.Api.Services;

public class ProgramServices
{
    private readonly ILogger _logger;

    public ProgramServices(ILogger logger)
    {
        _logger = logger;
    }

    public string print_story()
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.Load("plotto-cn.xml");
        var characters = new Dictionary<string, string>
        {
            { "A", "郭靖" },
            { "B", "黄蓉" }
        };
        var storyline = new Storyline(xmlDoc, characters,"测试1");
        string[] letters = new string[] { "A", "B", "C" };
        foreach (var letter in letters)
        {
            storyline.get_clause(letter);
        }
        for(int i=0;i<20;i++)
        {
            storyline.expand_story();
        }
        return storyline.print_story();
    }

    //public void ReadXmlNode()
    //{
    //    var plot = new Masterplot();
    //    using (var sw = new StreamWriter("plotto-character.txt")) 
    //    {
    //        foreach (var s in plot.Characters)
    //        {
    //            sw.WriteLine(s.Description);
    //        }
    //    }
    //    using (var sw = new StreamWriter("plotto-subject.txt"))
    //    {
    //        foreach (var s in plot.ClauseAs)
    //        {
    //            sw.WriteLine(s.Description);
    //        }
    //    }
    //    using (var sw = new StreamWriter("plotto-predicate.txt"))
    //    {
    //        foreach (var s in plot.ClauseBs)
    //        {
    //            sw.WriteLine(s.Description);
    //        }
    //    }
    //    using (var sw = new StreamWriter("plotto-outcome.txt"))
    //    {
    //        foreach (var s in plot.ClauseCs)
    //        {
    //            sw.WriteLine(s.Description);
    //        }
    //    }

    //    var xmlDoc = new XmlDocument();
    //    xmlDoc.Load("plotto.xml");

    //    var xnList = xmlDoc.SelectNodes("//plotto//conflicts//conflict//permutations//permutation//description");
    //    string[] lines = File.ReadAllLines("plotto-conflict.txt");
    //    var i = 0;
    //    foreach (XmlNode xn in xnList)
    //    {
    //        xn.InnerText = lines[i];
    //        i++;
    //    }

    //    xnList = xmlDoc.SelectNodes("//plotto//characters//character");
    //    lines = File.ReadAllLines("plotto-character.txt");
    //    i = 0;
    //    foreach (XmlNode xn in xnList)
    //    {
    //        xn.InnerText = lines[i];
    //        i++;
    //    }

    //    xnList = xmlDoc.SelectNodes("//plotto//subjects//subject//description");
    //    lines = File.ReadAllLines("plotto-subject.txt");
    //    i = 0;
    //    foreach (XmlNode xn in xnList)
    //    {
    //        xn.InnerText = lines[i];
    //        i++;
    //    }

    //    xnList = xmlDoc.SelectNodes("//plotto//predicates//predicate//description");
    //    lines = File.ReadAllLines("plotto-predicate.txt");
    //    i = 0;
    //    foreach (XmlNode xn in xnList)
    //    {
    //        xn.InnerText = lines[i];
    //        i++;
    //    }

    //    xnList = xmlDoc.SelectNodes("//plotto//outcomes//outcome//description");
    //    lines = File.ReadAllLines("plotto-outcome.txt");
    //    i = 0;
    //    foreach (XmlNode xn in xnList)
    //    {
    //        xn.InnerText = lines[i];
    //        i++;
    //    }

    //    xmlDoc.Save("plotto-cn.xml");
    //}
}
