# PaymentFlowWithRabbitMQ

## Geting started

No terminal execute:

``` bash
docker run -d — hostname my-rabbit — name rabbit13 -p 8080:15672 -p 5672:5672 -p 25676:25676 rabbitmq:3-management
```

Em seu projeto crie um contrato ou classe contendo as informações que deseja enviar:

``` csharp
public class PaymentRequestMessage
{
    public Guid Id { get; set; }
}
```

Adicione referência ao projeto Infra e instancie a classe MessagePublisher e utilize-o em seu código de acordo com o propósito:

### Publisher

``` csharp

var messagePublisher = new MessagePublisher<PaymentRequestMessage>(hostName: "localhost", queueName: "test_queue");
var message = new PaymentRequestMessage
{
    // dados do pagamento
};

messagePublisher.Publish(message);
```

### Consumer

``` csharp

var messagePublisher = new MessagePublisher<PaymentRequestMessage>(hostName: "localhost", queueName: "test_queue");

messagePublisher.StartConsume((p) =>
{
	Console.WriteLine($"{DateTime.Now} - Payment {p.Id} received.");
});
```

### MessagePublisher

Essa é a classe responsável por facilitar a gestão das filas, atualmente ela oferece os seguintes métodos:

| Método | Descrição |
|--------|-----------|
| Setup | Cria a fila caso ela ainda não exista. |
| Publish | Adiciona uma mensagem na fila. |
| StartConsume | Inicia o consumo da fila. |
| MessageReceivedEventHandler | Evento que dispara sempre que uma nova mensagem é recebida na fila. |

## Requisitos

- Docker
- RabbitMQ
