using System;
using EventDrivenPaymentFlow.Domain;
using EventDrivenPaymentFlow.Data;
using EventDrivenPaymentFlow.Infra.MessageBroker;

namespace EventDrivenPaymentFlow.PaymentRequestConsumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var paymentRepository = new PaymentsRepository();
            var messagePublisher = new MessagePublisher<Payment>("localhost", "payments_request_queue");

            Console.WriteLine($"{DateTime.Now} - {nameof(PaymentRequestConsumer)} started.");

            //messagePublisher.MessageReceived += MessagePublisher_MessageReceived; 
            //messagePublisher.StartConsume();
            //messagePublisher.StartConsume(MessagePublisher_MessageReceived);
            messagePublisher.StartConsume((p) =>
            {
                Console.WriteLine($"{DateTime.Now} - Payment {p.Id} received.");
            });

            Console.WriteLine($"{DateTime.Now} - {nameof(PaymentRequestConsumer)} finished.");
            Console.ReadLine();
        }

        private static void MessagePublisher_MessageReceived(Payment payment)
        {
            Console.WriteLine($"{DateTime.Now} - Payment {payment.Id} received.");
        }
    }
}
