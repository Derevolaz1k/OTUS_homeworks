using System.Dynamic;
using System.Text.Json.Serialization;

namespace OTUS_Reflection;
[JsonSerializable(typeof(F))]
public class F
{
    [JsonInclude]
    public int i1, i2, i3, i4, i5;

    public static F Get() => new() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
}