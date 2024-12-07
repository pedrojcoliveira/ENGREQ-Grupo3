﻿using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.Models
{
    public class SelectedDeliveryDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProductOfferId { get; set; }
        public ProductOffer ProductOffer { get; set; }

    }
}
