using System.Text;
using System.Xml;
using System.Xml.Linq;
using UltraNuke.TaleSpin.Utils;

namespace UltraNuke.Plotto.Domain;

/// <summary>
/// 故事情节的容器，一连串的情节
/// </summary>
public class Storyline
{
    private XmlDocument soup;
    private string name;
    private string A_clause;
    private string B_clause;
    private List<Conflict> story;
    private string C_clause;
    private Dictionary<string, string> characters;
    private string transpositions;
    private string conflict2B;

    public Storyline(XmlDocument soup, Dictionary<string,string> characters, string name)
    {
        this.soup = soup;
        this.name = name;
        A_clause = "";
        B_clause = "";
        story = new List<Conflict>();
        C_clause = "";
        this.characters = characters;
    }

    //如果未提供 clause_id，则获取随机子句，否则获取相应的子句条款。
    public void get_clause(string clause_letter)
    {

        switch (clause_letter)
        {
            case "A":
                var xnList = soup.SelectNodes("//plotto//subjects//subject");
                var i = RandomUtil.Next(0, xnList.Count - 1);
                A_clause = xnList[i]["description"].InnerText;
                break;
            case "B":
                xnList = soup.SelectNodes("//plotto//predicates//predicate");
                i = RandomUtil.Next(0, xnList.Count - 1);
                B_clause = xnList[i]["description"].InnerText;
                break;
            case "C":
                xnList = soup.SelectNodes("//plotto//outcomes//outcome");
                i = RandomUtil.Next(0, xnList.Count - 1);
                C_clause = xnList[i]["description"].InnerText;
                break;
        }
    }

    /// <summary>
    /// 将冲突添加到冲突列表的功能。
    /// 如果列表为空，则根据 B 子句生成第一个冲突位。
    /// </summary>
    public void expand_story()
    {
        //根据B子句得到第一个冲突
        if (story.Count == 0)
        {
            var xnList = soup.SelectNodes("//plotto//predicates//predicate//conflict-link");
            if (xnList.Count == 0) return;
            var i = 0;
            if (xnList.Count > 1)
            {
                i = RandomUtil.Next(0, xnList.Count - 1);
            }
            var conflictId = xnList[i].Attributes["ref"].Value;
            if (!story.Where(w => w.id.Equals(conflictId)).Any())
            {
                story.Add(new Conflict(soup, conflictId, characters));
            }
        }
        else
        {
            var count = story.Count;
            var conflict = story[count - 1];
            var xnList = soup.SelectNodes($"//plotto//conflicts//conflict[@id='{conflict.id}']//group//conflict-link");
            if (xnList.Count == 0) return;
            var i = 0;
            if (xnList.Count > 1)
            {
                i = RandomUtil.Next(0, xnList.Count - 1);
            }
            var conflictId = xnList[i].Attributes["ref"].Value;
            if (!story.Where(w => w.id.Equals(conflictId)).Any())
            {
                story.Add(new Conflict(soup, conflictId, characters));
            }
        }
    }

    public string print_story()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{A_clause}，{B_clause}，{C_clause}");
        sb.AppendLine();
        foreach (var conflict in story)
        {
            sb.AppendLine(conflict.plain_text);
        }
        return sb.ToString();
    }
}




