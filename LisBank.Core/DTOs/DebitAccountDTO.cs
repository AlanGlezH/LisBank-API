using System;
using LisBank.Core.Entities;

namespace LisBank.Core.DTOs
{
    public class DebitAccountDTO
    {
        public DebitAccountDTO()
        {
        }

        public int Id { get; set; }

        public virtual AccountDTO Account { get; set; }
    }
}
