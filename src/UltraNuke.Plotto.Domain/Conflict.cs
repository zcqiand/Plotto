using System.Xml;
using System.Xml.Linq;
using UltraNuke.TaleSpin.Utils;

namespace UltraNuke.Plotto.Domain;

/// <summary>
/// 持有单个 Ploto 冲突情况的对象。
/// </summary>
public class Conflict
{
    private XmlDocument soup;
    public string id;
    public string plain_text;

    public Conflict(XmlDocument soup, string conflict_id, Dictionary<string, string> characters)
    {
        this.soup = soup;
        id = conflict_id;

        var xnList = soup.SelectNodes($"//plotto//conflicts//conflict[@id='{conflict_id}']//permutations//permutation");
        var i = RandomUtil.Next(0, xnList.Count - 1);
        plain_text = xnList[i].InnerText;

        foreach(var character in characters)
        {
            plain_text = plain_text.Replace($"【{character.Key}】", character.Value);
        }

        xnList = soup.SelectNodes($"//plotto//characters//character");
        foreach (XmlNode xmlNode in xnList)
        {
            var text = xmlNode.InnerText;
            foreach (var character in characters)
            {
                text = text.Replace(character.Key, character.Value);
            }
            plain_text = plain_text.Replace($"【{xmlNode.Attributes["designation"].Value}】", text);
        }
    }
}




