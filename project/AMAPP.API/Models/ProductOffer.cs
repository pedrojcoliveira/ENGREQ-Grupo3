﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AMAPP.API.Constants;


namespace AMAPP.API.Models
{
    public class ProductOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int PeriodSubscriptionId { get; set; }
        public SubscriptionPeriod PeriodSubscription { get; set; }
        public List<SelectedDeliveryDate> SelectedDeliveryDates { get; set; } = new List<SelectedDeliveryDate>();
       public PaymentMethod PaymentMethod { get; set; }
       public PaymentMode PaymentMode { get; set; }
    }

}
