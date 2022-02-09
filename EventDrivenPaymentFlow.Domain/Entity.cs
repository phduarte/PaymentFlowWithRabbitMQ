using System;

namespace EventDrivenPaymentFlow.Domain
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
    }
}
