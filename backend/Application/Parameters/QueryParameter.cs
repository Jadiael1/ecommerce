
namespace Application.Parameters;

public class QueryParameter : PagingParameter
{
    public virtual string OrderBy { get; set; } = string.Empty;
    public virtual string Fields { get; set; } = string.Empty;

}

