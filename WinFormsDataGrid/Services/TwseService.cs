using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsDataGrid.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WinFormsDataGrid.Services
{
    public class TwseService
    {
        public async Task<List<StockInfo>> GetStockPricesAsync(List<string> stockIds)
        {
            var stockInfoList = new List<StockInfo>();
            var stockIdString = string.Join("|", stockIds);
            var url = $"https://mis.twse.com.tw/stock/api/getStockInfo.jsp?ex_ch={stockIdString}&json=1&delay=0";

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var json = JObject.Parse(response);
                //var msgArray = json["msgArray"] as JArray;
                var msgArray = json["msgArray"]?.ToString();

                if (msgArray != null)
                {
                    // 直接反序列化 msgArray 為 List<StockInfo>
                    return JsonConvert.DeserializeObject<List<StockInfo>>(msgArray);

                    //foreach (var item in msgArray)
                    //{
                    //    if (!string.IsNullOrEmpty(item["c"]?.ToString()))
                    //    {
                    //        var stockInfo = new StockInfo
                    //        {
                    //            StockId = item["c"]?.ToString(), // 股票代碼
                    //            Name = item["n"]?.ToString(),   // 股票名稱
                    //            CurrentPrice = decimal.TryParse(item["z"]?.ToString(), out var price) ? price : 0 // 當前價格
                    //        };
                    //        stockInfoList.Add(stockInfo);
                    //    }
                    //    else
                    //    {
                    //        continue;
                    //    }
                    //}
                }
            }

            return stockInfoList;
        }
    }
}
