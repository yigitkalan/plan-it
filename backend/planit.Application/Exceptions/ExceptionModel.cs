using Newtonsoft.Json;

namespace planit.Application.Exceptions;
public class ExceptionModel: ErrorStatusCode
{
    //keeping them as IEnumerable to handle inner exceptions
    public IEnumerable<string> Errors { get; set; }
    public override string ToString() => JsonConvert.SerializeObject(this);
}

public class ErrorStatusCode{
    public int StatusCode { get; set; }
}
