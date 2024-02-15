using System.Text;

namespace OTUS_Reflection;

public static class MySerializer
{
    public static string Serialize<T>(T obj)
    {
        var sb = new StringBuilder("{");
        var type = obj?.GetType();
        var fields = type?.GetFields();
        foreach (var field in fields)
        {
            var val = field.GetValue(obj);
            switch (val)
            {
                case null:
                    sb.Append("\"" + field.Name + "\"" + ": " + "null");
                    break;
                case string str:
                    sb.Append("\"" + field.Name + "\"" + ": " + "\"" + str + "\"");
                    break;
                default:
                    sb.Append("\"" + field.Name + "\"" + ": " + val);
                    break;
            }
            sb.Append(fields.Last() != field ? "," : "}");
        }

        return sb.ToString();
    }
    public static T Deserialize<T>(string json)
    {
        var obj = Activator.CreateInstance<T>();
        var type = typeof(T);

        // Убедимся, что строка начинается с '{' и заканчивается '}'
        if (json.StartsWith("{") && json.EndsWith("}"))
        {
            // Удалим внешние скобки
            json = json.Substring(1, json.Length - 2);

            // Разделим строку на пары "ключ-значение" по запятой
            var keyValuePairs = json.Split(',');

            foreach (var pair in keyValuePairs)
            {
                // Разделим пару "ключ-значение" по двоеточию
                var keyValue = pair.Split(':');

                // Извлечем имя ключа и значение
                var key = keyValue[0].Trim(' ', '\"');
                var value = keyValue[1].Trim(' ');

                // Найдем соответствующее поле в объекте и установим его значение
                var field = type.GetField(key);
                if (field != null)
                {
                    // Преобразуем строковое значение в нужный тип поля
                    var parsedValue = ParseValue(field.FieldType, value);
                    field.SetValue(obj, parsedValue);
                }
            }
        }

        return obj;
    }

    private static object ParseValue(Type type, string value)
    {
        // Простейшая логика преобразования строкового значения в нужный тип
        if (type == typeof(int))
        {
            return int.Parse(value);
        }

        if (type == typeof(string))
        {
            return value.Trim('\"');
        }
        // Добавьте другие типы по необходимости

        throw new NotSupportedException($"Не поддерживаемый тип: {type}");
    }
}