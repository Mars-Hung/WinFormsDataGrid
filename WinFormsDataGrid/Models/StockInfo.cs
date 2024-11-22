using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsDataGrid.Models
{
    public class StockInfo
    {
        [DisplayName("代碼")]
        [JsonProperty("c")]
        public string StockId { get; set; }
        [DisplayName("名稱")]
        [JsonProperty("n")]
        public string Name { get; set; }
        [DisplayName("成交價")]
        [JsonProperty("z", DefaultValueHandling = DefaultValueHandling.Ignore)]
        //[JsonConverter(typeof(DecimalConverter))]

        public decimal CurrentPrice { get; set; }
        [DisplayName("開盤")]
        [JsonProperty("o", DefaultValueHandling = DefaultValueHandling.Ignore)]
        //[JsonConverter(typeof(DecimalConverter))]

        public decimal OpenPrice { get; set; }
        [DisplayName("累積成交量")]
        [JsonProperty("v", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal CVD { get; set; }
        [DisplayName("漲跌")]
        public decimal OpenCurrentDiff { get { return CurrentPrice - OpenPrice; } }

    }
    public class DecimalConverter : JsonConverter<decimal>
    {
        public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String && reader.Value?.ToString() != "-")
            {
                return Convert.ToDecimal(reader.Value);
            }
            if (reader.TokenType == JsonToken.String && reader.Value?.ToString() == "-")
            {
                return 0; // 或者你想要的值，例如：return default(decimal);
            }

            if (reader.TokenType == JsonToken.Float || reader.TokenType == JsonToken.Integer)
            {
                return Convert.ToDecimal(reader.Value);
            }
           

            throw new JsonSerializationException($"無法將值 '{reader.Value}' 轉換為 decimal");
        }

        public override void WriteJson(JsonWriter writer, decimal value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
