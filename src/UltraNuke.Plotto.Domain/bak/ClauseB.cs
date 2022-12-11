namespace UltraNuke.Plotto.Domain;

/// <summary>
/// “B”条款
/// </summary>
public class ClauseB
{
    /// <summary>
    /// 编号
    /// </summary>
    public string Code { set; get; }
    /// <summary>
    /// 描述
    /// </summary>
    public string Description { set; get; }

    /// <summary>
    /// 冲突集合
    /// </summary>
    public string[] Conflicts {set;get;}
}
