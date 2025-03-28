﻿using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models.DataAnnotations
{
    public class Pedido
    {
        public int Id { get; set; }

        [ForeignKey ("Colaborador")]
        public int ColaboradorId { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("Supervisor")]
        public int SupervisorId { get; set; }

        public Usuario? Cliente { get; set; }
        public Usuario? Colaborador { get; set; }
        public Usuario? Supervisor { get; set; }
    }
}
