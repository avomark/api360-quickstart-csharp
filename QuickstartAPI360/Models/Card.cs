using System;
namespace QuickstartAPI360.Models
{
    public class Card
    {
        public string number { get; set; }
        public string customerId { get; set; }
        public int type { get; set; }
        public int fidelityId { get; set; }
        public bool isActive { get; set; }
        public bool isActive { get; set; }



  "number": "string",
  "customerId": 0,
  "type": 0,
  "fidelityId": 0,
  "isActive": true,
  "balances": [
    {
      "shopId": 0,
      "available": true,
      "discount": 0,
      "purchases": 0,
      "purchaseAmount": 0,
      "discountCumulative": 0,
      "purchasesCumulative": 0,
      "purchaseAmountCumulative": 0,
      "info": "string",
      "primaryLoyaltyBalance": {
        "label": "string",
        "type": "string",
        "value": {},
        "moneyCurrency": "string"
      },
      "dateFirstPurchase": "2019-03-23T07:13:48.516Z",
      "dateLastPurchase": "2019-03-23T07:13:48.516Z"
    }
  ],
  "composition": {
    "prefix": "string",
    "number": "string",
    "crc": "string"
  }
}
    }
}
