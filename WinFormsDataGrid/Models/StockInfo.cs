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
        public decimal CurrentPrice { get; set; }
        [DisplayName("開盤")]
        [JsonProperty("o", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal OpenPrice { get; set; }
        [DisplayName("累積成交量")]
        [JsonProperty("v", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal CVD { get; set; }
        [DisplayName("漲跌")]
        public decimal OpenCurrentDiff { get { return CurrentPrice - OpenPrice; } }

    }
}
