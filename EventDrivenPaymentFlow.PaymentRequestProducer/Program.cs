using EventDrivenPaymentFlow.Domain;
using System;
using EventDrivenPaymentFlow.Data;
using EventDrivenPaymentFlow.Infra.MessageBroker;

namespace EventDrivenPaymentFlow.PaymentRequestProducer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var banksRepository = new BanksRepository();
            var messagePublisher = new MessagePublisher<Payment>("localhost", "payments_request_queue");
            var continua = true;

            do
            {
                try
                {
                    var message = GetPaymentInfo(banksRepository);

                    messagePublisher.Publish(message);

                    Console.WriteLine($"{DateTime.Now} - Payment {message.Id} sent.");
                }
                catch
                {
                    continua = false;
                }

            } while (continua);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private static Payment GetPaymentInfo(IBanksRepository banksRepository)
        {
            Console.WriteLine("Digite os dados da sua conta:");
            Console.WriteLine();

            string bankNumber = GetParameter<string>("Número do Banco");

            var bank = banksRepository.GetByNumber(bankNumber);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(bank?.Name);
            Console.ResetColor();

            string clientName = GetParameter<string>("Nome do Cliente");
            string clientDocumentNumber = GetParameter<string>("Número do documento do cliente");
            string benecifiaryName = GetParameter<string>("Nome do beneficiário");
            string beneficiaryDocumentNumber = GetParameter<string>("Número do documento do beneficiário");
            var boleto = GetParameter<string>("Linha digitável");
            var dueDate = GetParameter<DateTime>("Data do Vencimento");
            var paymentDate = GetParameter<DateTime>("Data do Pagamento");
            var currency = GetParameter<string>("Moeda");
            var paymentValue = GetParameter<decimal>("Valor");

            return new Payment
            {
                Id = Guid.NewGuid(),
                DigitalizableLine = boleto,
                Value = new Money
                {
                    Currency = currency,
                    Value = paymentValue,
                },
                Date = paymentDate,
                DueDate = dueDate,
                Bank = bank,
                BankAccount = new BankAccount
                {
                    Bank = banksRepository.GetByNumber("655"),
                    Client = new Person
                    {
                        Name = clientName,
                        DocumentNumber = clientDocumentNumber
                    }
                },
                Beneficiary = new Person
                {
                    Name = benecifiaryName,
                    DocumentNumber = beneficiaryDocumentNumber
                },
                CreatedBy = Environment.UserName
            };
        }

        private static T GetParameter<T>(string parameterName)
        {
            var tentativas = 0;

            do
            {
                tentativas++;

                try
                {
                    Console.Write($"{parameterName}:");
                    var ret = Console.ReadLine();

                    return (T)Convert.ChangeType(ret, typeof(T));
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"O valor digitado não é valido. Verifique o dado e tente novamente. Restam {3 - tentativas}");
                    Console.ResetColor();
                }
            } while (tentativas < 3);

            throw new InvalidCastException($"A operação será cancelada devido a quantidade de tentativas falhas de digitar o {parameterName}.");
        }
    }
}
