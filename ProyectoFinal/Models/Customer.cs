﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ProyectoFinal.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        public DateTime CreateAt { get; set; }

        public bool State { get; set; }

        [JsonIgnore]
        public virtual ICollection<SalesInvoce> SalesInvoces { get; set; }

    }
}