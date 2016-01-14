using System.ComponentModel.DataAnnotations;

namespace Ingresso.ViewModel.Classes
{
    public class ItemSoldViewModel
    {
        public decimal Value { get; set; }

        //[CreditCard()]
        public string CardNumber1 { get; set; }

        public string CardNumber2 { get; set; }

        public string CardNumber3 { get; set; }

        public string CardNumber4 { get; set; }

        public int ExpMonth { get; set; }

        public int ExpYear { get; set; }

        public string SecurityCode { get; set; }

        public string HolderName { get; set; }
    }
}
